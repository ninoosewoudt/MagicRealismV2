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

	[SerializeField]
	private float scrollSpeed = 0.3f;

    private bool firstTouch = true;

    private Material[] materials;
    private int currentSelectedMat;

    void Start ()
    {
        //dit durrde een uur voordat het werkt andere methodes werken niet
        materials = Resources.LoadAll<Material>("PaintMaterials");

        if(materials.Length == 0)
        {
            Debug.LogError("no resources detected!! please make sure you have resources in the map Assets/Resources/PaintMaterials");
        }
                
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
            paint.GetComponent<TextureBall>().changeThisMaterial(materials[currentSelectedMat]);
		}

        checkTouchpad();     
	}

    private void checkTouchpad()
    {
        if (player.rightHand.controller.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchpadAxis = player.rightHand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);

			//print (touchpadAxis);

            if (firstTouch == true)
            {
                axisStartPoint = touchpadAxis;
                firstTouch = false;
            }

			//scroll up
			if (touchpadAxis.y - axisStartPoint.y > scrollSpeed)
            {
                print("scroll up");
                selectMat(1);
                axisStartPoint = touchpadAxis;
            }

			//scroll down
			if (touchpadAxis.y - axisStartPoint.y < -scrollSpeed)
			{
				print("scroll down");
                selectMat(-1);
				axisStartPoint = touchpadAxis;
			}
        }
        else if (firstTouch == false)
        {
            firstTouch = true;
        }
    }

    private void selectMat(int plusOrMin)
    {
        if(currentSelectedMat + plusOrMin > materials.Length - 1)
        {
            currentSelectedMat = 0;
            return;         
        }

        if(currentSelectedMat + plusOrMin < 0)
        {
            currentSelectedMat = materials.Length - 1;
            return;
        }

        currentSelectedMat += plusOrMin;
    }
}
