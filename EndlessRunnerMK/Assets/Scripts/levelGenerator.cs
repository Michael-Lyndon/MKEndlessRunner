using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    private float nextSpawnPoint = 44f;
	[SerializeField] private List<Transform> levelPrefabList;
    //[SerializeField] private Player player;
    public Transform generationPoint;

	private void Awake(){
		spawnLevelPrefab(levelPrefabList[0], new Vector3 (44,0));
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void spawnLevelPrefab(Transform prefab, Vector3 spawnPosition){
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(generationPoint.position.x > nextSpawnPoint){
            spawnLevelPrefab(levelPrefabList[Random.Range(0,levelPrefabList.Count)], new Vector3(nextSpawnPoint,0)); 
            nextSpawnPoint += 22f;
        }
    }
}
