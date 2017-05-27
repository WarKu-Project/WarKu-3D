using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;

public class FirebaseAuth : MonoBehaviour {

    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

    public GameObject con,select;

    void Awake()
    {
        InitializeFirebase();
    }

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Application.Quit();
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                FirebaseApp.DefaultInstance.SetEditorAuthUserId(Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.UserId);
                StartCoroutine(StartSelection());
            }
        }
    }

    public void AuthWithFB(string token)
    {
        con.SetActive(true);
        con.GetComponentInChildren<Text>().text = "Authenticating to Firebase Server";
        con.GetComponent<Animator>().SetTrigger("Start");
        Firebase.Auth.Credential credential =
        Firebase.Auth.FacebookAuthProvider.GetCredential(token);
        auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                Application.Quit();
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                Application.Quit();
                return;
            }
        });
    }

    IEnumerator StartSelection()
    {
        con.GetComponent<Animator>().SetTrigger("End");
        yield return new WaitForSeconds(0.9f);
        select.SetActive(true);
        con.SetActive(false);
        yield break;
    }
}
