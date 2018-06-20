using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OneWayPlatform : MonoBehaviour
{

    private PlatformEffector2D effector;
    private float waitTime;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        effector = GetComponent<PlatformEffector2D>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        float down = Input.GetAxisRaw(GameUtils.AXIS_VERTICAL);
        float jump = Input.GetAxisRaw(GameUtils.AXIS_JUMP);

        if (down < 0 ) {
            if(waitTime <= 0){
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }else{
                waitTime -= Time.deltaTime;
            }
        }else if(waitTime != 0.5f){
            waitTime = 0.5f;
            effector.rotationalOffset = 0f;
        }  
    }

}