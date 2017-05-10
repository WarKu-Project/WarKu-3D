using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGTController : MonoBehaviour {

    #region constant
    /**
     * @HOST host of Server
     * @PORT port of Gateway Server
     **/
    const string HOST = "localhost";
    const int PORT = 1000;
    #endregion

    #region remotes
    /**
     * Remotes as attributes for DRY purpose
     **/ 
    GatewayRemote gatewayRemote;
    WorldRemote worldRemote;
    #endregion

    #region attribute
    /**
     * PORT of Game core server
     * Index | Server
     * 0 | World Server
     * 1 | Combat Server
     * 2 | Position Server
     * 3 | Statistic Server
     **/
    int[] progressPort = { 0, 0, 0, 0 };
    #endregion

    #region unity method
    // Use this for initialization
    void Start()
    {
        InitializeRemotes();
        StartCoroutine(ConnectToGateway());
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRemote();
    }
    
    // Call when exit application
    void OnApplicationQuit()
    {
        gatewayRemote.Disconnect();
        worldRemote.Disconnect();
    }
    #endregion

    #region remote processing method
    /**
     * Assign Remotes to Attributes for DRY purpose
     **/
    void InitializeRemotes()
    {
        gatewayRemote = GatewayRemote.GetInstance();
        worldRemote = WorldRemote.GetInstance();
    }

    /**
     * Process Event for each remotes
     **/
    void ProcessRemote()
    {
        gatewayRemote.ProcessEvents();
        worldRemote.ProcessEvents();
    }
    #endregion

    #region connection
    /**
     * Connect to Gateway Server
     **/
    IEnumerator ConnectToGateway()
    {
        //Start Connection to Gateway server at HOST : PORT
        gatewayRemote.Connect(HOST, PORT);
        
        // Try to connect atmost 10 times
        for (int i = 0; i < 10; i++)
        {
            if (gatewayRemote.IsConnected() || gatewayRemote.IsConnectionFailed()) break;
            gatewayRemote.ProcessEvents();
            yield return new WaitForSeconds(0.5f);
        }

        // Connection Success / Not
        gatewayRemote.CheckConnection();
        yield break;
    }
    /**
     * Connect to World Server
     **/
    IEnumerator ConnectToWorld()
    {
        //Start Connection to Wordl server at HOST : PORT
        worldRemote.Connect(HOST, progressPort[0]);

        // Try to connect atmost 10 times
        for (int i = 0; i < 10; i++)
        {
            if (worldRemote.IsConnected() || worldRemote.IsConnectionFailed()) break;
            worldRemote.ProcessEvents();
            yield return new WaitForSeconds(0.5f);
        }

        // Connection Success / Not
        worldRemote.CheckConnection();
        yield break;
    }
    #endregion

    #region port manager
    public void AssignPort(int worldPort,int combatPort,int positionPort,int statisticPort)
    {
        progressPort = new int[] { worldPort, combatPort, positionPort, statisticPort };
    }
    #endregion
}
