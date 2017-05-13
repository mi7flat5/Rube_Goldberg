using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
  
    public List<GameObject> objectList;             // handled automatically at start
    public List<GameObject> objectPrefabList;      // set automatically in inspector and MUST match order of scene menu objects

    public int currentObject;                  // current selection index number

    void Start()
    {

        foreach (Transform child in transform)
        {
            objectList.Add(child.gameObject);
        }
      

    }

    public void MenuLeft()
    {
        objectList[currentObject].SetActive(false);
        currentObject--;
        if (currentObject < 0)
        {
            currentObject = objectList.Count - 1;
        }
        objectList[currentObject].SetActive(true);
    }

    public void MenuRight()
    {
        objectList[currentObject].SetActive(false);
        currentObject++;
        if (currentObject > objectList.Count - 1)
        {
            currentObject = 0;
        }
        objectList[currentObject].SetActive(true);
    }

    public void SpawnCurrentObject()
    {

        if ((objectList[currentObject].name == "ObjectDestroyer"))
            return;
        if (objectPrefabList[currentObject].name == "ConveyorObject")
            Instantiate(objectPrefabList[currentObject], transform.position, Quaternion.Euler( transform.rotation.x,transform.rotation.y,90));
        else  Instantiate(objectPrefabList[currentObject],transform.position, transform.rotation);
        
        objectList[currentObject].SetActive(false);
        currentObject = 0;
    }

    void Update()
    {

    }
   public bool bDestroyObject()
    {
        if (objectList[currentObject].name == "ObjectDestroyer")
            return true;
        else return false;
    }
}
