using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public Font font;
	public GameObject player;
	
	private DungeonCreator dungeonCreator;
	private GUIStyle statusStyle, titleStyle, subtitleStyle;
	
	// Dificultad por niveles
	private int maxLevel = 6;
	private int[] chunksPerLevel   = { 20, 25, 30, 45, 40, 45 };
	private int[] positivePerLevel = { 60, 50, 40, 30, 20, 10 };
	private int[] negativePerLevel = { 30, 35, 40, 45, 40, 40 };
	private int[] enemiesPerLevel  = { 10, 15, 20, 25, 40, 50 };
	
	// Variables del Juego:
	private int lives = 3;
	private int level = 0;
	
	public bool is_playing = true;
	public bool is_alive   = true;
	
	// Use this for initialization
	void Start () {
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
	
	
	// ========== GUI Methods ==========
	
	void OnGUI () {
		this.GameStatusGUI();
		
		if(!this.is_playing) {
			if(this.is_alive) this.LevelFinishedGUI();
			else 			  this.GameOverGUI();
		}
	}
	
	private void GameStatusGUI(){
		GUI.Label(new Rect(20, 20, 200, 40), "Time left: ", statusStyle);
		GUI.Label(new Rect(20, 50, 200, 40), "Lifes: " + this.lives, statusStyle);
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
		GUI.Label(new Rect((Screen.width-600)/2, (Screen.height+100)/2, 600, 100), "Gamve Over", titleStyle);
		GUI.Label(new Rect((Screen.width-700)/2, (Screen.height+300)/2, 700, 100), "Press Space to start again", subtitleStyle);
		
		if(Input.GetButton("Jump")){
			this.level = 0;
			this.is_playing = true;
			this.is_alive = true;
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
		
		player.transform.position = Vector3.zero;
	}
	
	
	private DungeonCreator GetDungeonCreator(){
		if(dungeonCreator == null) {
			dungeonCreator = (DungeonCreator) GameObject.FindGameObjectWithTag("DungeonManager").GetComponent(typeof(DungeonCreator));
		}
		
		return dungeonCreator;
	}	

}
