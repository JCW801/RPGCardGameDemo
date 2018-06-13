﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameDictionary
{
    /// <summary>
    /// 游戏所有卡牌信息
    /// </summary>
    public Dictionary<string, CardTransferModel> CardDic { get; set; }

    /// <summary>
    /// 游戏所有英雄信息
    /// </summary>
    public Dictionary<string, Hero> HeroDic { get; set; }
}

