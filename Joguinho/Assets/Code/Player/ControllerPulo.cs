using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPulo : MonoBehaviour {

	public bool estaNoChao = false;

	void OnTriggerEnter2D(Collider2D coll){
		Debug.Log("Enter");
	}
	void OnTriggerStay2D(Collider2D coll){
		Debug.Log("Stay");
		estaNoChao = true;
	}
	void OnTriggerExit2D(Collider2D coll){
		Debug.Log("Exit");
		estaNoChao = false;
	}	

}
