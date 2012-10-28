using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[ExecuteInEditMode]
public class DungeonCreator : MonoBehaviour {
	
	public int numChunks;
	public GameObject[] possibleChunks;
	
	public void Generate() {
		GameObject startChunk = UnityEngine.Object.Instantiate(possibleChunks[0]) as GameObject;
		startChunk.transform.position = Vector3.zero;
		
		Chunk lastChunkScrpt = (Chunk) startChunk.gameObject.GetComponent(typeof(Chunk));

		for(int i = 1 ; i < numChunks ; i++){
			GameObject nextChunk = UnityEngine.Object.Instantiate(possibleChunks[i%2]) as GameObject;
			Chunk nextChunkScript = (Chunk) nextChunk.gameObject.GetComponent(typeof(Chunk));
			
			print(lastChunkScrpt.getEndRotation());
			print(nextChunkScript.getStartRotation());
			nextChunkScript.setRotation(lastChunkScrpt.getEndRotation());

			nextChunkScript.setStartPosition(lastChunkScrpt.getEndPosition()-nextChunkScript.getStartPosition());

			lastChunkScrpt = nextChunkScript;
		}
	}
	
	
	public void RemoveAll() {
		 
	}
}
