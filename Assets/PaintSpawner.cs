using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PaintSpawner : MonoBehaviour {

	private Player player;
	[SerializeField]
	private GameObject PaintPrefab; 
	private GameObject paint;




	void Start () {


		player = Player.instance;

	}


	void Update (){
		if (player == null || player.rightHand == null || player.rightHand.controller == null)
			return;
		if (player.rightHand.controller.GetPressUp (SteamVR_Controller.ButtonMask.ApplicationMenu))
        {			
			paint = Instantiate (PaintPrefab, new Vector3(0,0,0) , Quaternion.identity);
			paint.transform.position = player.rightHand.transform.position;
		}
        else
        {
			return;
		}
	}
}
