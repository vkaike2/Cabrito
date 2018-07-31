using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPuloCollider : MonoBehaviour {

	public bool estaPulando = false;
	private string objAnterior = "";
	private string objAtual = "";

	void OnTriggerEnter2D(Collider2D coll){
		objAtual = coll.gameObject.tag;
		estaPulando = false;
	}
	void OnTriggerStay2D(Collider2D coll){
		estaPulando = false;
	}
	void OnTriggerExit2D(Collider2D coll){
		if(objAnterior != objAtual){
			estaPulando = true;
		}
		objAnterior = coll.gameObject.tag;
	}	

	public bool isJump(){
		return this.estaPulando;
	}
}
