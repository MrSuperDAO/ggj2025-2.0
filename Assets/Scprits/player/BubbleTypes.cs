using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum BubbleType
    {
        Normal,         // 普通泡泡
        StrongJump,     // 跳跃力更大的泡泡
        OneTime,        // 戳破一次不能重生的泡泡
        Movable         // 可以被其它泡泡爆破而吹动的泡泡
    }
