using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction
    { UNI, BI }

    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WayPointManager : MonoBehaviour
{
    public GameObject[] wayPoints;
    public Link[] links;

    public Graphs graph = new Graphs();

    // Start is called before the first frame update
    private void Start()
    {
        if (wayPoints.Length > 0)
        {
            foreach (GameObject wp in wayPoints)
            {
                graph.AddNode(wp);
            }
            foreach (Link l in links)
            {
                graph.AddEdge(l.node1, l.node2);
                if (l.dir == Link.direction.BI)
                {
                    graph.AddEdge(l.node2, l.node1);
                }
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
