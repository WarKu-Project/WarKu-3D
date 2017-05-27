using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class walking : MonoBehaviour {

	public Animator anim;
	// How fast your object moves
	public float moveSpeed,runSpeed,walkSpeed,attackDamage;
	// How fast your object will rotate in the direction of movement
	public float rotationSpeed;
	private Vector3 previousLocation;
	private Vector3 currentLocation;
	public float walk, turn;
	public bool attack, run;

    float time = 0;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	float getAttackDamage() {
		return attackDamage;
	}

	public void deathAction(){
		anim.Play ("death");
	}

	void checkAction(){
		if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("attack")) {
			if ((turn==-1&&(walk<0.3&&walk>-0.3))||Input.GetKey ("a")) {
				if (Input.GetKey (KeyCode.LeftShift) || run) {
					anim.Play ("run");
					moveSpeed = runSpeed;
				} 
				else if (Input.GetKey ("space") || attack) {
					anim.Play ("attack");
				} 
				else {
					anim.Play ("walk");
					moveSpeed = walkSpeed;
				}
				currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
				transform.position = currentLocation;
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
			} else if ((walk==-1&&(turn<1&&turn>-1))||Input.GetKey ("s")) {
				if (Input.GetKey (KeyCode.LeftShift) || run) {
					anim.Play ("run");
					moveSpeed = runSpeed;
				} 
				else if (Input.GetKey ("space") || attack) {
					anim.Play ("attack");
				} 
				else {
					anim.Play ("walk");
					moveSpeed = walkSpeed;
				}
				currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
				transform.position = currentLocation;
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
			} else if ((turn==1&&(walk<0.3&&walk>-0.3))||Input.GetKey ("d")) {
				if (Input.GetKey (KeyCode.LeftShift) || run) {
					anim.Play ("run");
					moveSpeed = runSpeed;
				} 
				else if (Input.GetKey ("space") || attack) {
					anim.Play ("attack");
				} 
				else {
					anim.Play ("walk");
					moveSpeed = walkSpeed;
				}
				currentLocation.x += moveSpeed * Time.fixedDeltaTime;
				transform.position = currentLocation;
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
			} 
			else if ((Input.GetKey ("w") && Input.GetKey ("a"))||(walk>0&&turn==-1)) {
				if (Input.GetKey (KeyCode.LeftShift) || run) {
					anim.Play ("run");
					moveSpeed = runSpeed;
				} 
				else if (Input.GetKey ("space") || attack) {
					anim.Play ("attack");
				} 
				else {
					anim.Play ("walk");
					moveSpeed = walkSpeed;
				}
				currentLocation.z += moveSpeed * Time.fixedDeltaTime;
				currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
				transform.position = currentLocation;
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
			} else if ((Input.GetKey ("w") && Input.GetKey ("d"))||(walk>0&&turn==1)) {
				if (Input.GetKey (KeyCode.LeftShift) || run) {
					anim.Play ("run");
					moveSpeed = runSpeed;
				} 
				else if (Input.GetKey ("space") || attack) {
					anim.Play ("attack");
				} 
				else {
					anim.Play ("walk");
					moveSpeed = walkSpeed;
				}
				currentLocation.z += moveSpeed * Time.fixedDeltaTime;
				currentLocation.x += moveSpeed * Time.fixedDeltaTime;
				transform.position = currentLocation;
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
			} else if ((Input.GetKey ("a") && Input.GetKey ("s"))||(walk<0&&turn==-1)) {
				if (Input.GetKey (KeyCode.LeftShift) || run) {
					anim.Play ("run");
					moveSpeed = runSpeed;
				} 
				else if (Input.GetKey ("space") || attack) {
					anim.Play ("attack");
				} 
				else {
					anim.Play ("walk");
					moveSpeed = walkSpeed;
				}
				currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
				currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
				transform.position = currentLocation;
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
			} else if ((Input.GetKey ("s") && Input.GetKey ("d"))||(walk<0&&turn==1)) {
				if (Input.GetKey (KeyCode.LeftShift) || run) {
					anim.Play ("run");
					moveSpeed = runSpeed;
				} 
				else if (Input.GetKey ("space") || attack) {
					anim.Play ("attack");
				} 
				else {
					anim.Play ("walk");
					moveSpeed = walkSpeed;
				}
				currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
				currentLocation.x += moveSpeed * Time.fixedDeltaTime;
				transform.position = currentLocation;
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
			} else if ((walk==1&&(turn<1&&turn>-1))||Input.GetKey ("w")) {
				if (Input.GetKey (KeyCode.LeftShift) || run) {
					anim.Play ("run");
					moveSpeed = runSpeed;
				} 
				else if (Input.GetKey ("space") || attack) {
					anim.Play ("attack");
				} 
				else {
					anim.Play ("walk");
					moveSpeed = walkSpeed;
				}
				currentLocation.z += moveSpeed * Time.fixedDeltaTime;
				transform.position = currentLocation;
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
			} else if (Input.GetKey ("space") || attack) {
				anim.Play ("attack");
			}  else {
				anim.Play ("idle");

			}
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

	void Update () {

		previousLocation = currentLocation;    
		currentLocation = transform.position;
		checkAction ();
		walk = ControlFreak2.CF2Input.GetAxis ("Vertical");
		turn = ControlFreak2.CF2Input.GetAxis ("Horizontal");
		attack = ControlFreak2.CF2Input.GetKey ("Space");
		run = ControlFreak2.CF2Input.GetKey ("Left Shift");

		/*Debug.Log("walk: "+walk);
		Debug.Log("turn: "+turn);*/
        //		Debug.Log("run: "+run);

        //		transform.Translate (0, 0, walk * Time.deltaTime);
        //		transform.Rotate(0, turn*rotationSpeed,0);
        //		transform.Translate(new Vector3 (turn, 0, walk) * Time.deltaTime * 3);

    }

}
