using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
public float playerSpeed = 5f;
public float playerJump = 5f;
public bool canJump;
public LayerMask findGround;
private Collider2D playerC2D;

private Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerC2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        canJump = Physics2D.IsTouchingLayers(playerC2D, findGround);

        playerRB.velocity = new Vector2(playerSpeed, playerRB.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space)){
            if(canJump){
                playerRB.velocity = new Vector2(playerRB.velocity.x, playerJump);
            }
        }
    }
}
