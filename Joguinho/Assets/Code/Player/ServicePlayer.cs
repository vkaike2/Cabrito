using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePlayer : MonoBehaviour {
	private bool estaPulando = false;
	private bool estaPulandoLado = false;

	public void andar (Rigidbody2D rb2d, float VELOCIDADE_ANDAR, Animator liminha)
	{
		float movimentoHorizontal = Input.GetAxisRaw ("Horizontal");
		Vector2 movimenta = new Vector2 (movimentoHorizontal, 0);
		liminha.SetBool("Corre", false);
		
		if (movimentoHorizontal != 0) {
			rb2d.AddForce (movimenta * VELOCIDADE_ANDAR);
			liminha.SetBool("Corre", true);
		}
		
	}

	public void pular (Rigidbody2D rb2d, float ALTURA_PULO, bool estaNoChao)
	{
		float pulo = Input.GetAxisRaw ("Jump");
		if (pulo != 0 && estaNoChao == true) {
			if(estaPulando == false){
				rb2d.AddForce (new Vector2 (0, ALTURA_PULO));
				estaPulando = true;
			}
		}
		if(pulo == 0){
			estaPulando = false;
		}
	}

	public float puloLado(Rigidbody2D rb2d, bool ativador, bool estaNoChao, String lado, float DISTANCIA_PULO_X, float DISTANCIA_PULO_Y){
		float pulo = Input.GetAxisRaw ("Jump");
		float movimentoHorizontal = Input.GetAxisRaw ("Horizontal");

		float multiplicador = 0;
		if(lado == "Direita"){
			multiplicador = -1;
		}else{
			multiplicador = 1;
		}

		if (pulo != 0 && movimentoHorizontal == multiplicador*-1 && ativador == true && estaNoChao == false) {
			if(estaPulandoLado == false){
				rb2d.AddForce (new Vector2 (DISTANCIA_PULO_X*multiplicador, DISTANCIA_PULO_Y));
				estaPulandoLado = true;
			}
		}
		if(pulo == 0){
			estaPulandoLado = false;
		}
		return 0;
	}

}
