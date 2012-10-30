using System;
using System.Collections;

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DungeonCreator))]
public class DungeonCreatorTester : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		if (GUILayout.Button("Generate"))
		{
			GameObject.Find("DungeonManager").GetComponent<DungeonCreator>().Generate();
		}
		
		if (GUILayout.Button("Remove All"))
		{
			GameObject.Find("DungeonManager").GetComponent<DungeonCreator>().RemoveAll();
		}
	}
}
