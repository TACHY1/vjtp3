using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public Font font;	
	private DungeonCreator dungeonCreator;
	
	// Use this for initialization
	void Start () {
		// TODO: Aca se pasarian los parametros del primer nivel
		GetDungeonCreator().Generate();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUIStyle style = new GUIStyle();
		style.fontSize = 18;
		style.font = font;
		style.normal.textColor = Color.white;

		GUI.Label(new Rect(20, 20, 200, 40), "Time left: ", style);
		GUI.Label(new Rect(20, 50, 200, 40), "Vidas: ", style);
		
		if(false) {
			style.alignment = TextAnchor.MiddleCenter;			
			style.fontSize = 60;
			GUI.Label(new Rect((Screen.width-600)/2, (Screen.height+100)/2, 600, 100), "Level finished", style);
	
			style.fontSize = 35;
			style.normal.textColor = Color.yellow;
	
			GUI.Label(new Rect((Screen.width-700)/2, (Screen.height+300)/2, 700, 100), "Press any key to go next level", style);
			if(Input.anyKeyDown){
				GetDungeonCreator().RemoveAll();
				// TODO: Aca se pasarian los parametros del siguiente nivel
				GetDungeonCreator().Generate();				
			}
		} else if(true) {
			style.alignment = TextAnchor.MiddleCenter;
			style.fontSize = 60;
			GUI.Label(new Rect((Screen.width-600)/2, (Screen.height+100)/2, 600, 100), "Gamve Over", style);
	
			style.fontSize = 35;
			style.normal.textColor = Color.yellow;
	
			GUI.Label(new Rect((Screen.width-700)/2, (Screen.height+300)/2, 700, 100), "Press any key to start again", style);
			if(Input.anyKeyDown){
				GetDungeonCreator().RemoveAll();
				// TODO: Aca se pasarian los parametros del primer nivel
				GetDungeonCreator().Generate();
			}
		}	

	}
	
	private DungeonCreator GetDungeonCreator(){
		if(dungeonCreator == null) {
			dungeonCreator = (DungeonCreator) GameObject.FindGameObjectWithTag("DungeonManager").GetComponent(typeof(DungeonCreator));
		}
		
		return dungeonCreator;
	}	

}
