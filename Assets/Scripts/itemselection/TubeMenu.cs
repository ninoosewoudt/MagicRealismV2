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
    private Dictionary<string, List<GameObject>> GameObjects;
    private List<string> keyList;

    private List<GameObject> spawendObjects = new List<GameObject>();
    
    private Player player;

    private int previousObject,nextObject,objectsCount,categoryCount;

    private CurrentHoldingObjects currentHolding;

    void Start ()
    {
        listSetup();

        player = Player.instance;

        currentHolding = GameObject.Find("Player").GetComponent<CurrentHoldingObjects>();

        newCetagory();
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
        GameObject newobj = Instantiate(GameObjects[keyList[categoryCount]][listNumber],this.transform.position + new Vector3(0, ofset, 0),Quaternion.identity);

        //maak item een trigger
        newobj.GetComponent<Collider>().isTrigger = true;

        // verandert grote
        newobj.gameObject.GetComponent<SizeAdjuster>().instantSizeChange(smalSize);

        newobj.transform.parent = this.gameObject.transform;

        spawendObjects.Add(newobj);

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

        if (nextObject > objectsCount)
        {
            nextObject = 0;
        }
        else if (nextObject < 0)
        {
            nextObject = objectsCount;
        }

        if (previousObject > objectsCount)
        {
            previousObject = 0;
        }
        else if (previousObject < 0)
        {
            previousObject = objectsCount;
        }
    }

    public void moveObjects(float y)
    {
        for (int i = 0; i < spawendObjects.Count; i++)
        {
            spawendObjects[i].transform.position += new Vector3(0, y, 0);
        }
    }

    public void checkObjectPostion()
    {
        if (spawendObjects.Count == 0)
        {
            return;
        }

        for (int i = 0; i < spawendObjects.Count; i++)
        {
            //checkt of object boven een bepaald hoogte zit
            if (spawendObjects[i].transform.position.y > this.transform.position.y + 1)
            {
                Destroy(spawendObjects[i]);
                spawendObjects.Remove(spawendObjects[i]);
                spawnObject(-spaceBetweenObjects, nextObject);
            }

            //checkt of object onder een bepaald hoogte zit
            if (spawendObjects[i].transform.position.y < this.transform.position.y - 1)
            {
                Destroy(spawendObjects[i]);
                spawendObjects.Remove(spawendObjects[i]);
                spawnObject(spaceBetweenObjects, previousObject);
            }
        }
    }

    //check if hand is holding one of the game object
    private void checkIfHolding()
    {
        for (int i = 0; i < spawendObjects.Count; i++)
        {
            if (currentHolding.checkIfAteched(spawendObjects[i]))
            {
                //create clone
                GameObject obj = Instantiate(spawendObjects[i], spawendObjects[i].transform.position, Quaternion.identity);
                obj.GetComponent<SizeAdjuster>().mySize = spawendObjects[i].GetComponent<SizeAdjuster>().mySize;
                obj.transform.parent = this.gameObject.transform;   
                //adjust oldone
                spawendObjects[i].GetComponent<Collider>().isTrigger = false;
                spawendObjects[i].GetComponent<SizeAdjuster>().oldsize();
                
                //replace old with new
                spawendObjects[i] = obj;
            }    
        }
    }

    private void switchCategory(int switchDirection)
    {
        categoryCount += switchDirection;

        if(categoryCount > GameObjects.Count - 1)
        {
            categoryCount = 0;
        }
        else if(categoryCount < 0)
        {
            categoryCount = GameObjects.Count - 1;
        }


        cleanSpawendObjects();
        newCetagory();
    }

    private void newCetagory()
    {
        objectsCount = GameObjects[keyList[categoryCount]].Count - 1;

        nextObject = 0;
        previousObject = objectsCount - 4;

        if(previousObject <= 0)
        {
            previousObject = objectsCount;
        }

        for (int i = 1; i <= 3; i++)
        {
            moveObjects(-spaceBetweenObjects);
            spawnObject(spaceBetweenObjects, nextObject);
        }
    }

    private void cleanSpawendObjects()
    {
        spawendObjects.Clear();
    }

    private void listSetup()
    {
        objects = Resources.LoadAll<GameObject>("interior");

        GameObjects = GameObject.FindObjectOfType<ExternalObjectList>().GameObjects;
        GameObjects["test"] = new List<GameObject>(objects);

        keyList = new List<string>(GameObjects.Keys);

        categoryCount = GameObjects.Count - 1;
    }

}
