using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public playerMovement player;
    private Vector3 playerPosition;
    private float moveDistance;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerMovement>();
        playerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveDistance = player.transform.position.x - playerPosition.x;
        transform.position = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);
        playerPosition = player.transform.position;
    }
}
