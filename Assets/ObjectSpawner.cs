//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ObjectSpawner : MonoBehaviour
{
    private Player player;

    private Vector2 axisStartPoint;
    private Vector2 touchpadAxis;

    [SerializeField]
    private float scrollSpeed = 0.3f;

    private bool firstTouch = true;

    private GameObject[] objects;
    private int currentSelectedObj;

    void Start()
    {
        //dit durrde een uur voordat het werkt andere methodes werken niet
        objects = Resources.LoadAll<GameObject>("interior");

        if (objects.Length == 0)
        {
            Debug.LogError("no resources detected!! please make sure you have resources in the map Assets/Resources/interior");
        }

        player = Player.instance;
    }

    void Update()
    {
        if (player == null || player.leftHand == null || player.leftHand.controller == null)
            return;

        if (player.leftHand.controller.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            GameObject newGameObject = Instantiate(objects[currentSelectedObj], new Vector3(0, 0, 0), Quaternion.identity);
            newGameObject.transform.position = player.leftHand.transform.position;
        }

        checkTouchpad();
    }

    private void checkTouchpad()
    {
        if (player.leftHand.controller.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchpadAxis = player.leftHand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);

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
        currentSelectedObj += plusOrMin;

        if (currentSelectedObj > objects.Length - 1)
        {
            currentSelectedObj = 0;
        }

        if (currentSelectedObj < 0)
        {
            currentSelectedObj = objects.Length - 1;
        }
    }
}
