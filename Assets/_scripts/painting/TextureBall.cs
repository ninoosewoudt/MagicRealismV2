using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TextureBall : MonoBehaviour
{
    private Renderer thisRenderer;
    private Player player;

	void Start ()
    {       
        thisRenderer = GetComponent<Renderer>();
        player = Player.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case Tags.paintable:
                if(this.gameObject.transform.parent != player.leftHand || this.gameObject.transform.parent != player.rightHand)
                changeOtherMaterial(other.gameObject.GetComponent<Renderer>());
                break;

            case Tags.materialButton:
                changeThisMaterial(other.gameObject.GetComponent<Renderer>());
                break;

        }
    }

    private void changeOtherMaterial(Renderer rend)
    {
        rend.material = thisRenderer.material;
        destroyBall();
    }

    private void changeThisMaterial(Renderer rend)
    {
        if (thisRenderer != rend.material)
        thisRenderer.material = rend.material;
    }

    private void destroyBall()
    {
        Destroy(this.gameObject);
    }
}
