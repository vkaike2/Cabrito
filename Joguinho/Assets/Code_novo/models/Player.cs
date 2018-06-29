using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float velocidadeAndar;
	private float impulsoPulo;
	private PlayerAnimator anim;
	private Rigidbody2D rgb2D;
	private float movHorizontal;
	private float movVertical;
	private float movJump;
	private bool travarControles;

    public Player(GameObject gameObj){
		this.velocidadeAndar = 50;
		this.impulsoPulo = 1100;
		this.anim = new PlayerAnimator(gameObj);
		this.rgb2D = gameObj.GetComponent<Rigidbody2D>();
		this.travarControles = false;
    }

    public float getVelocidadeAndar(){
		return this.velocidadeAndar;
	}
	public void setVelocidadeAndar(float velocidadeAndar){
		this.velocidadeAndar = velocidadeAndar;
	}
	public float getImpulsoPulo(){
		return this.impulsoPulo;
	}	
	public void setImpulsoPulo(float impulsoPulo){
		this.impulsoPulo = impulsoPulo;
	}
	public PlayerAnimator getAnim(){
		return this.anim;
	}
	public Rigidbody2D getRgb2D(){
		return this.rgb2D;
	}
	public float getMovHorizontal(){
		return this.movHorizontal;
	}
	public void setMovVertical(string movVertical){
		if(!travarControles){
		this.movVertical = Input.GetAxisRaw(movVertical);
		}
	}
	public float getMovVertical(){
		return this.movVertical;
	}
	public void setMovHorizontal(string movHorizontal){
		if(!travarControles){
		this.movHorizontal = Input.GetAxisRaw(movHorizontal);
		}
	}
	public float getMovJump(){
		return this.movJump;
	}
	public void setMovJump(string movJump){
		if(!travarControles){
		this.movJump = Input.GetAxisRaw(movJump);
		}
	}
	public bool getTravarControles(){
		return this.travarControles;
	}
	public void setTravarControles(bool travarControles){
		this.travarControles = travarControles;
	}

}
