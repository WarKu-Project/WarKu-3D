using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPacket : PacketManager {

    #region id
    private enum PacketId
    {
        CLIENT_ASSIGN_POSITION_REQUEST = 10000,
        CLIENT_UPDATE_POSITION = 11000,
        CLIENT_CREATE_UNIT = 12000,

        SERVER_ASSIGN_POSITION = 20000,
        SERVER_RESPONSE_UNITS_IN_SIGHT = 21000,
        SERVER_RESPONSE_CREATE_UNIT_SUCCESS = 22000
    }
    #endregion

    #region initialize
    private PositionRemote remote;

    public PositionPacket(PositionRemote remote) : base()
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

    }
    #endregion

    #region position
    public void requestPosition(string username,string type)
    {
        PacketWriter pw = BeginSend((int)PacketId.CLIENT_ASSIGN_POSITION_REQUEST);
        pw.WriteString(username);
        pw.WriteString(type);
        EndSend();
    }

    #endregion
}
