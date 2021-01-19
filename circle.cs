using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    public int res = 7;
    public float radius = 1f;
    Vector3[] points;
  
    MeshFilter filter;
    Mesh m;
    private void Start()
    {
        filter = GetComponent<MeshFilter>();
    }
    private void Update()
    {
        List<int> tris= new List<int>();
        //Build vertices,Middle one first
        points = new Vector3[res+2];
        points[0] = Vector3.zero;
        float slice = 2 * Mathf.PI/res;
       
            for (int i = 1; i < res + 2; i++)
            {
                float angle = slice * i;
                float x = (radius * Mathf.Cos(angle));
                float z = (radius * Mathf.Sin(angle));
                points[i] = new Vector3(x, 0, z);
            }

        //Build triangles
        int v = 0;
        for (int i = 0; i < res+1; i++)
        {
            if (i != res)
            {
                tris.Add(0);
                tris.Add(v + 1);
                tris.Add(v);
            }
            else
            {
                //Handle the last triangle
                tris.Add(0);
                tris.Add(1);
                tris.Add(v);
            }
                    
            v++;
        }
        

        m = new Mesh();
        m.vertices = points;
        m.triangles = tris.ToArray();
        m.RecalculateNormals();
        filter.mesh = m;
    }
   
}
