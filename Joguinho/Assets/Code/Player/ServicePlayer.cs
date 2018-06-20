using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePlayer : MonoBehaviour {
	private bool estaPulandoLado = false;
	public float speed = 50;
	public float jump = 1100;
	private Animator animator;
	private Rigidbody2D body;
	private ControllerPulo controllerPulo;


	void Start(){
		animator = GetComponent<Animator>();		
		body = GetComponent<Rigidbody2D>();
		controllerPulo = GetComponentInChildren<ControllerPulo>();
	}

	void FixedUpdate ()	{
		andar();
		pular();
	}
	public void andar (){
		float move = Input.GetAxisRaw(GameUtils.AXIS_HORIZONTAL);
		float down = Input.GetAxisRaw(GameUtils.AXIS_VERTICAL);
	
		Boolean isStopRun = animator.GetBool(GameUtils.ANIM_PARAM_STOP_RUN);
		Boolean isDown = animator.GetBool(GameUtils.ANIM_PARAM_DOWN);
		Boolean isRun = animator.GetBool(GameUtils.ANIM_PARAM_RUN);

		if(isDown && down >= 0){
			animator.SetBool(GameUtils.ANIM_PARAM_DOWN, false);
		}

		if(down < 0){
			Vector2 movement = new Vector2 (0, 0);
			body.AddForce(movement);
			animator.SetBool(GameUtils.ANIM_PARAM_DOWN, true);
		} else if (move != 0) {
			animator.SetBool(GameUtils.ANIM_PARAM_RUN, true);
			Vector2 movement = new Vector2 (move, 0);
			body.AddForce(movement * speed);
			Vector3 escala = transform.localScale;
			escala.x = move;
			transform.localScale = escala;
		} else if(isRun){
			animator.SetBool(GameUtils.ANIM_PARAM_RUN, false);
		}	
		
	}

	public void pular () {
		float down = Input.GetAxisRaw(GameUtils.AXIS_VERTICAL);
		float pulo = Input.GetAxisRaw(GameUtils.AXIS_JUMP);
		Boolean isJump = animator.GetBool(GameUtils.ANIM_PARAM_JUMP);
		
		if(pulo != 0 && !controllerPulo.isJump() && down == 0){
			Vector2 pular = new Vector2(0, pulo);
			body.AddForce(pular * jump);
			animator.SetBool(GameUtils.ANIM_PARAM_JUMP, true);
		}else if(isJump) {
			animator.SetBool(GameUtils.ANIM_PARAM_JUMP, false);
		}
	}

}
