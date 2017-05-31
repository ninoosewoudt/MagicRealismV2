using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public static class Detach 
{
    public static void fromHand(GameObject obj)
    {
        Player player = Player.instance;

        for (int i = 0; i <= player.handCount - 1; i++)
        {
            if (player.GetHand(i).currentAttachedObject == obj)
            {
                player.GetHand(i).DetachObject(obj);
            }
        }
    }

    public static void fromParrent(GameObject obj)
    {
        obj.transform.parent = null;
    }
}
