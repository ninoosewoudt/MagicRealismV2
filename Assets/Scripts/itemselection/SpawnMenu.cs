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

    private GameObject menu, oldMenu;

    [SerializeField]
    private float tubeSpawnHeight = 2;

    [SerializeField]
    private float lineWith = 0.04f;

    [SerializeField]
    private Color goodColor,badColor;

	private bool canSpawn = false,pressed = false;

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
        /*
        ///testLine
        lineRend.SetPosition(0, pointer.gameObject.transform.position - new Vector3(0,0.5f,0));
        lineRend.SetPosition(1, hand.gameObject.transform.position);
        ///
		*/


        // als menu knop word ingedrukt
        if (player.leftHand == null)
        {

        }
        else if(player.leftHand.controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
        	lineRend.enabled = true;
			pressed = true;
        }
        else if (player.leftHand.controller.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
        	lineRend.enabled = false;
        	
        	if(canSpawn)
        	{
        		pressed = false;
            	spawnObjects(checkFloorHit());
        	}
			
        }

		if(pressed)
		{
			checkFloorHit ();	
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
        Destroy(oldMenu);

        Vector3 rot = player.leftHand.transform.eulerAngles;
        rot = new Vector3(0,rot.y + 180, 0);

        GameObject newMenu = Instantiate(menu, new Vector3(pos.x, 0, pos.z), Quaternion.identity);

        GameObject newTrah = Instantiate(trashcan, new Vector3(pos.x -0.4f, 0, pos.z), Quaternion.identity);

        GameObject newTube = Instantiate(tube, new Vector3(pos.x + 0.4f, tubeSpawnHeight, pos.z), Quaternion.identity);

        newTrah.transform.parent = newMenu.transform;
        newTube.transform.parent = newMenu.transform;

        newMenu.transform.localRotation = Quaternion.Euler(rot);

        oldMenu = newMenu;
    }

    private void drawLine(Color color)
    {
        lineRend.material.color = color;
        lineRend.SetPosition(0, player.leftHand.transform.position);
        lineRend.SetPosition(1, player.leftHand.transform.forward * 20);
    }

    private Vector3 checkFloorHit()
    {
        RaycastHit hit;
        
        Debug.DrawLine (player.leftHand.transform.position, player.leftHand.transform.forward*20 ,Color.red);
        /////////////////////////////////////////////////////of Vector3.forward
        if (Physics.Raycast(player.leftHand.transform.position, player.leftHand.transform.forward, out hit))
        {
			print (hit.transform.gameObject.name);
        	if(hit.transform.gameObject.name == floor.name)
        	{	
        		canSpawn = true;
            	drawLine(goodColor);
            	return hit.point;
        	}       
        }

        canSpawn = false;
        drawLine(badColor);
        return Vector3.zero;
    }

    
}
