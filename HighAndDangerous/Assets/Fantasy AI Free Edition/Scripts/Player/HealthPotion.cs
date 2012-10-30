using UnityEngine;
using System.Collections;

public class HealthPotion : MonoBehaviour {
	GameObject Player;
	public float HpBoost=100;
	
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerEnter(Collider other){
		if(other.transform==Player.transform){
		Health hp=(Health)other.transform.GetComponent("Health");
		if(hp){
		if(hp.CurrentHealth<hp.MaxHealth){		
		hp.CurrentHealth=hp.CurrentHealth+HpBoost;
			Destroy(gameObject);
				}
		}
	}
	}
}
