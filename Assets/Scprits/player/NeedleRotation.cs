using UnityEngine;

public class NeedleRotation : MonoBehaviour
{
    // ��Ҷ�������ȷ��Բ��λ��
    public Transform playerTransform;
    // Բ�İ뾶����⽫Χ������뾶��ת
    public float radius = 3.0f;
    // ��ת�ٶȣ����������������ٶ�
    public float rotationSpeed = 100.0f;

    // �洢��ǰ���ĽǶȣ��Զ�Ϊ��λ��
    private float currentAngle;

    void Start()
    {
        // ��ʼ���Ƕ�Ϊ0
        currentAngle = 0.0f;
    }

    void Update()
    {
        // �����λ�ô���Ļ����ת��Ϊ��������
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePositionWorld.z = playerTransform.position.z; // ȷ��z�����������ͬ����2D��Ϸ��ͨ��Ϊ0��

        // �������ҵ����ķ�������
        Vector2 directionToMouse = (Vector2)(mousePositionWorld - playerTransform.position);

        // ����÷��������ĽǶ�
        float angleToMouse = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

        // ȷ���Ƕ�
        if (angleToMouse < 0)
        {
            angleToMouse += 360.0f;
        }

        // ƽ����ת
        currentAngle = Mathf.LerpAngle(currentAngle, angleToMouse, Time.deltaTime * rotationSpeed);

        // �������������ռ��е�λ��
        Vector3 needleTipPosition = playerTransform.position + new Vector3(Mathf.Cos(currentAngle * Mathf.Deg2Rad), Mathf.Sin(currentAngle * Mathf.Deg2Rad), 0) * radius;

        // ��������λ�úͷ���
        transform.position = needleTipPosition - transform.up * 0.5f; 
        transform.up = (needleTipPosition - (Vector3)transform.position).normalized;
    }
}