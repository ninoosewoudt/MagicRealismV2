using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPainting : MonoBehaviour
{
    [SerializeField]
    private GameObject testobj;
    private Paint painting;
	
	void Start ()
    {
        painting = GetComponent<Paint>();
        painting.changeColor(testobj,new Color(1,0.2f,0,0));
	}
	
	void Update () {
		
	}
}
