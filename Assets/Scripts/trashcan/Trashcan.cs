//Brian Boersen
using UnityEngine;
using System.Collections;

public class Trashcan : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(Tags.paintable) || other.CompareTag(Tags.unpaintable))
        {
            print("destroy");
            Detach.fromHand(other.gameObject);
			Destroy(other.gameObject);
	    }
	}

}