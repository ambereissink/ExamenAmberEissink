using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public bool walkable;
    public Vector3 worldposition;

    public Node(bool nodeWalkable, Vector3 worldPos)
    {
        walkable = nodeWalkable;
        worldposition = worldPos;
    }
}
