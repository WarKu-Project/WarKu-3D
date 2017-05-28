using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	public Transform player_locate;
	public Vector3 offset;
	private Vector3 point;
	private Vector3 previousLocation;
	private Vector3 currentLocation;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
//		transform.LookAt (point);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
		previousLocation = currentLocation;    
		currentLocation = transform.position;
		transform.LookAt (player_locate.position);

//		transform.RotateAround (point, new Vector3 (0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * 10.0f);
//		transform.LookAt (point);
//		transform.LookAt (castle.position);
//		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (currentLocation - previousLocation), Time.fixedDeltaTime * rotationSpeed);

	}
}
