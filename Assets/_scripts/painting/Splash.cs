//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField]
    private GameObject splash;
    
    public void spawn(Vector3 spawnPosition)
    {
        
        if (splash != null)
        {           
            var newSplash = Instantiate(splash, spawnPosition,Quaternion.identity) as GameObject;
            Destroy(newSplash, newSplash.GetComponent<ParticleSystem>().duration + 0.3f);
        }

        else
            Debug.LogError("no splash assigned");
    }
	
}
