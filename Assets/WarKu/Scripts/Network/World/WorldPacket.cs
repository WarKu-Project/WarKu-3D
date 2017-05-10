using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPacket : PacketManager {

    #region id
    private enum PacketId
    {

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
        
    }
    #endregion

}
