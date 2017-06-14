//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class CurrentHoldingObjects : MonoBehaviour
{
    private Player player;

	// Use this for initialization
	void Start ()
    {
        player = Player.instance;
	}
	
	public bool checkIfAteched(GameObject obj)
    {
        bool atached = false;

        for (int i = 0; i < player.handCount; i++)
        {
            if(obj == player.GetHand(i).currentAttachedObject)
            {
                atached = true;
            }  
        }

        return atached;
    }
}
