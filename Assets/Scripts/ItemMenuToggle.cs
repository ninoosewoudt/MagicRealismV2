using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ItemMenuToggle : MonoBehaviour {

	private Player player;
	[SerializeField]
	private GameObject itemMenuPrefab; 
	[SerializeField]
	private GameObject itemMenuItemPrefab;
	private GameObject itemMenu;
	private bool menuEnabled; 

	private bool init;

	public List<GameObject> Objects;

	void Start () {
		//Objects = new List<GameObject> ();

		itemMenu = Instantiate (itemMenuPrefab);

		for (int y = 0; y < 1; y++) {
			for (int x = 0; x < 2; x++) {
				var ypos = y * 10;
				var xpos = x * 10;
				var item = Instantiate (itemMenuItemPrefab);
				item.transform.SetParent (itemMenu.transform,false);	
				item.transform.position = new Vector3(xpos,ypos);
				item.GetComponent<ItemMenuItem>().Item = Objects[y+x];
			}
		}

		Objects.ForEach ((go) => {
			

		});

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
				itemMenu.transform.SetParent (player.leftHand.transform,false);
				itemMenu.transform.position += new Vector3(0,+0.4f,+0.4f);
				//itemMenu.transform.rotation = player.leftHand.transform.rotation;

				init = false;
			}

			menuEnabled = !menuEnabled;
			itemMenu.SetActive (menuEnabled);
		} else {
			return;
		}
	}
}
