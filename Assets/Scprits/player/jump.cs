using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{

    public LayerMask groundLayerMask_1;
    public LayerMask groundLayerMask_2;
    public LayerMask groundLayerMask_3;
    public LayerMask groundLayerMask_4;

    // 声明 OnGround 变量
    public bool OnGround = false;

    void OnTriggerStay2D(Collider2D other)
    {
        // 重置 OnGround 变量，假设最初没有接触
        OnGround = false;

        // 检查碰撞体是否在任何一个 groundLayerMask 中
        if ((groundLayerMask_1 & (1 << other.gameObject.layer)) != 0 ||
            (groundLayerMask_2 & (1 << other.gameObject.layer)) != 0 ||
            (groundLayerMask_3 & (1 << other.gameObject.layer)) != 0 ||
            (groundLayerMask_4 & (1 << other.gameObject.layer)) != 0)
        {
            // 物体与某个感兴趣的层的碰撞体接触
            OnGround = true;
            // 在这里添加你的逻辑，比如设置 CanJumpTwice 为 true
        }
        // 注意：不需要 else 分支来设置 OnGround = false，因为我们已经在开始时重置了它
    }
}
