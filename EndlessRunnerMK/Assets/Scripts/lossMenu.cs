using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lossMenu : MonoBehaviour
{
    public void restartGame(){
        FindObjectOfType<gameStateManager>().reset();
    }

}
