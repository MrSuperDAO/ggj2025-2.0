using UnityEngine;

public class NeedleInteraction : MonoBehaviour
{
    // 玩家的刚体组件，用于施加力
    public Rigidbody2D playerRigidbody;
    // 目标对象所在的图层掩码
    public LayerMask targetLayerMask;
    // 施加的推力大小
    public float pushForce = 5.0f;
    // 射线投射的长度
    public float raycastLength = 0.1f;

    void Update()
    {
        // 获取针尖在世界空间中的位置
        Vector2 needleTipPosition = (Vector2)transform.position + (Vector2)transform.up * 0.5f;

        // 发射射线以检测针尖下方是否有目标对象
        RaycastHit2D hit = Physics2D.Raycast(needleTipPosition, -Vector2.up, raycastLength, targetLayerMask);

        // 检查是否击中了目标对象，并且玩家按下了鼠标左键
        if (hit.collider != null && hit.collider.CompareTag("Target") && Input.GetMouseButtonDown(0))
        {
            // 销毁目标对象
            Destroy(hit.collider.gameObject);

            // 对玩家施加一个向上的推力
            playerRigidbody.AddForce(-Vector2.up * pushForce, ForceMode2D.Impulse);
        }
    }
}