using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour {
	float time = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("AA");
		time += Time.deltaTime;
		if(time==0.1f){
			Destroy (gameObject);
			time = 0;
		}
	}
}
