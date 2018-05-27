using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour {

	private GameObject player;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player_Test");
		offset = new Vector3(0,0,-10);
		offset.y = transform.position.y - player.transform.position.y;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		gameObject.transform.position = new Vector3(0,player.transform.position.y,-10) + offset;
	}
}
