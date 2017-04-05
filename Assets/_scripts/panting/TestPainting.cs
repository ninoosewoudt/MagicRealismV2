using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPainting : MonoBehaviour
{
    [SerializeField]
    private GameObject testobj;
    private Painting painting;
	
	void Start ()
    {
        painting = GetComponent<Painting>();
        painting.changeColor(testobj,new Color(1,0.2f,0,0));
	}
	
	void Update () {
		
	}
}
