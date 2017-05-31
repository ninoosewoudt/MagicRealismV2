using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketcount : MonoBehaviour {

	public TextMesh text;
	private int count = 0;

	// Use this for initialization
	void Start () {
		UpdateText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		count++;
		UpdateText ();
	}

	void UpdateText(){
		text.text = count.ToString ();
	}
}
