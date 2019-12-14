using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStateManager : MonoBehaviour
{
    public levelGenerator levelGenerator;
    public playerMovement playerMovement;
    public scoreManager scoreManager;
    private Vector3 playerSpawnPoint;
    private prefabDeactivate[] prefabDeactivateList;

    // Start is called before the first frame update
    void Start()
    {
        playerSpawnPoint = playerMovement.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame(){
        StartCoroutine("restartGameCR");
    }

    public IEnumerator restartGameCR(){
        playerMovement.gameObject.SetActive(false);
        scoreManager.canScore = false;
        yield return new WaitForSeconds(1f);
        prefabDeactivateList = FindObjectsOfType<prefabDeactivate>();
        for(int i = 0; i < prefabDeactivateList.Length; i++){
            prefabDeactivateList[i].gameObject.SetActive(false);
        }
        playerMovement.transform.position = playerSpawnPoint;
        playerMovement.resetVariables();
        scoreManager.resetScore();
        scoreManager.canScore = true;
        levelGenerator.setNextSpawnPoint(44f);
        playerMovement.gameObject.SetActive(true);
    }
}
