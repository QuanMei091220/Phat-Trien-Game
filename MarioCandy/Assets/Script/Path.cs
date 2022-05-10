using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform[] listPoint;

    public int start = 0;
    public int end = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrawGizmos()
    {
        if (listPoint == null || listPoint.Length < 1)
        {
            return;
        }
        for (int i = 1; i < listPoint.Length; i++)
        {
            Gizmos.DrawLine(listPoint[i - 1].position, listPoint[i].position);
        }
    }

    public Transform getPoint(int p)
    {
        return listPoint[p];
    }

    public Transform getNextPoint()
    {
        if (start == 0)
        {
            end = 1;
        }
        else if (start == listPoint.Length - 1)
        {
            end = -1;
        }
        start += end;
        return listPoint[start];
    }
}
