//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TubeMenu : MonoBehaviour
{
    private GameObject[] objects;
    private List<GameObject> spawendObject = new List<GameObject>();
    private Player player;

    private int previousObject, nextObject,objectsCount;

    void Start ()
    {
        objects = Resources.LoadAll<GameObject>("interior");

        if (objects.Length == 0)
        {
            Debug.LogError("no resources detected!! please make sure you have resources in the map Assets/Resources/interior");
        }

        player = Player.instance;

    }
	
	void Update ()
    {
		
	}

    public void spawnAboveObject()
    {
        Instantiate(objects[nextObject]);

        changeListPosition(+1);
    }

    private void changeListPosition(int changeStep)
    {
        if (nextObject >= objectsCount - 1)
        {
            nextObject = 0;
        }
        else if (nextObject <= 0)
        {
            nextObject = objectsCount - 1;
        }
        else
        {
            nextObject += changeStep;
        }

        if (previousObject >= objectsCount - 1)
        {
            previousObject = 0;
        }
        else if (previousObject <= 0)
        {
            previousObject = objectsCount - 1;
        }
        else
        {
            previousObject += changeStep;
        }
    }

    public void spawnUnderObject()
    {
        Instantiate(objects[previousObject]);

        changeListPosition(-1);
    }

    public void moveObjects(float y)
    {
       
    }

    public void checkObjectPostion()
    {

        if (spawendObject[spawendObject.Count - 1].transform.position.y > 3)
        {

        }

        //checkt of object onder een bepaald hoogte zit
        // vervang "0" met de juste hoogte/laagte
        if (spawendObject[0].transform.position.y < 0)
        {
            
        }      
    }

}
