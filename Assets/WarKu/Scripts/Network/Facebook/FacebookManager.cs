using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FacebookManager : MonoBehaviour {

    public GameObject fbCon;

    void Awake()
    {
        fbCon.SetActive(true);
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallBack, OnHideUnity);
        }
        else
        {
            FB.ActivateApp();
            fbCon.SetActive(false);
        }
    }

    void InitCallBack()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();

            Debug.Log("Success");
            fbCon.SetActive(false);
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
            fbCon.GetComponentInChildren<Text>().text = "Can't Connect to Facebook";
        }
    }

    void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
