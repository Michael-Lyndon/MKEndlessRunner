using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
    public GameObject pooledObject;

    public int pooledQuantity;

    List<GameObject> objectPoolList;
    
    // Start is called before the first frame update
    void Start()
    {
        objectPoolList = new List<GameObject>();

        for(int i = 0; i < pooledQuantity; i++){
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            objectPoolList.Add(obj);
        }
    }

    public GameObject getPooledObject(){
        for(int i = 0; i < objectPoolList.Count; i++){
            if(!objectPoolList[i].activeInHierarchy){
                return objectPoolList[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        objectPoolList.Add(obj);
        return objectPoolList[objectPoolList.Count-1];
    }
}
