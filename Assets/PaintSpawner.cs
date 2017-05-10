//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PaintSpawner : MonoBehaviour
{
	private Player player;

	[SerializeField]
	private GameObject PaintPrefab; 
	private GameObject paint;

    private Vector2 axisStartPoint;
    private Vector2 touchpadAxis;

    private bool firstTouch = true;

    void Start ()
    {
		player = Player.instance;
	}

	void Update ()
    {
		if (player == null || player.rightHand == null || player.rightHand.controller == null)
			return;

		if (player.rightHand.controller.GetPressUp (SteamVR_Controller.ButtonMask.ApplicationMenu))
        {			
			paint = Instantiate (PaintPrefab, new Vector3(0,0,0) , Quaternion.identity);
			paint.transform.position = player.rightHand.transform.position;
		}

        checkTouchpad();     
	}

    private void checkTouchpad()
    {
        if (player.rightHand.controller.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchpadAxis = player.rightHand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
            print(touchpadAxis);

            if (firstTouch == true)
            {
                axisStartPoint = touchpadAxis;
                firstTouch = false;
            }

            if (Mathf.Abs(touchpadAxis.x - axisStartPoint.x) > 0.3)
            {
                print("scroll");
            }
        }
        else if (firstTouch == false)
        {
            firstTouch = true;
        }
    }
}
