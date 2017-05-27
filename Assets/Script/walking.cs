using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour {

	private Animator anim;
	// How fast your object moves
	public float moveSpeed,runSpeed,walkSpeed;
	// How fast your object will rotate in the direction of movement
	public float rotationSpeed;
	private Vector3 previousLocation;
	private Vector3 currentLocation;
	public Score score;
	GameObject player;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		previousLocation = currentLocation;    
		currentLocation = transform.position;
		score.setCurrentLocation (currentLocation);
		
		if (Input.GetKey ("w") && Input.GetKey ("a")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.Play ("run");
				moveSpeed = runSpeed;
			} else {
				anim.Play ("walk");
				moveSpeed = walkSpeed;
			}
			currentLocation.z += moveSpeed * Time.fixedDeltaTime;
			currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
			transform.position = currentLocation;
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
		} else if (Input.GetKey ("w") && Input.GetKey ("d")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.Play ("run");
				moveSpeed = runSpeed;
			} else {
				anim.Play ("walk");
				moveSpeed = walkSpeed;
			}
			currentLocation.z += moveSpeed * Time.fixedDeltaTime;
			currentLocation.x += moveSpeed * Time.fixedDeltaTime;
			transform.position = currentLocation;
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
		} else if (Input.GetKey ("a") && Input.GetKey ("s")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.Play ("run");
				moveSpeed = runSpeed;
			} else {
				anim.Play ("walk");
				moveSpeed = walkSpeed;
			}
			currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
			currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
			transform.position = currentLocation;
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
		} else if (Input.GetKey ("s") && Input.GetKey ("d")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.Play ("run");
				moveSpeed = runSpeed;
			} else {
				anim.Play ("walk");
				moveSpeed = walkSpeed;
			}
			currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
			currentLocation.x += moveSpeed * Time.fixedDeltaTime;
			transform.position = currentLocation;
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
		} else if (Input.GetKey ("w")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.Play ("run");
				moveSpeed = runSpeed;
			} 
			else {
				anim.Play ("walk");
				moveSpeed = walkSpeed;
			}
			currentLocation.z += moveSpeed * Time.fixedDeltaTime;
			transform.position = currentLocation;
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
		} else if (Input.GetKey ("a")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.Play ("run");
				moveSpeed = runSpeed;
			} else {
				anim.Play ("walk");
				moveSpeed = walkSpeed;
			}
			currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
			transform.position = currentLocation;
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
		} else if (Input.GetKey ("s")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.Play ("run");
				moveSpeed = runSpeed;
			} else {
				anim.Play ("walk");
				moveSpeed = walkSpeed;
			}
			currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
			transform.position = currentLocation;
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
		} else if (Input.GetKey ("d")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.Play ("run");
				moveSpeed = runSpeed;
			} else {
				anim.Play ("walk");
				moveSpeed = walkSpeed;
			}
			currentLocation.x += moveSpeed * Time.fixedDeltaTime;
			transform.position = currentLocation;
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
		} else if (Input.GetKey ("space")) {
			anim.Play ("attack");
		} 
		else {
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("attack")) {
				if(anim.GetCurrentAnimatorStateInfo (0).normalizedTime>=1){
					anim.Play ("idle");
				}
			} else {
				anim.Play ("idle");

			}
		}
	}
}
