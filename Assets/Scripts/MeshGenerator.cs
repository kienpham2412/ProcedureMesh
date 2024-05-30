using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public MeshFilter meshFilter;

    /// <summary>
    /// Reset is called when the user hits the Reset button in the Inspector's
    /// context menu or when adding the component the first time.
    /// </summary>
    void Reset()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        meshFilter.mesh = GenerateMesh();
    }

    private Mesh GenerateMesh()
    {
        var mesh = new Mesh
        {
            name = "NewMesh"
        };

        var listVerts = new List<Vector3>();
        var listTrisIndices = new List<int>();
        listVerts.AddRange(CreateBackFace(0, ref listTrisIndices));
        listVerts.AddRange(CreateFrontFace(1, ref listTrisIndices));
        listVerts.AddRange(CreateLeftFace(2, ref listTrisIndices));
        listVerts.AddRange(CreateRightFace(3, ref listTrisIndices));
        listVerts.AddRange(CreateBelowFace(4, ref listTrisIndices));
        listVerts.AddRange(CreateAboveFace(5, ref listTrisIndices));
        mesh.vertices = listVerts.ToArray();
        mesh.triangles = listTrisIndices.ToArray();
        return mesh;
    }

    private int[] CalculateTrisIndices(int order, int[] localIndices)
    {
        for (int i = 0; i < localIndices.Length; i++)
            localIndices[i] += order * 4;
        return localIndices;
    }

    private Vector3[] CreateBackFace(int order, ref List<int> tris)
    {
        var p1 = new Vector3(-0.5f, 0.5f, -0.5f);
        var p2 = new Vector3(0.5f, 0.5f, -0.5f);
        var p3 = new Vector3(0.5f, -0.5f, -0.5f);
        var p4 = new Vector3(-0.5f, -0.5f, -0.5f);

        var indices = new int[] { 0, 1, 2, 0, 2, 3 };
        indices = CalculateTrisIndices(order, indices);
        tris.AddRange(indices);
        return new Vector3[] { p1, p2, p3, p4 };
    }

    private Vector3[] CreateFrontFace(int order, ref List<int> tris)
    {
        var p1 = new Vector3(-0.5f, 0.5f, 0.5f);
        var p2 = new Vector3(0.5f, 0.5f, 0.5f);
        var p3 = new Vector3(0.5f, -0.5f, 0.5f);
        var p4 = new Vector3(-0.5f, -0.5f, 0.5f);

        var indices = new int[] { 0, 3, 2, 0, 2, 1 };
        indices = CalculateTrisIndices(order, indices);
        tris.AddRange(indices);
        return new Vector3[] { p1, p2, p3, p4 };
    }

    private Vector3[] CreateLeftFace(int order, ref List<int> tris)
    {
        var p1 = new Vector3(-0.5f, 0.5f, 0.5f);
        var p2 = new Vector3(-0.5f, 0.5f, -0.5f);
        var p3 = new Vector3(-0.5f, -0.5f, -0.5f);
        var p4 = new Vector3(-0.5f, -0.5f, 0.5f);

        var indices = new int[] { 0, 1, 2, 0, 2, 3 };
        indices = CalculateTrisIndices(order, indices);
        tris.AddRange(indices);
        return new Vector3[] { p1, p2, p3, p4 };
    }

    private Vector3[] CreateRightFace(int order, ref List<int> tris)
    {
        var p1 = new Vector3(0.5f, 0.5f, 0.5f);
        var p2 = new Vector3(0.5f, 0.5f, -0.5f);
        var p3 = new Vector3(0.5f, -0.5f, -0.5f);
        var p4 = new Vector3(0.5f, -0.5f, 0.5f);

        var indices = new int[] { 0, 3, 2, 0, 2, 1 };
        indices = CalculateTrisIndices(order, indices);
        tris.AddRange(indices);
        return new Vector3[] { p1, p2, p3, p4 };
    }

    private Vector3[] CreateBelowFace(int order, ref List<int> tris)
    {
        var p1 = new Vector3(-0.5f, -0.5f, -0.5f);
        var p2 = new Vector3(0.5f, -0.5f, -0.5f);
        var p3 = new Vector3(0.5f, -0.5f, 0.5f);
        var p4 = new Vector3(-0.5f, -0.5f, 0.5f);

        var indices = new int[] { 0, 1, 3, 1, 2, 3 };
        indices = CalculateTrisIndices(order, indices);
        tris.AddRange(indices);
        return new Vector3[] { p1, p2, p3, p4 };
    }

    private Vector3[] CreateAboveFace(int order, ref List<int> tris)
    {
        var p1 = new Vector3(-0.5f, 0.5f, -0.5f);
        var p2 = new Vector3(0.5f, 0.5f, -0.5f);
        var p3 = new Vector3(0.5f, 0.5f, 0.5f);
        var p4 = new Vector3(-0.5f, 0.5f, 0.5f);

        var indices = new int[] { 0, 3, 2, 0, 2, 1 };
        indices = CalculateTrisIndices(order, indices);
        tris.AddRange(indices);
        return new Vector3[] { p1, p2, p3, p4 };
    }
}
