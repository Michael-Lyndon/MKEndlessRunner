using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabDeactivate : MonoBehaviour
{

    public GameObject prefabDeactivationPoint;
    // Start is called before the first frame update
    void Start()
    {
        prefabDeactivationPoint = GameObject.Find("deactivatePoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(prefabDeactivationPoint.transform.position.x > transform.position.x){
            gameObject.SetActive(false);
            Debug.Log("Deavtiate");
        }
    }
}
