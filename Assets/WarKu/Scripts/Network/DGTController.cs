using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGTController : MonoBehaviour {

    GatewayRemote gatewayRemote;
    WorldRemote worldRemote;
    CombatRemote combatRemote;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ConnectToServer());
    }

    // Update is called once per frame
    void Update()
    {
        if (gatewayRemote)
            gatewayRemote.ProcessEvents();
        if (worldRemote)
            worldRemote.ProcessEvents();
        if (combatRemote)
            combatRemote.ProcessEvents();
    }

    #region Gateway
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
    #endregion

    public IEnumerator ConnectToGame(int worldPort,int combatPort,int positionPort,int statisticPort)
    {
        worldRemote = WorldRemote.GetInstance();
        worldRemote.Connect("localhost", worldPort);
        worldRemote.ProcessEvents();
        combatRemote = CombatRemote.GetInstance();
        combatRemote.Connect("localhost", combatPort);
        combatRemote.ProcessEvents();
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < 10; i++)
        {
            if (worldRemote.IsConnected() || worldRemote.IsConnectionFailed()) break;
            if (combatRemote.IsConnected() || combatRemote.IsConnectionFailed()) break;
            worldRemote.ProcessEvents();
            combatRemote.ProcessEvents();
            yield return new WaitForSeconds(0.1f);
        }
        if (worldRemote.IsConnected()&& combatRemote.IsConnected())
        {
            Debug.Log("Connection Success");
        }
        else
        {
            Debug.Log("Connection Fail");
        }
        yield break;
    }

    private void OnApplicationQuit()
    {
        if (gatewayRemote)
            gatewayRemote.Disconnect();
        if (worldRemote)
            worldRemote.Disconnect();
        if (combatRemote)
            combatRemote.Disconnect();
    }
}
