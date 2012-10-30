using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float MaxHealth=100;
	public float CurrentHealth;
	public bool Invincible;
	public bool Dead;
	public bool mustDamage;
	private float nextActionTime = 1f;
	public float period = 1f;
	private int damageHit;
	// Use this for initialization
	void Start () {
		//MAKE THE CURRENT HEALTH THE MAX HEALTH AT START
		mustDamage = false;
		
	CurrentHealth=MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
		//IF INVINCIBLE, HE CANNOT DIE..
		if(Invincible){
		CurrentHealth=MaxHealth;	
		}
		else{
		if(CurrentHealth<=0){
			CurrentHealth=0;
			Dead=true;
		}	
			if (Time.time > nextActionTime && mustDamage ) {
       			nextActionTime += period;
        		CurrentHealth = CurrentHealth - damageHit;
				if(CurrentHealth < 0) CurrentHealth = 0;
    		}
			
		//MAX HEALTH
			if(CurrentHealth>=MaxHealth)CurrentHealth=MaxHealth;
			
			//WHEN DEATH IS UPON HIM
		if(Dead){
				//TELL THE AI SCRIPT HE IS DEAD
			FreeAI AI=(FreeAI)GetComponent("FreeAI");
				if(AI){
			if(AI.IsDead){}
			else AI.IsDead=true;
		}
		}
		}
	
	}
	
	public void startDamage(int damage){
		damageHit = damage;
		nextActionTime = Time.time;
		mustDamage = true;
		
	}
	
	public void stopDamage(){
		mustDamage = false;
	}
}
