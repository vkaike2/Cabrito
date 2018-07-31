using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaService : MonoBehaviour{

    private PlatformEffector2D effector;

    public PlataformaService(GameObject gameObj){
        this.effector = gameObj.GetComponent<PlatformEffector2D>();
    }

    public void descer(){
        float movVertical = Input.GetAxisRaw(GameUtils.AXIS_VERTICAL);
        float movJump = Input.GetAxisRaw(GameUtils.AXIS_JUMP);

        if(movVertical == -1){
            effector.rotationalOffset = 180f;
        }

        if(movJump == 1){
            effector.rotationalOffset = 0;
        }
    }

}