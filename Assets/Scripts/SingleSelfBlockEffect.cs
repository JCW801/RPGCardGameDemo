﻿using System;
using System.Collections.Generic;

public class SingleSelfBlockEffect : BlockEffect
{
    public override void Invoke(CardHolder executor, ICollection<CardHolder> targets)
    {
        executor.GainBlock(BlockValue);
    }
}