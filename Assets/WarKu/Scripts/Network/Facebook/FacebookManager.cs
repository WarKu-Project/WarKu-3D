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
            if (FB.IsLoggedIn)
            {

            }else
            {
                Login();
            }
        }
    }

    void InitCallBack()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();

            Debug.Log("Success");
            fbCon.SetActive(false);
            Login();
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
    
    void Login()
    {
        var perms = new List<string>() { "public_profile", "email" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }

    void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            Debug.Log(aToken.TokenString);
            GetComponent<FirebaseManager>().AuthWithFB(aToken.TokenString);
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }
}
