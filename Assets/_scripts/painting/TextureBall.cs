//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TextureBall : MonoBehaviour
{
    private Renderer thisRenderer;
    private Player player; 

    private GameObject gameManager;
    private Splash splash;

	void Awake()
    {
        thisRenderer = GetComponent<Renderer>();
        player = Player.instance;

        gameManager = GameObject.FindGameObjectWithTag(Tags.gamemanager);

        if(gameManager != null)
        {
            splash = gameManager.GetComponent<Splash>();
        }
        else
        {
            Debug.LogError("no splash script");
        }       
    }

    void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
		    case Tags.paintable:
                changeOtherMaterial(other.gameObject.GetComponent<Renderer>());
            break;

            case Tags.materialButton:
                //changeThisMaterial(other.gameObject.GetComponent<Renderer>());
            break;
        }
    }

    private void changeOtherMaterial(Renderer rend)
    {
        for(int i = 0; i <= player.handCount -1; i++)
        {
            if (player.GetHand(i).currentAttachedObject == this.gameObject)
            {
                player.GetHand(i).DetachObject(this.gameObject);
            }
        }

        splash.spawn(this.transform.position);
        rend.material = thisRenderer.material;
        destroyBall();
    }

    public void changeThisMaterial(Material mat)
    {
        thisRenderer.material = mat;
    }

    private void destroyBall()
    {
        Destroy(this.gameObject);
    }
}
