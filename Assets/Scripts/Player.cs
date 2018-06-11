﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player
{
    /// <summary>
    /// 玩家名称
    /// </summary>
    public string PlayerName { get; set; }

    /// <summary>
    /// 玩家持有的英雄及其卡牌数量
    /// </summary>
    public Dictionary<Hero,Dictionary<PlayableCard,int>> PlayerHeroAndCardDic { get; set; }

    /// <summary>
    /// 玩家进入副本后的信息
    /// </summary>
    public CardPlayer CardPlayer { get; set; }
}