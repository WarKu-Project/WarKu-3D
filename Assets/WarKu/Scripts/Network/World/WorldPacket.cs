using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPacket : PacketManager {

    #region id
    private enum PacketId
    {
        CLIENT_REQUEST_GAME_STATE = 10000,

        SERVER_NOTIFY_STATE_CHANGE = 21000,
        SERVER_UPDATE_TIME = 22000
    }
    #endregion

    #region initialize
    private WorldRemote remote;

    public WorldPacket(WorldRemote remote) : base()
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
        _Mapper[(int)PacketId.SERVER_NOTIFY_STATE_CHANGE] = OnUpdateState;
        _Mapper[(int)PacketId.SERVER_UPDATE_TIME] = OnUpdateTime;
    }
    #endregion

    #region world update
    /**
     * Request Update State
     **/
     public void RequestUpdateState()
    {
        PacketWriter pw = BeginSend((int)PacketId.CLIENT_REQUEST_GAME_STATE);
        EndSend();
    }
    /**
     * Update Game State
     **/
     public void OnUpdateState(int id,PacketReader pr)
    {
        string state = pr.ReadString();
        Debug.Log(state);
    }
    /**
     * Update Time
     **/
    public void OnUpdateTime(int id,PacketReader pr)
    {
        int time = pr.ReadUInt16();
        Debug.Log(time);
    }
    #endregion
}
