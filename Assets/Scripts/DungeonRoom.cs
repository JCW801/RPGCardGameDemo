﻿using System;
using System.Collections.Generic;
using System.Linq;

public abstract class DungeonRoom
{
    /// <summary>
    /// 房间深度
    /// </summary>
    public int RoomDepth { get; private set; }

    /// <summary>
    /// 房间在对应深度的编号
    /// </summary>
    public int RoomIndex { get; private set; }

    /// <summary>
    /// 是否连接下一层左房间
    /// </summary>
    public bool HasNextLeftRoom { get; private set; }

    /// <summary>
    /// 是否连接下一层中房间
    /// </summary>
    public bool HasNextMiddleRoom { get; private set; }

    /// <summary>
    /// 是否连接下一层右房间
    /// </summary>
    public bool HasNextRightRoom { get; private set; }

    public void SetRoom(DungeonRoomTransferModel dungeonRoom)
    {
        RoomDepth = dungeonRoom.RoomDepth;
        RoomIndex = dungeonRoom.RoomIndex;
        HasNextLeftRoom = dungeonRoom.HasNextLeftRoom;
        HasNextMiddleRoom = dungeonRoom.HasNextMiddleRoom;
        HasNextRightRoom = dungeonRoom.HasNextRightRoom;
    }
}