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
	
	public Quaternion getEndRotation () {
		return endPoint.transform.rotation;
	}
	
	public Quaternion getStartRotation() {
		return startPoint.transform.rotation;
	}
	
	public Vector3 getEndNormal () {
		return endPoint.transform.forward;
	}
	
	public Vector3 getStartNormal() {
		return startPoint.transform.forward;
	}
	
	
	public void setStartPosition(Vector3 position){
		gameObject.transform.position = position;
	}

	public void setRotation(Quaternion rot){
		gameObject.transform.rotation = new Quaternion(0,rot.y,0,0);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
