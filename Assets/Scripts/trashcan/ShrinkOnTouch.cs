//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkOnTouch : MonoBehaviour
{
    [SerializeField]
    private Vector3 newSize = new Vector3(0.5f,0.5f,0.5f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paintable") && other.gameObject.GetComponent<SizeAdjuster>() != null)
        {
            other.gameObject.GetComponent<SizeAdjuster>().changeSize(newSize);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Paintable") && other.gameObject.GetComponent<SizeAdjuster>() != null)
        {
            other.gameObject.GetComponent<SizeAdjuster>().oldsize();
        }
    }

}