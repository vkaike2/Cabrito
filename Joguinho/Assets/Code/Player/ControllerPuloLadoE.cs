using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPuloLadoE : MonoBehaviour {

	public bool encostouEsquerda = false;

	void OnTriggerEnter2D(Collider2D coll){
		encostouEsquerda = true;
	}
	void OnTriggerStay2D(Collider2D coll){
		encostouEsquerda = true;
	}
	void OnTriggerExit2D(Collider2D coll){
		encostouEsquerda = false;
	}	
}
