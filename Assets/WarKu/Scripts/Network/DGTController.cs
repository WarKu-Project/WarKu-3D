using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGTController : MonoBehaviour {

    GatewayRemote gatewayRemote;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ConnectToServer());
    }

    // Update is called once per frame
    void Update()
    {
        gatewayRemote.ProcessEvents();
    }

    IEnumerator ConnectToServer()
    {
        gatewayRemote = GatewayRemote.GetInstance();
        gatewayRemote.Connect("localhost", 1000);
        gatewayRemote.ProcessEvents();
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < 10; i++)
        {
            if (gatewayRemote.IsConnected() || gatewayRemote.IsConnectionFailed()) break;
            gatewayRemote.ProcessEvents();
            yield return new WaitForSeconds(0.1f);
        }
        if (gatewayRemote.IsConnected())
        {
            Debug.Log("Connection Success");
            gatewayRemote.Login("Reii");
        }
        else
        {
            Debug.Log("Connection Fail");
        }
        yield break;
    }

    private void OnApplicationQuit()
    {
        gatewayRemote.Disconnect();
    }
}
