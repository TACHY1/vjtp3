using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
	
	public Font font;
	
	void Update(){
		if(Input.GetButton("Jump")) Application.LoadLevel(1);
	}
	
	void OnGUI(){
		var style = getTitleStyle(Color.white);
		GUI.Label(new Rect(18, 53, 550, 100), "High And Dangerus", style);
		
		style = getTitleStyle(Color.black);
		GUI.Label(new Rect(16, 51, 550, 100), "High And Dangerus", style);
		
		style = getSubtitleStyle(Color.yellow);
		int left = Screen.width - 328;
		int top = Screen.height - 51;
		GUI.Label(new Rect(left, top, 340, 40), "- Press Space to Play -", style);
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
