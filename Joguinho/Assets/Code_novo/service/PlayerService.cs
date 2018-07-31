using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour{

    private Player player;
    private PlayerPuloCollider playerPuloCollider;
    private GameObject playerGameObject;

	private float movHorizontal;
	private float movVertical;
    private float movJump;
    private bool estaPulando;

    private float cdw;

    public PlayerService(GameObject gameObj){
        this.player = new Player(gameObj);
        this.playerGameObject = gameObj;
        this.playerPuloCollider = gameObj.GetComponentInChildren<PlayerPuloCollider>();
        this.cdw = 0;
    }

    public void andar(){
        player.setMovHorizontal(GameUtils.AXIS_HORIZONTAL);
		
        if (movHorizontal != 0){
            Vector2 vetHorizontal = new Vector2(movHorizontal, 0);
            player.getRgb2D().AddForce(vetHorizontal * player.getVelocidadeAndar());
        }
    }

	public void pular(){
        estaPulando = playerPuloCollider.estaPulando;       

        if(cdw >= 1){
            if(movJump != 0 && !estaPulando){
                Vector2 vetPular = new Vector2(0,movJump);
                player.getRgb2D().AddForce(vetPular * player.getImpulsoPulo());
                cdw = 0;
            }
        }else{
            cdw += Time.deltaTime;
        }
	}

	public void atualizaInputs(){
		player.setMovHorizontal(GameUtils.AXIS_HORIZONTAL);
		player.setMovVertical(GameUtils.AXIS_VERTICAL);
        player.setMovJump(GameUtils.AXIS_JUMP);

		movHorizontal = player.getMovHorizontal();
		movVertical = player.getMovVertical();
        movJump = player.getMovJump();
	}

    public void atualizaDirecao(){
        Vector3 escala = playerGameObject.transform.localScale;
        if(movHorizontal > 0 && escala.x <= 0 || movHorizontal <0 && escala.x >= 0){
            escala.x = escala.x*-1;
        }
        playerGameObject.transform.localScale = escala;
    }

    public void atualizaAnimacao(){
        if(movHorizontal != 0){
            player.getAnim().setRun(true);
        }else{
            player.getAnim().setRun(false);
        }

        if(estaPulando){
            player.getAnim().setJump(true);
        }else{
            player.getAnim().setJump(false);
        }
    }

    public void travarControles(){

        player.setTravarControles(true);
        movHorizontal = 0;
        movJump = 0;
        movVertical = 0;
    }

    public void destravarControles(){

        player.setTravarControles(false);
    }
}
