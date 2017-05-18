using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatewayPacket : PacketManager {

    #region id
    private enum PacketId
    {
        CLIENT_REQUEST_AUTHENTICATION = 10000,

        SERVER_RESPONSE_AUTHENTICATION_SUCCESSFUL = 20000,
        SERVER_RESPONSE_DUPLICATE_AUTHENTICATION = 20001
    }
    #endregion

    #region initialize
    private GatewayRemote remote;

    public GatewayPacket(GatewayRemote remote) : base()
    {
        this.remote = remote;
        PacketMapper();
    }
    #endregion

    #region connection
    protected override void OnConnected()
    {
        remote.OnConnected();
    }

    protected override void OnDisconnected()
    {
        remote.OnDisconnected();
        Debug.Log("Bye");
    }

    protected override void OnFailed()
    {
        remote.OnFailed();
    }
    #endregion

    #region packet mapper
    void PacketMapper()
    {
        _Mapper[(int)PacketId.SERVER_RESPONSE_AUTHENTICATION_SUCCESSFUL] = OnAuthenticationSuccessful;
        _Mapper[(int)PacketId.SERVER_RESPONSE_DUPLICATE_AUTHENTICATION] = OnDuplicateAuthentication;
    }
    #endregion

    #region authentication
    /**
     *  Authentication Request
     **/
     public void RequestAuthentication(string username)
    {
        PacketWriter pw = BeginSend((int)PacketId.CLIENT_REQUEST_AUTHENTICATION);
        pw.WriteString(username);
        EndSend();
    }
    /**
     * Receive Authentication Successful Response from Server
     **/
     public void OnAuthenticationSuccessful(int id,PacketReader pr)
    {
        string username = pr.ReadString();
        int worldPort = pr.ReadUInt16();
        int combatPort = pr.ReadUInt16();
        int positionport = pr.ReadUInt16();
        int statisticPort = pr.ReadUInt16();
        remote.OnAuthenticationSuccessful(worldPort,combatPort,positionport,statisticPort);
    }
    /**
     * Receive Duplicate Authentication from server
     **/
    public void OnDuplicateAuthentication(int id,PacketReader pr)
    {
        remote.OnDuplicateAuthentication();
    }
    #endregion
}
