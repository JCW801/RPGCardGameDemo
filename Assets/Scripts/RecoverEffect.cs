﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class RecoverEffect : Effect
{
    /// <summary>
    /// 生命回复值
    /// </summary>
    public int RecoverValue { get; set; }
}