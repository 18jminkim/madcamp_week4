using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMaker : MonoBehaviour
{
    public Mesh mesh;
    public MeshCollider meshCol;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponentInChildren<Mesh>();
        meshCol = GetComponent<MeshCollider>();
        if (mesh != null && meshCol != null)
        {
            meshCol.sharedMesh = mesh;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
