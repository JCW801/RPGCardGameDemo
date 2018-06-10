﻿
using System.Collections.Generic;
using System;
using System.Linq;

public class SingleAttackEffect : Attackffect
{
    public override void Invoke(CardHolder executor, ICollection<CardHolder> targets)
    {
        if (targets != null && targets.Count == 1)
        {
            foreach (var item in Enumerable.Range(0,AttackTargetCount))
            {
                executor.Attack(targets.GetEnumerator().Current, AttackDamage);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}