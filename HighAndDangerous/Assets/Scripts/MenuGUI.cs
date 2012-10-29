using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
	
	public Font font;
	
	public int size = 18;
	
	public int top = 50;
	public int left = 50;
	public int width = 50;
	public int height = 50;
	
	void Start(){
	}
	
	void OnGUI(){
		var style = getTitleStyle(Color.white);
		GUI.Label(new Rect(18, 53, 550, 100), "High And Dangerus", style);
		
		style = getTitleStyle(Color.black);
		GUI.Label(new Rect(16, 51, 550, 100), "High And Dangerus", style);
		
		style = getSubtitleStyle(Color.white);
		GUI.Label(new Rect(396, 584, 340, 40), "- Press Space to Play -", style);
	}
	
	private GUIStyle getTitleStyle(Color color){
		var style = new GUIStyle();
		style.font = font;
		style.fontSize = 42;
		style.normal.textColor = color;
		return style;
	}
	
	private GUIStyle getSubtitleStyle(Color color){
		var style = new GUIStyle();
		style.font = font;
		style.fontSize = 23;
		style.normal.textColor = color;
		return style;
	}
}
