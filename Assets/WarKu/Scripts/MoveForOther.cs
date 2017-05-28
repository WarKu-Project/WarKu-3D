using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForOther : MonoBehaviour {

    Vector3 next;

	// Use this for initialization
	void Start () {
        next = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(float x,float y,float r,string action)
    {
        next = new Vector3(x, transform.position.y, y);
        GetComponent<Animator>().Play(action);
    }
}
