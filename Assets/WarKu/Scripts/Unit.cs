using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public int speed;
    Vector3 target;
    Quaternion targetR;

	// Use this for initialization
	void Start () {
        target = new Vector3(transform.position.x,transform.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime*speed);
//        transform.rotation = Quaternion.Lerp(transform.rotation, targetR, Time.deltaTime * speed);
    }

    public void Move(float x, float y, float r)
    {
        target = new Vector3(x,0, y);
        Debug.Log(x + " " + y);
       // targetR = Quaternion.AngleAxis(r,Vector3.up);
    }
}
