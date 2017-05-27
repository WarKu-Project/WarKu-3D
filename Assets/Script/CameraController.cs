using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	public Vector3 offset;
	private Vector3 previousLocation;
	private Vector3 currentLocation;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
		previousLocation = currentLocation;    
		currentLocation = transform.position;
//		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (currentLocation - previousLocation), Time.fixedDeltaTime * rotationSpeed);

	}
}
