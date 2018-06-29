using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

	private Animator anim;

	public PlayerAnimator(GameObject gameObj){
		this.anim = gameObj.GetComponent<Animator>();
	}

	public bool getRun(){
		return anim.GetBool("run");
	}
	public void setRun(bool run){
		anim.SetBool("run",run);
	}

	public bool getJump(){
		return anim.GetBool("jump");
	}

	public void setJump(bool jump){
		anim.SetBool("jump",jump);
	}

	public bool getStopRuning(){
		return anim.GetBool("stop_running");
	}
	public void setStopRuning(bool stopRuning){
		anim.SetBool("run",stopRuning);
	}
}
