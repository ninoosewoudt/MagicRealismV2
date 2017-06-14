//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TubeMenu : MonoBehaviour
{
    [SerializeField]
    private float spaceBetweenObjects = 0.5f;

    [SerializeField]
    private Vector3 smalSize = new Vector3(0.5f, 0.5f, 0.5f);

    private GameObject[] objects;
    private List<GameObject> spawendObject = new List<GameObject>();
    private Player player;

    private int previousObject,nextObject,objectsCount;

    private CurrentHoldingObjects currentHolding;

    void Start ()
    {
        objects = Resources.LoadAll<GameObject>("interior");

        if (objects.Length == 0)
        {
            Debug.LogError("no resources detected!! please make sure you have resources in the map Assets/Resources/interior");
        }

        player = Player.instance;

        currentHolding = GameObject.Find("Player").GetComponent<CurrentHoldingObjects>();

        objectsCount = objects.Length - 1;

        previousObject = objects.Length - 4;

        for (int i = 1; i <= 3; i++)
        {
            moveObjects(-spaceBetweenObjects);
            spawnObject(spaceBetweenObjects, nextObject);           
        }
    }
	
	void Update()
    {
        checkObjectPostion();
        checkIfHolding();

        //scroll test
        //moveObjects(-0.25f * Time.deltaTime);
	}

    public void spawnObject(float ofset, int listNumber)
    {
        //spawn item
        GameObject newobj = Instantiate(objects[listNumber],this.transform.position + new Vector3(0, ofset, 0),Quaternion.identity);

        //maak item een trigger
        newobj.GetComponent<Collider>().isTrigger = true;

        // verandert grote
        newobj.gameObject.GetComponent<SizeAdjuster>().instantSizeChange(smalSize);

        spawendObject.Add(newobj);

        if(ofset > 0)
        {
            changeListPosition(+1);
        }
        else
        {
            changeListPosition(-1);
        }
    }

    private void changeListPosition(int changeStep)
    {
        nextObject += changeStep;
        previousObject += changeStep;

        if (nextObject > objectsCount - 1)
        {
            nextObject = 0;
        }
        else if (nextObject < 0)
        {
            nextObject = objectsCount - 1;
        }

        if (previousObject > objectsCount - 1)
        {
            previousObject = 0;
        }
        else if (previousObject < 0)
        {
            previousObject = objectsCount - 1;
        }
    }

    public void moveObjects(float y)
    {
        for (int i = 0; i < spawendObject.Count; i++)
        {
            spawendObject[i].transform.position += new Vector3(0, y, 0);
        }
    }

    public void checkObjectPostion()
    {
        if (spawendObject.Count == 0)
        {
            return;
        }

        for (int i = 0; i < spawendObject.Count; i++)
        {
            //checkt of object boven een bepaald hoogte zit
            if (spawendObject[i].transform.position.y > this.transform.position.y + 1)
            {
                Destroy(spawendObject[i]);
                spawendObject.Remove(spawendObject[i]);
                spawnObject(-spaceBetweenObjects, nextObject);
            }

            //checkt of object onder een bepaald hoogte zit
            if (spawendObject[i].transform.position.y < this.transform.position.y - 1)
            {
                Destroy(spawendObject[i]);
                spawendObject.Remove(spawendObject[i]);
                spawnObject(spaceBetweenObjects, previousObject);
            }
        }
    }

    //check if hand is holding one of the game object
    private void checkIfHolding()
    {
        for (int i = 0; i < spawendObject.Count; i++)
        {
            if (currentHolding.checkIfAteched(spawendObject[i]))
            {
                //create clone
                GameObject obj = Instantiate(spawendObject[i], spawendObject[i].transform.position, Quaternion.identity);
                obj.GetComponent<SizeAdjuster>().mySize = spawendObject[i].GetComponent<SizeAdjuster>().mySize;

                //adjust oldone
                spawendObject[i].GetComponent<Collider>().isTrigger = false;
                spawendObject[i].GetComponent<SizeAdjuster>().oldsize();
                
                //replace old with new
                spawendObject[i] = obj;
            }    
        }
    }

}
