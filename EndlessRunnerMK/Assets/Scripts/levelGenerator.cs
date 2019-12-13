using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    private float nextSpawnPoint = 44f;
    public objectPool[] objectPool;
    public Transform generationPoint; //Checks if we are at a position where we need to generate a new platform
    private int prefabSelector;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void placePrefab(GameObject prefab, Vector3 spawnPosition){
        prefab.transform.position = spawnPosition;
        prefab.transform.rotation = transform.rotation;
        prefab.SetActive(true);
        nextSpawnPoint += 22f;
    }

    // Update is called once per frame
    void Update()
    {
        if(generationPoint.position.x > nextSpawnPoint){
            prefabSelector = Random.Range(0, objectPool.Length);
            GameObject randomPrefab = objectPool[prefabSelector].getPooledObject();
            placePrefab(randomPrefab, new Vector3(nextSpawnPoint,0));
        }
    }
}
