using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EasilyInjuredBuffEffect : BuffEffect
{
    /// <summary>
    /// 易伤倍数
    /// </summary>
    public static Double Multiplier
    {
        get
        {
            return multiplier;
        }
        set
        {
            multiplier = value;
        }
    }
    private static Double multiplier = 1.5;

    public override void Invoke(CardHolder executor, ICollection<CardHolder> targets)
    {
        executor.PreTakeAttackEvent += EasilyInjured;
    }

    public override void RemoveBuffEffect(CardHolder buffHolder)
    {
        buffHolder.PreTakeAttackEvent -= EasilyInjured;
    }

    private void EasilyInjured(CardHolder ch1, CardHolder ch2, int damage)
    {
        damage = Convert.ToInt32(Math.Round(damage * Multiplier));
    }
}