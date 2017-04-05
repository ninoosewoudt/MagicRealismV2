using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    /*    SteamVR_TrackedController[] TrackedControllers;

        void Start()
        {
            TrackedControllers = FindObjectsOfType<SteamVR_TrackedController>();
            foreach(var c in TrackedControllers)
            {
                Debug.Log(c.transform.name);
            }
        }
        */

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
