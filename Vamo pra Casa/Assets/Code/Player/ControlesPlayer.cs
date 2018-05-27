﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesPlayer : MonoBehaviour
{

	public float VELOCIDADE_ANDAR;
	public float ALTURA_PULO;
	public float DISTANCIA_PULO_X;
	public float DISTANCIA_PULO_Y;
	private Rigidbody2D rb2d;
    private float cdwPulo;
	private ServicePlayer servicePlayer;
	private ControllerPulo controllerPulo;
	private ControllerPuloLadoE controllerPuloLadoE;
	private ControllerPuloLadoD controllerPuloLadoD;
	
	void Start ()
	{
		servicePlayer = GetComponent<ServicePlayer>();
		controllerPulo = GameObject.Find("pulo").GetComponent<ControllerPulo> ();
		controllerPuloLadoE = GameObject.Find("puloLado_E").GetComponent<ControllerPuloLadoE> ();
		controllerPuloLadoD = GameObject.Find("puloLado_D").GetComponent<ControllerPuloLadoD> ();

		rb2d = GetComponent<Rigidbody2D> ();
		cdwPulo = 0;
	}

	void FixedUpdate ()
	{
		servicePlayer.andar(rb2d,VELOCIDADE_ANDAR);
		servicePlayer.pular(rb2d,ALTURA_PULO,controllerPulo.estaNoChao);

		if(controllerPulo.estaNoChao == false){
			cdwPulo = cdwPulo + Time.deltaTime;
			if(cdwPulo >= 0.2f){
				cdwPulo = servicePlayer.puloLado(rb2d,controllerPuloLadoE.encostouEsquerda,controllerPulo.estaNoChao,"Esquerda",DISTANCIA_PULO_X,DISTANCIA_PULO_Y);
				cdwPulo = servicePlayer.puloLado(rb2d,controllerPuloLadoD.encostouDireita,controllerPulo.estaNoChao,"Direita",DISTANCIA_PULO_X,DISTANCIA_PULO_Y);
			}
		}else{
			cdwPulo = 0;
		}


	}

}





