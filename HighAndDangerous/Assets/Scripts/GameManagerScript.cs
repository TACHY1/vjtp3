using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public Font font;
	public GameObject player;
	
	private DungeonCreator dungeonCreator;
	private GUIStyle statusStyle, titleStyle, subtitleStyle;
	
	// Dificultad por niveles
	private int maxLevel = 6;
	private int[] chunksPerLevel   = { 25, 35, 40, 45, 50, 65 };
	private int[] positivePerLevel = { 25, 25, 20, 20, 15, 15 };
	private int[] negativePerLevel = { 35, 40, 45, 50, 50, 55 };
	private int[] enemiesPerLevel  = { 40, 35, 35, 30, 35, 30 };
	
	// Variables del Juego:
	private int lives = 3;
	private int level = 0;
	private int health = 0;
	
	public bool is_playing = true;
	public bool is_alive   = true;	
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		GenerateLevel();
		
		statusStyle = new GUIStyle();
		statusStyle.font = font;
		statusStyle.fontSize = 18;
		statusStyle.normal.textColor = Color.white;
		
		titleStyle = new GUIStyle();
		titleStyle.font = font;
		titleStyle.fontSize = 60;
		titleStyle.normal.textColor = Color.white;
		titleStyle.alignment = TextAnchor.MiddleCenter;
		
		subtitleStyle = new GUIStyle();
		subtitleStyle.font = font;
		subtitleStyle.fontSize = 35;
		subtitleStyle.normal.textColor = Color.yellow;
		subtitleStyle.alignment = TextAnchor.MiddleCenter;
	}
	
	// Update is called once per frame
	void Update () {}
	
	// ========== GAME Methods ==========

	   public bool isPlaying() {
	       return is_playing;
	   }
	
	   public bool isAlive() {
	       return is_alive;
	   }
	
	   public void setPlaying(bool playing) {
	       is_playing = playing;
	   }
	
	   public void setAlive(bool alive) {
	       is_alive = alive;
	   }        
	
	   public void setHealth(int newHealth) {
	       health = newHealth;
	   }
	
	// ========== GUI Methods ==========
	
	void OnGUI () {
		this.GameStatusGUI();
		
		if(!this.is_playing) {
			if(this.is_alive) this.LevelFinishedGUI();
			else 			  this.GameOverGUI();
		}
	}
	
	private void GameStatusGUI(){
		GUI.Label(new Rect(20, 50, 200, 40), "Health: " + this.health, statusStyle);
		GUI.Label(new Rect(20, 80, 200, 40), "Level: " + (this.level+1), statusStyle);
	}
	
	private void LevelFinishedGUI(){
		GUI.Label(new Rect((Screen.width-600)/2, (Screen.height+100)/2, 600, 100), "Level finished", titleStyle);
		GUI.Label(new Rect((Screen.width-700)/2, (Screen.height+300)/2, 700, 100), "Press Space to start the next level", subtitleStyle);
		
		if(Input.GetButton("Jump")){
			this.level++;
			this.is_playing = true;
			this.is_alive = true;
			GenerateLevel();
		}
	}
	
	private void GameOverGUI(){
		GUI.Label(new Rect((Screen.width-600)/2, (Screen.height+100)/2, 600, 100), "Game Over", titleStyle);
		GUI.Label(new Rect((Screen.width-700)/2, (Screen.height+300)/2, 700, 100), "Press Space to start again", subtitleStyle);
		
		if(Input.GetButton("Jump")){
			this.level = 0;
			this.is_playing = true;
			this.is_alive = true;
			UnityEngine.Object.DestroyImmediate(GameObject.FindGameObjectWithTag("Player"));
			UnityEngine.Object.DestroyImmediate(GameObject.FindGameObjectWithTag("MainCamera"));
			player = (GameObject)Instantiate(Resources.Load("Player"));
			
			GenerateLevel();
		}
	}
	
	// ========== Dungeon Generator Methods ==========
	
	private void GenerateLevel(){
		DungeonCreator generator = GetDungeonCreator();
		generator.RemoveAll();
		
		generator.numChunks    = chunksPerLevel[level];
		generator.positiveProb = positivePerLevel[level];
		generator.negativeProb = negativePerLevel[level];
		generator.enemyProb    = enemiesPerLevel[level];
		
		generator.Generate();
		Health hp=(Health)player.transform.GetComponent("Health");
		hp.CurrentHealth = hp.MaxHealth;
		
		player.transform.position = new Vector3(-1, 0.5F, 0);
	}
	
	
	private DungeonCreator GetDungeonCreator(){
		if(dungeonCreator == null) {
			dungeonCreator = (DungeonCreator) GameObject.FindGameObjectWithTag("DungeonManager").GetComponent(typeof(DungeonCreator));
		}
		
		return dungeonCreator;
	}	

}
