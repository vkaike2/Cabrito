using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPuloLadoD : MonoBehaviour {

	public bool encostouDireita = false;

	void OnTriggerEnter2D(Collider2D coll){
		encostouDireita = true;
	}
	void OnTriggerStay2D(Collider2D coll){
		encostouDireita = true;
	}
	void OnTriggerExit2D(Collider2D coll){
		encostouDireita = false;
	}	
}
