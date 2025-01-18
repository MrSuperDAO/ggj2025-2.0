using UnityEngine;
using UnityEngine.EventSystems;  // ����EventSystems�����ռ�

public class Menu : MonoBehaviour
{
    private RectTransform rectTransform;  // UIԪ�ص�RectTransform

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // ��ȡ�������Ļ�ռ��е�λ��
        Vector3 mousePosition = Input.mousePosition;

        // ��UIԪ�ص�����λ��ת��Ϊ��Ļ�ռ��е�λ��
        Vector3 uiPosition = rectTransform.position;
        uiPosition.z = Camera.main.WorldToScreenPoint(uiPosition).z;  // ȷ��Zֵ��ȷ

        // �����UIԪ�����ĵ����λ�õķ�������
        Vector3 direction = mousePosition - uiPosition;

        // ������ת�Ƕ�
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ����UIԪ�ص���ת��ʹ���������λ��
        rectTransform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }
}