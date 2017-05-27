using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	private double score = 0;
	private Vector3 currentLocation;
	public GameObject explosion;
	public GameObject player;
	private GameObject aura; 
	public void setCurrentLocation(Vector3 currentLocation){
		this.currentLocation = currentLocation;
		if(currentLocation.x >= 213.5 && currentLocation.x <= 273.5){
			if (currentLocation.z >= 216.5 && currentLocation.z <= 270.5){
				score += 0.05;
				aura = Instantiate (explosion,currentLocation,Quaternion.identity);
				Debug.Log (score);
			}
		}
		Destroy (aura,0.5f);
	}

	// Use this for initialization
	public void Start () {
		
	}
	
//	 Update is called once per frame
	void Update () {
		
	}
}
