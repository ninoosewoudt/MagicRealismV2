//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField]
    private GameObject splash;

    public void spawn(Vector3 spawnPosition, Material mat = null)
    {
        
        if (splash != null)
        {           
            var newSplash = Instantiate(splash, spawnPosition,Quaternion.identity) as GameObject;

            if(mat != null)
            newSplash.GetComponent<ParticleSystemRenderer>().material = mat;

            ParticleSystem particle = newSplash.GetComponent<ParticleSystem>();
            Destroy(newSplash, particle.duration + 0.3f);
        }

        else
            Debug.LogError("no splash assigned");
    }
	
}
