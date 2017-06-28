//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SpawnMenu : MonoBehaviour
{
    private Player player;

    private LineRenderer lineRend;

    [SerializeField]
    private GameObject prullenbak,buis;

    [SerializeField]
    private float lineWith = 0.04f;

    [SerializeField]
    private Color goodColor,badColor;
    private Color currentColor;

    ///voor test
    [SerializeField]
    private GameObject pointer;

    [SerializeField]
    private GameObject hand;
    ///

    void Awake()
    {
        player = Player.instance;
        currentColor = goodColor;

        if(GetComponent<LineRenderer>() == null)
        lineConvig();

        lineRend = GetComponent<LineRenderer>();

        setLineColor();
    }
	
	void Update ()
    {
        ///testLine
        lineRend.SetPosition(0, pointer.gameObject.transform.position - new Vector3(0,0.5f,0));
        lineRend.SetPosition(1, hand.gameObject.transform.position);
        ///


        // als menu knop word ingedrukt
        if (player.leftHand != null && player.leftHand.controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            lineRend.SetPosition(0, player.leftHand.transform.position);
            lineRend.SetPosition(1, player.leftHand.transform.forward * 10);
        }
	}

    private void lineConvig()
    {
        gameObject.AddComponent<LineRenderer>();
        lineRend.endWidth = lineWith;
        lineRend.startWidth = lineWith;
    }

    private void setLineColor()
    {
        lineRend.material.color = currentColor;
    }
}
