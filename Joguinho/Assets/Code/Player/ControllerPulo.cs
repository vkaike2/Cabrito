using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPulo : MonoBehaviour {

	public bool isJumping = false;
	private Collider2D jumpCollider;

	void OnTriggerEnter2D(Collider2D coll){
		isJumping = false;
	}
	void OnTriggerStay2D(Collider2D coll){
		// isJumping = false;
	}
	void OnTriggerExit2D(Collider2D coll){
		isJumping = true;
	}	

	public bool isJump(){
		return this.isJumping;
	}
}
