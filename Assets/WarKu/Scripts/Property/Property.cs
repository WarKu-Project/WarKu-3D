using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : MonoBehaviour {

    public GameObject select,playerUnitPrefab,cf2,mainui;
    public Texture[] colors;
    public Camera playerCam, WorldCam;
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
        mainui.SetActive(false);
        cf2.SetActive(true);
        GameObject playerUnit = Instantiate(playerUnitPrefab, new Vector3(x, 0, y), Quaternion.identity);
        WorldCam.gameObject.SetActive(false);
        playerCam.GetComponent<CameraController>().player = playerUnit;
        playerCam.transform.position = new Vector3(playerUnit.transform.position.x,2.18f,playerUnit.transform.position.z-5);
        playerCam.gameObject.SetActive(true);
        playerUnit.transform.LookAt(new Vector3(250,0, 250));
        playerUnit.GetComponent<PlayerUnitProperty>().color = color;
        playerUnit.GetComponent<PlayerUnitProperty>().name = Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.DisplayName;

        playerUnit.GetComponentInChildren<SkinnedMeshRenderer>().material.mainTexture = colors[color - 1];
    }
}
