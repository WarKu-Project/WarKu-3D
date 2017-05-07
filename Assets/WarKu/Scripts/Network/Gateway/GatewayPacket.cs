using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatewayPacket : PacketManager {

    #region id
    private enum PacketId
    {
        C_LOGIN = 10000,

        S_NOTIFY_LOGIN_SUCCESS = 20000,
        S_NOTIFY_DUPLICATE_LOGIN = 20001
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
    private void PacketMapper()
    {
        _Mapper[(int)PacketId.S_NOTIFY_LOGIN_SUCCESS] = OnLoginSuccess;
        _Mapper[(int)PacketId.S_NOTIFY_DUPLICATE_LOGIN] = OnDuplicateLogin;
    }
    #endregion

    #region authentication
    public void Login(string name)
    {
        PacketWriter pw = BeginSend((int)PacketId.C_LOGIN);
        pw.WriteString(name);
        EndSend();
    }

    public void OnLoginSuccess(int id,PacketReader pr)
    {
        string username = pr.ReadString();
        remote.OnLoginSuccess(username);
    }

    public void OnDuplicateLogin(int id,PacketReader pr)
    {
        string username = pr.ReadString();
        remote.OnDuplicateLogin(username);
    }
    #endregion
}
