using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureBall : MonoBehaviour
{
    private Renderer thisRenderer;

	void Start ()
    {        
        thisRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case Tags.paintable:
                changeOtherMaterial(other.gameObject.GetComponent<Renderer>());
                break;

            case Tags.materialButton:
                changeThisMaterial(other.gameObject.GetComponent<Renderer>());
                break;

            case Tags.untagged:
                destroyBall();
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
