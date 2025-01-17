using UnityEngine;

public class NeedleRotation : MonoBehaviour
{
    // 玩家对象，用于确定圆心位置
    public Transform playerTransform;
    // 圆的半径，针尖将围绕这个半径旋转
    public float radius = 3.0f;
    // 旋转速度，控制针尖跟随鼠标的速度
    public float rotationSpeed = 100.0f;

    // 存储当前针尖的角度（以度为单位）
    private float currentAngle;

    void Start()
    {
        // 初始化角度为0
        currentAngle = 0.0f;
    }

    void Update()
    {
        // 将鼠标位置从屏幕坐标转换为世界坐标
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePositionWorld.z = playerTransform.position.z; // 确保z坐标与玩家相同（在2D游戏中通常为0）

        // 计算从玩家到鼠标的方向向量
        Vector2 directionToMouse = (Vector2)(mousePositionWorld - playerTransform.position);

        // 计算该方向向量的角度
        float angleToMouse = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

        // 确保角度
        if (angleToMouse < 0)
        {
            angleToMouse += 360.0f;
        }

        // 平滑旋转
        currentAngle = Mathf.LerpAngle(currentAngle, angleToMouse, Time.deltaTime * rotationSpeed);

        // 计算针尖在世界空间中的位置
        Vector3 needleTipPosition = playerTransform.position + new Vector3(Mathf.Cos(currentAngle * Mathf.Deg2Rad), Mathf.Sin(currentAngle * Mathf.Deg2Rad), 0) * radius;

        // 设置针尖的位置和方向
        transform.position = needleTipPosition - transform.up * 0.5f; 
        transform.up = (needleTipPosition - (Vector3)transform.position).normalized;
    }
}