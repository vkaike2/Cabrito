using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPulo : MonoBehaviour {

	public bool estaNoChao = false;

	void OnTriggerEnter2D(Collider2D coll){
	}
	void OnTriggerStay2D(Collider2D coll){
		estaNoChao = true;
	}
	void OnTriggerExit2D(Collider2D coll){
		estaNoChao = false;
	}	

}
