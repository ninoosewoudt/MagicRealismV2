//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkOnTouch : MonoBehaviour
{
    [SerializeField]
    private Vector3 shrinkSize = new Vector3(.4f, .4f, .4f);

    private Dictionary<GameObject, Vector3> originalSize = new Dictionary<GameObject, Vector3>();

    private List<GameObject> gameobjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paintable"))
        {
            print("shrink");

            originalSize.Add(other.gameObject, other.gameObject.transform.localScale);

            gameobjects.Add(other.gameObject);

            //other.gameObject.transform.localScale = Vector3.Lerp(other.gameObject.transform.localScale, RealObjectSize.fitInToSize(other.gameObject, shrinkSize), 3);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameobjects.Contains(other.gameObject))
        {
            gameobjects.Remove(other.gameObject);

            other.gameObject.transform.localScale = originalSize[other.gameObject];

            originalSize.Remove(other.gameObject);
        }
    }

    private void Update()
    {
        for(int i = 0; i < gameobjects.Count; i++)
        {
            GameObject currentObject = gameobjects[i];

            if(currentObject == null)
            {
                gameobjects.Remove(currentObject);
                return;
            }

            currentObject.transform.localScale = Vector3.Lerp(currentObject.transform.localScale, RealObjectSize.fitInToSize(currentObject, shrinkSize), 0.6f);
        }
       
    }
}