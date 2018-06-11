using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Relics
{
    /// <summary>
    /// 圣物名称
    /// </summary>
    public String RelicsName { get; set; }

    /// <summary>
    /// 圣物图片文件名
    /// </summary>
    public String RelicsSpriteName { get; set; }

    /// <summary>
    /// 圣物效果
    /// </summary>
    public Effect RelicsEffect { get; set; }
}