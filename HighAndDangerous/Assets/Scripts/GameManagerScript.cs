using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public Font font;
	public GameObject player;
	
	private DungeonCreator dungeonCreator;
	private GUIStyle statusStyle, titleStyle, subtitleStyle;
	
	// Variables del Juego:
	public int lifes = 3;
	public int level = 1;
	
	public bool is_playing = true;
	public bool is_alive   = true;
	
	// Use this for initialization
	void Start () {
		// TODO: Aca se pasarian los parametros del primer nivel
		GetDungeonCreator().Generate();	
		
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
		GUI.Label(new Rect(20, 50, 200, 40), "Lifes: " + this.lifes, statusStyle);
		GUI.Label(new Rect(20, 80, 200, 40), "Level: " + this.level, statusStyle);
	}
	
	private void LevelFinishedGUI(){
		GUI.Label(new Rect((Screen.width-600)/2, (Screen.height+100)/2, 600, 100), "Level finished", titleStyle);
		GUI.Label(new Rect((Screen.width-700)/2, (Screen.height+300)/2, 700, 100), "Press Space to start the next level", subtitleStyle);
		
		if(Input.GetButton("Jump")) GenerateLevel();
	}
	
	private void GameOverGUI(){
		GUI.Label(new Rect((Screen.width-600)/2, (Screen.height+100)/2, 600, 100), "Gamve Over", titleStyle);
		GUI.Label(new Rect((Screen.width-700)/2, (Screen.height+300)/2, 700, 100), "Press Space to start again", subtitleStyle);
		
		if(Input.GetButton("Jump")) GenerateLevel();
	}
	
	// ========== Dungeon Generator Methods ==========
	
	private void GenerateLevel(){
		GetDungeonCreator().RemoveAll();
		GetDungeonCreator().Generate();
		
		player.transform.position = Vector3.zero;
	}
	
	
	private DungeonCreator GetDungeonCreator(){
		if(dungeonCreator == null) {
			dungeonCreator = (DungeonCreator) GameObject.FindGameObjectWithTag("DungeonManager").GetComponent(typeof(DungeonCreator));
		}
		
		return dungeonCreator;
	}	

}
