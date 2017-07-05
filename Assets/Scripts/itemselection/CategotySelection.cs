//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategotySelection : MonoBehaviour
{
    private float lastRotation;

	void Awake ()
    {
        lastRotation = this.gameObject.transform.localRotation.x;
	}

	void FixedUpdate ()
    {
		
	}
}
