using UnityEngine;
using System.Collections;

public class Chunk : MonoBehaviour {

	public GameObject startPoint;
	public GameObject endPoint;
	
	public Vector3 getStartPosition () {
		return startPoint.transform.localPosition;
	}
	
	public Vector3 getEndPosition () {
		return endPoint.transform.position;
	}
	
	public void setStartPosition(Vector3 position){
		gameObject.transform.position = position;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
