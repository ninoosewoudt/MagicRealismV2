using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TextureBall : MonoBehaviour
{
    private Renderer thisRenderer;
    private Player player;
	private GameObject hand1;
	private GameObject hand2;

	void Awake(){
		hand1 = GameObject.Find ("hand1");
		hand2 = GameObject.Find ("hand2");
	}
	void Start ()
    {       
        thisRenderer = GetComponent<Renderer>();
        player = Player.instance;
    }

    void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
		case Tags.paintable:
			
			if (this.gameObject.transform.parent == hand1 || this.gameObject.transform.parent == hand2 ) {
				changeOtherMaterial (other.gameObject.GetComponent<Renderer> ());

			} else {
				player.leftHand.DetachObject (this.gameObject);
				player.rightHand.DetachObject (this.gameObject);
				return;
			}
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
