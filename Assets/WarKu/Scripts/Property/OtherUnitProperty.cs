using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherUnitProperty : MonoBehaviour {

    public string action, uid, name;
    Vector3 next;

	// Use this for initialization
	void Start () {
        next = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, next, Time.deltaTime * 3);
	}

    public void UpdatePosition(float x,float y,float r,string action)
    {
        next = new Vector3(x, 0, y);
    }
}
