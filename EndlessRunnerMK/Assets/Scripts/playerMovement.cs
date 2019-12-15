using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
public float playerSpeed;
private float playerSpeedReset; 
public float playerSpeedModifier;
public float distanceIncrease;
private float distanceIncreaseReset;
private float distanceIncreaseCount;
private float distanceIncreaseCountReset;
public float playerJump;
public float jumpMaxDuration;
private float jumpDurationCount;
public bool canJump;
public LayerMask findGround;
public Transform findGroundPoint;
public float findGroundRadius;
public gameStateManager gameStateManager;

private Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        jumpDurationCount = jumpMaxDuration;
        playerSpeedReset = playerSpeed;
        distanceIncreaseCountReset = distanceIncreaseCount;
        distanceIncreaseReset = distanceIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        canJump = Physics2D.OverlapCircle(findGroundPoint.position, findGroundRadius, findGround); 
        if(transform.position.x > distanceIncreaseCount){ //Speed Increase
            distanceIncreaseCount += distanceIncrease;
            distanceIncrease = distanceIncrease * playerSpeedModifier;
            playerSpeed = playerSpeed * playerSpeedModifier;
        }

        playerRB.velocity = new Vector2(playerSpeed, playerRB.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space)){
            if(canJump){
                playerRB.velocity = new Vector2(playerRB.velocity.x, playerJump);
            }
        }

        if(Input.GetKey(KeyCode.Space)){
            if(jumpDurationCount > 0){
                playerRB.velocity = new Vector2(playerRB.velocity.x, playerJump);
                jumpDurationCount-= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            jumpDurationCount = 0;
        }

        if(canJump){
            jumpDurationCount = jumpMaxDuration;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "lossCondition"){
            gameStateManager.gameLoss();
        }
    }

    public void resetVariables(){
        playerSpeed = playerSpeedReset;
        distanceIncreaseCount = distanceIncreaseCountReset;
        distanceIncrease = distanceIncreaseReset;
    }
}
