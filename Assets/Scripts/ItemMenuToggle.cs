using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ItemMenuToggle : MonoBehaviour {

	private Player player;
	[SerializeField]
	private GameObject itemMenuPrefab; 
	private GameObject itemMenu;
	private bool menuEnabled; 

	private bool init;

	void Start () {

		itemMenu = Instantiate (itemMenuPrefab);


		Debug.Log (FindObjectsOfType<ItemMenuToggle> ().Length);

		init = true;

		player = Player.instance;
		menuEnabled = true;
	}


	void Update ()
    {
		if (player == null || player.leftHand == null || player.leftHand.controller == null)
			return;
		if (player.leftHand.controller.GetPressUp (SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			if (init) {
				itemMenu.transform.parent = player.leftHand.transform;
				itemMenu.transform.position = player.leftHand.transform.position + new Vector3(0,+0.4f,+0.4f);
				itemMenu.transform.rotation = player.leftHand.transform.rotation;

				init = false;
			}

			menuEnabled = !menuEnabled;
			itemMenu.SetActive (menuEnabled);
		} else {
			return;
		}
	}
}
