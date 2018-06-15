using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class BuffEffect : Effect
{
    public abstract void RemoveBuffEffect(CardHolder buffOwner);

    public override void SetEffect(List<string> list)
    {
    }
}