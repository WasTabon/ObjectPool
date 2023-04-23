using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{ 
    private T _prefab;
    private bool _autoExpand;
    private Transform _container;

    private List<T> _pool;

    public PoolMono(T prefab, bool autoExpand, Transform container)
    {
        _prefab = prefab;
        _autoExpand = autoExpand;
        _container = container;
        _pool = new List<T>();
    }

    public void CreatePool(int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = GameObject.Instantiate(_prefab, _container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T freeElement)
    {
        foreach (var mono in _pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                freeElement = mono;
                freeElement.gameObject.SetActive(true);
                return true;
            }
        }
        freeElement = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out T freeElement))
            return freeElement;

        if (_autoExpand)
            return CreateObject();

        throw new Exception("There is no free elements in pool");
    }
}


