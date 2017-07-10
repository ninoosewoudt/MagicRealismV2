//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategotySelection : MonoBehaviour
{
    [SerializeField]
    private int toBoigStep = 100;

    private float lastRotation,lastSwitchPoint;

	void Awake ()
    {
        lastSwitchPoint = this.gameObject.transform.localRotation.x;
	}

	void FixedUpdate ()
    {
		
	}
}
