using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public enum Types
{
    CHAIR,
    TABLE
}

public class ObjectBank : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _objects;

    private Dictionary<Types, List<GameObject>> _dictionary;

    private void Awake()
    {
        _objects = new List<GameObject>();
        GameObject go;
        go = OBJLoader.LoadOBJFile(@"C:\Users\vdkui\Downloads\paviljoen-exloo.obj");
        _objects.Add(go);
        Instantiate(go, Vector3.zero, Quaternion.identity);
        //
    }
}
