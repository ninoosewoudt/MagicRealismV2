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

    private float lastY;

	[SerializeField]
	private float scrollSpeedMultiplier = 1.3f;


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
		if (player.leftHand == null && player.rightHand == null)
			return;
		
            if (player.leftHand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
				print ("grip");
                if (!gripped)
                {
                    gripedHand = player.leftHand;
                    lastY = gripedHand.transform.position.y;
                    gripped = true;                  
                }
                return;
            }
			
            if (player.rightHand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                if (!gripped)
                {
                    gripedHand = player.rightHand;
                    lastY = gripedHand.transform.position.y;
                    gripped = true;
                }               
                return;
            }

		if (player.leftHand.controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
		{
			gripped = false;
			return;
		}

		if (player.rightHand.controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
		{
			gripped = false;
			return;
		}
    }

    private void scrollWithController()
    {
        float newY = gripedHand.transform.position.y;
		tubeMenu.moveObjects((newY - lastY) * scrollSpeedMultiplier);
        lastY = newY;
        
    }


}
