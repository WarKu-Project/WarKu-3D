using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUIHandler : MonoBehaviour {

    public GameObject StatusLoader,retryButton;

    public void ShowConnectionStatusUI(string text,bool isRetry)
    {
        if (isRetry) retryButton.SetActive(true);
        else retryButton.SetActive(false);
        StatusLoader.GetComponentInChildren<Text>().text = text;
        StatusLoader.GetComponentsInChildren<Animator>()[0].SetTrigger("Start");
        StatusLoader.GetComponentsInChildren<Animator>()[1].SetTrigger("Show");
        StatusLoader.SetActive(true);
    }

    public void StopConnectionStatusUI()
    {
        StatusLoader.GetComponentsInChildren<Animator>()[0].SetTrigger("Stop");
        StatusLoader.GetComponentsInChildren<Animator>()[1].SetTrigger("Hide");
    }

    public void HideStatusUI()
    {
        StatusLoader.SetActive(false);
    }
}
