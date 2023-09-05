using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    private MeshFilter _meshFilter;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        Vector3[] vertices = _meshFilter.mesh.vertices;
        
        for(int i = 0; i < vertices.Length; i++)
        {
            var position = transform.position;
            vertices[i].y = WaveManager.instance.GetWaveHeight(position.x + vertices[i].x, position.z + vertices[i].z);
        }

        _meshFilter.mesh.vertices = vertices;
        _meshFilter.mesh.RecalculateNormals();
    }
    
}
