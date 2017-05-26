using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float maxHealth;
	private float remainHealth;
	private bool take_damage,death;
	// Use this for initialization
	void Start () {
		remainHealth = maxHealth;
		Debug.Log ("Start");
		death = false;
	}

	void Update(){
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("idle")) {
			take_damage = false;
		}

	}

	bool isDeath(){
		if (remainHealth <= 0)
			return true;
		else
			return false;
	}

	public void reduceHealth(float damage){
		remainHealth -= damage;
	}
		
	void OnTriggerEnter(Collider o ){
		if (o.tag == "Player") {
			if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("attack") && !take_damage && !death) {
				Debug.Log ("Take Damage Health: "+remainHealth);
				take_damage = true;
				reduceHealth(o.gameObject.GetComponentInParent<walking>().attackDamage);
				Debug.Log ("Take Damage Health: "+remainHealth);
				if (isDeath()) {
					Debug.Log ("death");
					o.gameObject.GetComponentInParent<walking> ().deathAction();
					death = true;
				}
			} 
		}

	}
}
