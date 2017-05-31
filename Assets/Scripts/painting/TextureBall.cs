//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureBall : MonoBehaviour
{
    private Renderer thisRenderer;

    private GameObject gameManager;
    private Splash splash;

	void Awake()
    {
        thisRenderer = GetComponent<Renderer>();

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
        if (other.gameObject.tag == Tags.paintable || other.gameObject.tag == Tags.wall)
        {
            changeOtherMaterial(other.gameObject.GetComponent<Renderer>());
        }
    }

    private void changeOtherMaterial(Renderer rend)
    {
      
        rend.material = thisRenderer.material;
        destroyBall();
    }

    public void changeThisMaterial(Material mat)
    {
        thisRenderer.material = mat;
    }

    private void destroyBall()
    {
        splash.spawn(this.transform.position, thisRenderer.material);

        Detach.fromHand(this.gameObject);

        Destroy(this.gameObject);
    }
}
