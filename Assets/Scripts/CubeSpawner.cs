using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;

    private PoolMono<Cube> _pool;

    private void Start()
    {
        _pool = new PoolMono<Cube>(_prefab, _autoExpand, _container);
        _pool.CreatePool(_capacity);
    }

    private void Update()
    {
        SetCubePos();
    }

    private void SetCubePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateCube();
        }
    }

    private void CreateCube()
    {
        float x = Random.Range(-5f, 5f);
        float z = Random.Range(-5f, 5f);

        Vector3 position = new Vector3(x, 0, z);

        var cube = _pool.GetFreeElement();
        cube.transform.position = position;
    }
    
}
