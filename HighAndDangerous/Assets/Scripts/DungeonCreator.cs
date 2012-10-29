using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[ExecuteInEditMode]
public class DungeonCreator : MonoBehaviour {

	public GameObject TheDungeon;
	public int numChunks;
	public GameObject endChunk;
	public GameObject[] possibleChunks;
	
	public void Generate() {
		GameObject dungeonObject = UnityEngine.Object.Instantiate(TheDungeon) as GameObject;	
		GameObject startChunk = UnityEngine.Object.Instantiate(possibleChunks[0]) as GameObject;

		startChunk.transform.parent = dungeonObject.transform;
		
		startChunk.transform.position = Vector3.zero;
		GameObject endChunkObject = UnityEngine.Object.Instantiate(endChunk) as GameObject;
		Chunk endChunkScript = (Chunk) endChunkObject.gameObject.GetComponent(typeof(Chunk));		
		endChunkObject.transform.parent = dungeonObject.transform;
		
		Chunk lastChunkScrpt = (Chunk) startChunk.gameObject.GetComponent(typeof(Chunk));

		for(int i = 1 ; i < numChunks ; i++){
			GameObject nextChunk = UnityEngine.Object.Instantiate(possibleChunks[UnityEngine.Random.Range(0,7)]) as GameObject;
			Chunk nextChunkScript = (Chunk) nextChunk.gameObject.GetComponent(typeof(Chunk));
			nextChunk.transform.parent = dungeonObject.transform;
			
//			nextChunkScript.setRotation(lastChunkScrpt.getEndRotation());
//			nextChunkScript.setRotation(Quaternion.FromToRotation(lastChunkScrpt.getEndNormal, nextChunkScript.getStartNormal));
	
			nextChunkScript.setStartPosition(lastChunkScrpt.getEndPosition()-nextChunkScript.getStartPosition());

			lastChunkScrpt = nextChunkScript;
		}

		endChunkScript.setStartPosition(lastChunkScrpt.getEndPosition()-endChunkScript.getStartPosition());
	}
	
	
	public void RemoveAll() {
		GameObject[] dungeons = GameObject.FindGameObjectsWithTag("DungeonObject");
		
//		for(int i = 0 ; i < dungeons.Count ; i++){
//			Destroy(dungeons[i]);
//		}
	}
}
