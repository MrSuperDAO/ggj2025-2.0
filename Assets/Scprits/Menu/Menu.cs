using UnityEngine;
using UnityEngine.EventSystems;  // 引入EventSystems命名空间

public class Menu : MonoBehaviour
{
    private RectTransform rectTransform;  // UI元素的RectTransform

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // 获取鼠标在屏幕空间中的位置
        Vector3 mousePosition = Input.mousePosition;

        // 将UI元素的中心位置转换为屏幕空间中的位置
        Vector3 uiPosition = rectTransform.position;
        uiPosition.z = Camera.main.WorldToScreenPoint(uiPosition).z;  // 确保Z值正确

        // 计算从UI元素中心到鼠标位置的方向向量
        Vector3 direction = mousePosition - uiPosition;

        // 计算旋转角度
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 设置UI元素的旋转，使其面向鼠标位置
        rectTransform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }
}