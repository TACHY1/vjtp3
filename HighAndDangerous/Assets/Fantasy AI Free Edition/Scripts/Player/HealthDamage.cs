using UnityEngine;
using System.Collections;

public class HealthDamage : MonoBehaviour {

	public Transform Player;
	public int HpBoost=100;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerEnter(Collider other){
		if(other.transform==Player){
		Health hp=(Health)other.transform.GetComponent("Health");
		
		if(hp){
				
			//if(hp.CurrentHealth<hp.MaxHealth){		
				
				hp.startDamage(HpBoost);
			//	Destroy(gameObject);
			//}
		}
	}
	}
	
	void OnTriggerExit(Collider other){
		if(other.transform==Player){
		Health hp=(Health)other.transform.GetComponent("Health");
		
		if(hp){
				
			//if(hp.CurrentHealth<hp.MaxHealth){		
				hp.stopDamage();
				//hp.CurrentHealth=hp.CurrentHealth-HpBoost;
			//	Destroy(gameObject);
			//}
		}
	}
	}
}
