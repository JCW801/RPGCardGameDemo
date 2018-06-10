﻿using System;
using System.Collections.Generic;
using System.Linq;

public abstract class PlayableCard : Card
{
    /// <summary>
    /// 默认卡牌魔法消耗
    /// </summary>
    public int DefaultManaCost { get; set; }
    /// <summary>
    /// 当前卡牌魔法消耗
    /// </summary>
    public int CurrentManaCost { get; private set; }

    /// <summary>
    /// 卡牌效果
    /// </summary>
    public Effect[] CardEffects { get; set; }

    /// <summary>
    /// 打出卡牌
    /// </summary>
    /// <param name="targets"></param>
    public void PlayCard(ICollection<CardHolder> targets)
    {
        foreach (var item in CardEffects)
        {
            item.Invoke(Owner,targets);
        }
    }
}