using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public List<Edge> edgeList = new List<Edge>();

    public Node path = null;
    private GameObject id;
    /*public float xPos;
    public float yPos;
    public float zPos;*/
    public float f, g, h;
    public Node cameFrom;

    public Node(GameObject i)
    {
        id = i;
        /*  xPos = i.transform.position.x;
          yPos = i.transform.position.y;
          zPos = i.transform.position.z;*/
        path = null;
    }

    public GameObject getId()
    {
        return id;
    }
}
