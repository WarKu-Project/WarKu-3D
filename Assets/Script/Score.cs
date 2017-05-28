using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	private double score = 0;
	private Vector3 currentLocation;
	public GameObject explosion;
	public GameObject player;
	private GameObject aura; 
	public CiclularProgress process;
	public bool checkCurrentLocation(Vector3 currentLocation){
		if(currentLocation.x >= 213.5 && currentLocation.x <= 273.5){
			if (currentLocation.z >= 216.5 && currentLocation.z <= 270.5){
				return true;
			}
			else return false;
		} else return false;

	}

	public void setScore(Vector3 currentLocation){
		if (checkCurrentLocation (currentLocation)) {
			score += 0.1;
			aura = Instantiate (explosion, currentLocation, Quaternion.identity);
//			process.updateProcess (score);
			Debug.Log (score);
		} else {
			Debug.Log ("gun");
			score = 0;
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
