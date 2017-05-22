using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {

	/**
     * Retry Connection
     **/
     public void Reconnect()
    {
        Destroy(GameObject.Find("NetworkManager"));
        SceneManager.LoadScene(0);
    }
}
