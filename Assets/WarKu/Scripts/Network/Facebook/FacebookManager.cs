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
            if (FB.IsLoggedIn)
            {
                StartCoroutine(ConnectToFirebase());
            }
            else
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
            Login();
        }
        else
        {
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
            StartCoroutine(ConnectToFirebase());
        }
        else
        {
            fbCon.GetComponentInChildren<Text>().text = "Login is cancelled";
            Application.Quit();
        }
    }

    IEnumerator ConnectToFirebase()
    {
        fbCon.GetComponent<Animator>().SetTrigger("End");
        yield return new WaitForSeconds(1);
        fbCon.SetActive(false);
        GetComponent<FirebaseManager>().AuthWithFB(Facebook.Unity.AccessToken.CurrentAccessToken.TokenString);
        yield break;
    }
}
