using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class ObjectDestroyer : MonoBehaviour {
	[SerializeField]
	private Player player;
	private Hand hand;

	private GameObject cur;

	void Start () 
	{
		player = Player.instance;
	}


	void Update ()
	{
		if (player == null || player.rightHand == null || player.rightHand.controller == null)
			return;

		if(cur == null)
		{
			cur = player.rightHand.currentAttachedObject;
		}

		if (player.rightHand.controller.GetPressUp (SteamVR_Controller.ButtonMask.Grip)) 
		{
			if (player.rightHand.currentAttachedObject == cur)
				return;

			var obj = player.rightHand.currentAttachedObject;
			player.rightHand.DetachObject (player.rightHand.currentAttachedObject);
			Destroy (obj);


		} else 
		{
			return;
		}

	}
}
