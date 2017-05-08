using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPacket : PacketManager {

    #region id
    private enum PacketId
    {
        UPDATE_TIME = 20000,
        UPDATE_GAME_STATE = 20001
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
        _Mapper[(int)PacketId.UPDATE_TIME] = OnUpdateTime;
        _Mapper[(int)PacketId.UPDATE_GAME_STATE] = OnUpdateState;
    }
    #endregion

    void OnUpdateTime(int id,PacketReader pr)
    {
        int time = pr.ReadUInt16();
        remote.UpdateTime(time);
    }

    void OnUpdateState(int id, PacketReader pr)
    {

    }
}
