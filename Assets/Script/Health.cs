using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class Health : MonoBehaviour {

	public float maxHealth;
	public bool isPlayer;
	public GameObject healthbar;
	private float remainHealth;
	private bool take_damage,death;
	// Use this for initialization
	void Start () {
		remainHealth = maxHealth;
		Debug.Log ("Start");
		death = false;
//		healthbar = GameObject.Find ("health_bar");
	}

	void Update(){
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("idle")) {
			take_damage = false;
		}
		var healthValue = (remainHealth/maxHealth)*1.5f;
		healthbar.transform.localScale = new Vector3 ( transform.localScale.x*0.1f, transform.localScale.y*0.1f, healthValue);
	}

	bool isDeath(){
		if (remainHealth <= 0)
			return true;
		else
			return false;
	}

	bool getDeath(){
		return death;
	}

	void setDeath(bool newdeath){
		death = newdeath;
	}

	bool getTakeDamage(){
		return take_damage;
	}

	void setTakeDamage(bool newtakedamage){
		take_damage = newtakedamage;
	}

	public void reduceHealth(float damage){
		remainHealth -= damage;
		if (remainHealth < 0) {
			remainHealth = 0;
		}
	}

	float getRemainHealth(){
		return remainHealth;
	}
		
	void OnTriggerEnter(Collider  o ){
        Debug.Log("Hit "+o.tag);
		//if (gameObject.tag=="Player") {
			Debug.Log ("tag_player: "+o.gameObject.tag);    
			if (o.tag == "Enemy") {			
				if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("attack") && !take_damage && !death) {
                /*Debug.Log ("Take Damage Health: " + remainHealth);
                take_damage = true;
                reduceHealth (o.gameObject.GetComponentInParent<walking> ().attackDamage);
                Debug.Log ("Take Damage Health: " + remainHealth);
                if (isDeath ()) {
                    Debug.Log ("death");
                    gameObject.GetComponentInParent<walking> ().deathAction ();
                    death = true;
                }*/
                     Debug.Log("ID : " + o.transform.root.GetComponent<OtherUnitProperty>().uid);
                    FirebaseDatabase.DefaultInstance.GetReference("deadlist").Child(o.transform.root.GetComponent<OtherUnitProperty>().uid).SetValueAsync(o.transform.root.GetComponent<OtherUnitProperty>().uid);
                } 
			} 
	//	} /*else {
		//	Debug.Log ("tag_enemy: "+o.gameObject.tag);*/
		//	if (o.tag == "Player") {	
			//	if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("attack") && !take_damage && !death) {
				/*	Debug.Log ("Take Damage Health: " + remainHealth);
					take_damage = true;
					reduceHealth (o.gameObject.GetComponentInParent<walking> ().attackDamage);*/
                  //  if (gameObject.tag!="Player")
                  //      FirebaseDatabase.DefaultInstance.GetReference("units").Child(GetComponent<OtherUnitProperty>().uid).Child("hp").SetValueAsync(GetComponent<OtherUnitProperty>().hp-1);
					/*Debug.Log ("Take Damage Health: " + remainHealth);
					if (isDeath ()) {
						Debug.Log ("death");
						gameObject.GetComponentInParent<walking> ().deathAction ();
						death = true;
					}*/
				//} 
		//	} 
		/*}*/
	}

    class UID
    {
        public string uid;
    public UID(string uid)
    {
        this.uid = uid;
    }
}
}
