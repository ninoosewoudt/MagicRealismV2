//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Scroll : MonoBehaviour
{
    private Player player;
    private Hand gripedHand;

    private TubeMenu tubeMenu;

    private bool gripped = false;


	void Start ()
    {
        player = Player.instance;
        tubeMenu = GetComponent<TubeMenu>();
	}
	
	void FixedUpdate ()
    {
        checkGriped();

        if (gripped)
        {
            scrollWithController();
        }
	}

    private void checkGriped()
    {
        if(player.leftHand != null)
        if (player.leftHand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            gripedHand = player.leftHand;
            gripped = true;
            return;
        }

        if (player.rightHand != null)
        if (player.rightHand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            gripedHand = player.rightHand;
            gripped = true;
            return;
        }

        gripped = false;
    }

    private void scrollWithController()
    {

    }


}
