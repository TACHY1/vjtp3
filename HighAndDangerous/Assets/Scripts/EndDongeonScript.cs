using UnityEngine;
using System.Collections;

public class EndDongeonScript : MonoBehaviour {
	GameObject Player;
	GameManagerScript GameManager;
	PlayerController playerController;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		GameManager = GetGameManager();
		playerController = GetPlayerController();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.transform==Player.transform){
			GetGameManager().setPlaying(false);
		}
	}
	
	private GameManagerScript GetGameManager(){
       if(GameManager == null) {
               GameManager = (GameManagerScript) GameObject.FindGameObjectWithTag("GameManager").GetComponent(typeof(GameManagerScript));
       }
       
       return GameManager;
    }
	
	private PlayerController GetPlayerController(){
       if(playerController == null) {
           playerController = (PlayerController) Player.GetComponent(typeof(PlayerController));
       }
       
       return playerController;
    }
}
