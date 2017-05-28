using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SwitchToSelectTeam());
    }

    IEnumerator SwitchToSelectTeam()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        GameObject.FindObjectOfType<Property>().select.SetActive(true);
        GameObject.FindObjectOfType<Property>().select.GetComponent<Animator>().SetTrigger("InitSelect");
    }   
}