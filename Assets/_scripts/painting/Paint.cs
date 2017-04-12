//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public void changeColor(GameObject gameobj,Color color)
    {
        Renderer rend = gameobj.GetComponent<Renderer>();
        rend.material.color = color;
    }

    public void changeMaterial(GameObject gameobj, Material mat)
    {
        Renderer rend = gameobj.GetComponent<Renderer>();
        rend.material = mat;
    }
}
