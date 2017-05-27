using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : MonoBehaviour {

    public GameObject select;

    int color;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectTeam(int color)
    {
        this.color = color;
        InitPlayer();
    }

    void InitPlayer()
    {
        float x = 100;
        float y = 100;
        if (color == 1)
        {
            x = Random.Range(100, 400);
            y = Random.Range(100, 150);
        }else if (color == 2){
            x = Random.Range(100, 150);
            y = Random.Range(100, 400);
        }
        else if (color == 3)
        {
            x = Random.Range(350, 400);
            y = Random.Range(100, 400);
        }
        else if (color == 4)
        {
            x = Random.Range(100, 400);
            y = Random.Range(350, 400);
        }
        select.SetActive(false);
    }
}
