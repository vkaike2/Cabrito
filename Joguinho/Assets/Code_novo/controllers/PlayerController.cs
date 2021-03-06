﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private PlayerService playerService;

	void Awake() {
		playerService = new PlayerService(gameObject);
	}
	void Start () {
		
	}
	
	void FixedUpdate() {
		playerService.andar();
		playerService.pular();
	}
	
	void Update () {
		playerService.atualizaInputs();
		playerService.atualizaDirecao();
		playerService.atualizaAnimacao();
	}

	void travarControles(){
		playerService.travarControles();
	}
	void destravarControles(){
		playerService.destravarControles();
	}
}
