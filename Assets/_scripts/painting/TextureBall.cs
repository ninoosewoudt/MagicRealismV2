using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureBall : MonoBehaviour
{
    private Renderer thisRenderer;

	void Start ()
    {        
        thisRenderer = GetComponent<Renderer>();
        print(thisRenderer);
    }

    void OnCollisionEnter(Collision collision)
    {
        print("werkt");
        switch (collision.gameObject.tag)
        {
            case Tags.paintable:
                changeOtherMaterial(collision.gameObject.GetComponent<Renderer>());
                break;

            case Tags.materialButton:
                changeThisMaterial(collision.gameObject.GetComponent<Renderer>());
                break;
        }
    }

    private void changeOtherMaterial(Renderer rend)
    {
        rend.material = thisRenderer.material;
        Destroy(this.gameObject);
    }

    private void changeThisMaterial(Renderer rend)
    {
        if (thisRenderer != rend.material)
        thisRenderer.material = rend.material;
    }
}
