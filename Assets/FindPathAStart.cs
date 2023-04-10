using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathMarker
{
    public MapLocation location;
    public float G;
    public float H;
    public float F;
    public GameObject marker;
    public PathMarker parrent;

    public PathMarker(MapLocation l, float g, float h, float f, GameObject marker, PathMarker p)
    {
        location = l;
        G = g;
        H = h;
        F = f;
        this.marker = marker;
        parrent = p;
    }

    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            return location.Equals(((PathMarker)obj).location);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

public class FindPathAStart : MonoBehaviour
{
    public Maze Maze;
    public Material closeMaterials;
    public Material openMaterilas;

    private List<PathMarker> open = new List<PathMarker>();
    private List<PathMarker> close = new List<PathMarker>();
    public GameObject start;
    public GameObject end;
    public GameObject pathP;

    private PathMarker goalNode;
    private PathMarker startNode;
    private PathMarker lastPos;
    private bool done = false;

    private void RemoveAllMarkers()
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("marker");
        foreach (GameObject m in markers)
            Destroy(m);
    }

    private void BeginSerach()
    {
        done = false;
        RemoveAllMarkers();

        List<MapLocation> locations = new List<MapLocation>();
        for (int z = 1; z < Maze.depth - 1; z++)
        {
            for (int x = 1; x < Maze.width - 1; x++)
            {
                if (Maze.map[x, z] != 1)
                {
                    locations.Add(new MapLocation(x, z));
                }
            }
        }

        locations.Shuffle();

        Vector3 startLocation = new Vector3(locations[0].x * Maze.scale, 0, locations[0].z * Maze.scale);
        startNode = new PathMarker(new MapLocation(locations[0].x, locations[0].z), 0, 0, 0, Instantiate(start, startLocation, Quaternion.identity), null);

        Vector3 goalLocation = new Vector3(locations[1].x * Maze.scale, 0, locations[1].z * Maze.scale);
        goalNode = new PathMarker(new MapLocation(locations[1].x, locations[1].z), 0, 0, 0, Instantiate(end, goalLocation, Quaternion.identity), null);

        open.Clear();
        close.Clear();
        lastPos = startNode;
    }

    private void Search(PathMarker thisNode)
    {
        if (thisNode.Equals(goalNode))
        {
            done = true;
            return;
        }

        foreach (MapLocation dir in Maze.directions)
        {
            MapLocation neighbour = dir + thisNode.location;
            if (Maze.map[neighbour.x, neighbour.z] == 1) continue;
            if (neighbour.x < 1 || neighbour.x >= Maze.width || neighbour.z < 1 || neighbour.z >= Maze.depth) continue;
            if (IsClosed(neighbour)) continue;

            float G = Vector2.Distance(thisNode.location.ToVector(), neighbour.ToVector()) + thisNode.G;
            float H = Vector2.Distance(neighbour.ToVector(), goalNode.location.ToVector());

            float F = G + H;
            GameObject pathBlock = Instantiate(pathP, new Vector3(neighbour.x * Maze.scale, 0, neighbour.z * Maze.scale), Quaternion.identity);

            TextMesh[] values = pathBlock.GetComponentsInChildren<TextMesh>();
            values[0].text = "G : " + G.ToString("0.00");

            values[1].text = "H : " + H.ToString("0.00");
            values[2].text = "F : " + F.ToString("0.00");

            if (!UpdateMarker(neighbour, G, H, F, thisNode))
            {
                open.Add(new PathMarker(neighbour, G, H, F, pathBlock, thisNode));
            }
        }

        open = open.OrderBy(p => p.F).ThenBy(n => n.H).ToList<PathMarker>();
        open.RemoveAt(0);
        PathMarker pm = (PathMarker)open.ElementAt(0);
        close.Add(pm);
        open.RemoveAt(0);
        pm.marker.GetComponent<Renderer>().material = closeMaterials;
        lastPos = pm;
    }

    private bool UpdateMarker(MapLocation pos, float g, float h, float f, PathMarker prt)
    {
        foreach (PathMarker p in open)
        {
            if (p.location.Equals(pos))
            {
                p.G = g;
                p.H = h;
                p.F = f;
                p.parrent = prt;
                return true;
            }
        }

        return false;
    }

    private bool IsClosed(MapLocation marker)
    {
        foreach (PathMarker p in close)
        {
            if (p.location.Equals(marker)) return true;
        }

        return false;
    }

    private void GetPath()
    {
        RemoveAllMarkers();
        PathMarker begin = lastPos;
        while (!startNode.Equals(begin) && begin != null)
        {
            Instantiate(pathP, new Vector3(begin.location.x * Maze.scale, 0, begin.location.z * Maze.scale), Quaternion.identity);
            begin = begin.parrent;
        }
        Instantiate(pathP, new Vector3(startNode.location.x * Maze.scale, 0, startNode.location.z * Maze.scale), Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) BeginSerach();

        if (Input.GetKeyDown(KeyCode.C)) Search(lastPos);

        if (Input.GetKeyDown(KeyCode.M)) GetPath();
    }
}
