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
	GameObject player;
	public float walk, turn;
	public bool attack, run;
    private bool death;
    public Score score;
    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator> ();
		death = false;
	}

	float getAttackDamage() {
		return attackDamage;
	}

	public void deathAction(){
		death = true;
	}

    void checkAction() {
        if (death) {
            GetComponent<PlayerUnitProperty>().action = "death";
            anim.Play("death");
        } else {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack")) {
                if ((turn == -1 && (walk < 0.3 && walk > -0.3)) || Input.GetKey("a")) {
                    if (Input.GetKey(KeyCode.LeftShift) || run) {
                        GetComponent<PlayerUnitProperty>().action = "run";
                        anim.Play("run");
                        moveSpeed = runSpeed;
                    }
                    else if (Input.GetKey("space") || attack) {
                        GetComponent<PlayerUnitProperty>().action = "attack";
                        anim.Play("attack");
                    }
                    else {
                        GetComponent<PlayerUnitProperty>().action = "walk";
                        anim.Play("walk");
                        moveSpeed = walkSpeed;
                    }
                    currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
                    transform.position = currentLocation;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
                } else if ((walk == -1 && (turn < 1 && turn > -1)) || Input.GetKey("s")) {
                    if (Input.GetKey(KeyCode.LeftShift) || run) {
                        GetComponent<PlayerUnitProperty>().action = "run";
                        anim.Play("run");
                        moveSpeed = runSpeed;
                    }
                    else if (Input.GetKey("space") || attack) {
                        GetComponent<PlayerUnitProperty>().action = "attack";
                        anim.Play("attack");
                    }
                    else {
                        GetComponent<PlayerUnitProperty>().action = "walk";
                        anim.Play("walk");
                        moveSpeed = walkSpeed;
                    }
                    currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
                    transform.position = currentLocation;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
                } else if ((turn == 1 && (walk < 0.3 && walk > -0.3)) || Input.GetKey("d")) {
                    if (Input.GetKey(KeyCode.LeftShift) || run) {
                        GetComponent<PlayerUnitProperty>().action = "run";
                        anim.Play("run");
                        moveSpeed = runSpeed;
                    }
                    else if (Input.GetKey("space") || attack) {
                        GetComponent<PlayerUnitProperty>().action = "attack";
                        anim.Play("attack");
                    }
                    else {
                        GetComponent<PlayerUnitProperty>().action = "walk";
                        anim.Play("walk");
                        moveSpeed = walkSpeed;
                    }
                    currentLocation.x += moveSpeed * Time.fixedDeltaTime;
                    transform.position = currentLocation;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
                }
                else if ((Input.GetKey("w") && Input.GetKey("a")) || (walk > 0 && turn == -1)) {
                    if (Input.GetKey(KeyCode.LeftShift) || run) {
                        GetComponent<PlayerUnitProperty>().action = "run";
                        anim.Play("run");
                        moveSpeed = runSpeed;
                    }
                    else if (Input.GetKey("space") || attack) {
                        GetComponent<PlayerUnitProperty>().action = "attack";
                        anim.Play("attack");
                    }
                    else {
                        GetComponent<PlayerUnitProperty>().action = "walk";
                        anim.Play("walk");
                        moveSpeed = walkSpeed;
                    }
                    currentLocation.z += moveSpeed * Time.fixedDeltaTime;
                    currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
                    transform.position = currentLocation;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
                } else if ((Input.GetKey("w") && Input.GetKey("d")) || (walk > 0 && turn == 1)) {
                    if (Input.GetKey(KeyCode.LeftShift) || run) {
                        GetComponent<PlayerUnitProperty>().action = "run";
                        anim.Play("run");
                        moveSpeed = runSpeed;
                    }
                    else if (Input.GetKey("space") || attack) {
                        GetComponent<PlayerUnitProperty>().action = "attack";
                        anim.Play("attack");
                    }
                    else {
                        GetComponent<PlayerUnitProperty>().action = "walk";
                        anim.Play("walk");
                        moveSpeed = walkSpeed;
                    }
                    currentLocation.z += moveSpeed * Time.fixedDeltaTime;
                    currentLocation.x += moveSpeed * Time.fixedDeltaTime;
                    transform.position = currentLocation;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
                } else if ((Input.GetKey("a") && Input.GetKey("s")) || (walk < 0 && turn == -1)) {
                    if (Input.GetKey(KeyCode.LeftShift) || run) {
                        GetComponent<PlayerUnitProperty>().action = "run";
                        anim.Play("run");
                        moveSpeed = runSpeed;
                    }
                    else if (Input.GetKey("space") || attack) {
                        GetComponent<PlayerUnitProperty>().action = "attack";
                        anim.Play("attack");
                    }
                    else {
                        GetComponent<PlayerUnitProperty>().action = "walk";
                        anim.Play("walk");
                        moveSpeed = walkSpeed;
                    }
                    currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
                    currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
                    transform.position = currentLocation;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
                } else if ((Input.GetKey("s") && Input.GetKey("d")) || (walk < 0 && turn == 1)) {
                    if (Input.GetKey(KeyCode.LeftShift) || run) {
                        GetComponent<PlayerUnitProperty>().action = "run";
                        anim.Play("run");
                        moveSpeed = runSpeed;
                    }
                    else if (Input.GetKey("space") || attack) {
                        GetComponent<PlayerUnitProperty>().action = "attack";
                        anim.Play("attack");
                    }
                    else {
                        GetComponent<PlayerUnitProperty>().action = "walk";
                        anim.Play("walk");
                        moveSpeed = walkSpeed;
                    }
                    currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
                    currentLocation.x += moveSpeed * Time.fixedDeltaTime;
                    transform.position = currentLocation;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
                } else if ((walk == 1 && (turn < 1 && turn > -1)) || Input.GetKey("w")) {
                    if (Input.GetKey(KeyCode.LeftShift) || run) {
                        GetComponent<PlayerUnitProperty>().action = "run";
                        anim.Play("run");
                        moveSpeed = runSpeed;
                    }
                    else if (Input.GetKey("space") || attack) {
                        GetComponent<PlayerUnitProperty>().action = "attack";
                        anim.Play("attack");
                    }
                    else {
                        GetComponent<PlayerUnitProperty>().action = "walk";
                        anim.Play("walk");
                        moveSpeed = walkSpeed;
                    }
                    currentLocation.z += moveSpeed * Time.fixedDeltaTime;
                    transform.position = currentLocation;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - previousLocation), Time.fixedDeltaTime * rotationSpeed);
                } else if (Input.GetKey("space") || attack) {
                    GetComponent<PlayerUnitProperty>().action = "attack";
                    anim.Play("attack");
                } else {
                    GetComponent<PlayerUnitProperty>().action = "idle";
                    anim.Play("idle");

                }
            }
            else {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack")) {
                    if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) {
                        GetComponent<PlayerUnitProperty>().action = "idle";
                        anim.Play("idle");
                    }
                } else {
                    GetComponent<PlayerUnitProperty>().action = "idle";
                    anim.Play("idle");

                }
            }

        }
    }
    void Update()
    {

        previousLocation = currentLocation;
        currentLocation = transform.position;
        score.setCurrentLocation(currentLocation);
        checkAction();
        walk = ControlFreak2.CF2Input.GetAxis("Vertical");
        turn = ControlFreak2.CF2Input.GetAxis("Horizontal");
        attack = ControlFreak2.CF2Input.GetKey("Space");
        run = ControlFreak2.CF2Input.GetKey("Left Shift");

    }
}
