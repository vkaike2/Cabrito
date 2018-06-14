using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePlayer : MonoBehaviour {
	private bool estaPulando = false;
	private bool estaPulandoLado = false;
	public float speed = 50;
	public float jump = 3;
	private Animator animator;
	private Rigidbody2D body;


	void Start(){
		animator = GetComponent<Animator>();		
		body = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()	{
		andar();
	}
	public void andar (){
		float move = Input.GetAxisRaw(GameUtils.AXIS_HORIZONTAL);
		Boolean isStopRun = animator.GetBool(GameUtils.ANIM_STOP_RUN);
		Boolean isRun = animator.GetBool(GameUtils.ANIM_RUN);
		/*Tem que refinar para quando o personagem muda de direção 
			não tocar a animação de isStopRun
		*/
		if (move != 0 && !isStopRun) {
			animator.SetBool(GameUtils.ANIM_RUN, true);
			Vector2 movement = new Vector2 (move, 0);
			body.AddForce(movement * speed);
			Vector3 escala = transform.localScale;
			escala.x = move;
			transform.localScale = escala;
		} else if(isStopRun){
			Debug.Log("parando de vez");	
			animator.SetBool(GameUtils.ANIM_STOP_RUN, false);
		} else if(isRun){
			Debug.Log("inicio da parada");	
			animator.SetBool(GameUtils.ANIM_STOP_RUN, true);
			animator.SetBool(GameUtils.ANIM_RUN, false);
		}	
		
	}

	public void pular () {
		float pulo = Input.GetAxisRaw (GameUtils.AXIS_JUMP);
		
		// if (pulo != 0 && estaNoChao == true) {
		// 	if(estaPulando == false){
		// 		body.AddForce (new Vector2 (0, jump));
		// 		estaPulando = true;
		// 	}
		// }

		// if(pulo == 0){
		// 	estaPulando = false;
		// }
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
