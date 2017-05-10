using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class ObjectDestroyer : MonoBehaviour {
	[SerializeField]
	private Player player;
	private LineRenderer linerenderer;
	private Hand hand;




	void Start () {
		player = Player.instance;

	}


	void Update (){
		if (player == null || player.rightHand == null || player.rightHand.controller == null)
			return;
		
		Debug.Log(player.leftHand.currentAttachedObject.gameObject);
		Debug.Log(player.leftHand.currentAttachedObject.name);


		if (player.leftHand.controller.GetPressUp (SteamVR_Controller.ButtonMask.Grip)) {
			




	

		} else {
			return;
		}

	}
}
