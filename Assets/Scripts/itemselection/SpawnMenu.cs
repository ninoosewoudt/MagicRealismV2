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
    private GameObject trashcan,tube,floor;

    [SerializeField]
    private float tubeSpawnHeight = 1;

    [SerializeField]
    private float lineWith = 0.04f;

    [SerializeField]
    private Color goodColor,badColor;

    private bool canSpawn = false;

    ///voor test
    [SerializeField]
    private GameObject pointer;

    [SerializeField]
    private GameObject hand;
    ///

    void Awake()
    {
        player = Player.instance;

        if(GetComponent<LineRenderer>() == null)
        lineConvig();

        lineRend = GetComponent<LineRenderer>();
    }
	
	void Update ()
    {
        ///testLine
        lineRend.SetPosition(0, pointer.gameObject.transform.position - new Vector3(0,0.5f,0));
        lineRend.SetPosition(1, hand.gameObject.transform.position);
        ///


        // als menu knop word ingedrukt
        if (player.leftHand == null)
        {

        }
        else if(player.leftHand.controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            checkFloorHit();
        }
        else if (canSpawn && player.leftHand.controller.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            spawnObjects(checkFloorHit());
        }
	}

    private void lineConvig()
    {
        gameObject.AddComponent<LineRenderer>();
        lineRend.endWidth = lineWith;
        lineRend.startWidth = lineWith;
    }

    private void spawnObjects(Vector3 pos)
    {
        Vector3 rot = player.leftHand.transform.eulerAngles;
        rot = new Vector3(rot.x, rot.y + 180, rot.z);

        Instantiate(trashcan, new Vector3(pos.x -0.2f, 0, pos.z), Quaternion.Euler(rot));

        Instantiate(trashcan, new Vector3(pos.x + 0.2f, tubeSpawnHeight, pos.z), Quaternion.Euler(rot));
    }

    private void drawLine(Color color)
    {
        lineRend.material.color = color;
        lineRend.SetPosition(0, player.leftHand.transform.position);
        lineRend.SetPosition(1, player.leftHand.transform.forward * 10);
    }

    private Vector3 checkFloorHit()
    {
        RaycastHit hit;
        /////////////////////////////////////////////////////of Vector3.forward
        if (Physics.Raycast(player.leftHand.transform.position, -Vector3.up, out hit) && hit.transform.gameObject == floor)
        {
            canSpawn = true;
            drawLine(goodColor);
            return hit.point;
        }

        canSpawn = false;
        drawLine(badColor);
        return Vector3.zero;
    }

    
}
