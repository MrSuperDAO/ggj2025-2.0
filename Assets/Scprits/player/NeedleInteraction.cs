using UnityEngine;

public class NeedleInteraction : MonoBehaviour
{
    // ��ҵĸ������������ʩ����
    public Rigidbody2D playerRigidbody;
    // Ŀ��������ڵ�ͼ������
    public LayerMask targetLayerMask;
    // ʩ�ӵ�������С
    public float pushForce = 5.0f;
    // ����Ͷ��ĳ���
    public float raycastLength = 0.1f;

    void Update()
    {
        // ��ȡ���������ռ��е�λ��
        Vector2 needleTipPosition = (Vector2)transform.position + (Vector2)transform.up * 0.5f;

        // ���������Լ������·��Ƿ���Ŀ�����
        RaycastHit2D hit = Physics2D.Raycast(needleTipPosition, -Vector2.up, raycastLength, targetLayerMask);

        // ����Ƿ������Ŀ����󣬲�����Ұ�����������
        if (hit.collider != null && hit.collider.CompareTag("Target") && Input.GetMouseButtonDown(0))
        {
            // ����Ŀ�����
            Destroy(hit.collider.gameObject);

            // �����ʩ��һ�����ϵ�����
            playerRigidbody.AddForce(-Vector2.up * pushForce, ForceMode2D.Impulse);
        }
    }
}