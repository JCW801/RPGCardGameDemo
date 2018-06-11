using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class MonsterDungeonRoom : DungeonRoom
{
    public Monster[] RoomMonster { get; set; }
}