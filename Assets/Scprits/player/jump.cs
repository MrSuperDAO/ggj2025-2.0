using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{

    public LayerMask groundLayerMask_1;
    public LayerMask groundLayerMask_2;
    public LayerMask groundLayerMask_3;
    public LayerMask groundLayerMask_4;

    // ���� OnGround ����
    public bool OnGround = false;

    void OnTriggerStay2D(Collider2D other)
    {
        // ���� OnGround �������������û�нӴ�
        OnGround = false;

        // �����ײ���Ƿ����κ�һ�� groundLayerMask ��
        if ((groundLayerMask_1 & (1 << other.gameObject.layer)) != 0 ||
            (groundLayerMask_2 & (1 << other.gameObject.layer)) != 0 ||
            (groundLayerMask_3 & (1 << other.gameObject.layer)) != 0 ||
            (groundLayerMask_4 & (1 << other.gameObject.layer)) != 0)
        {
            // ������ĳ������Ȥ�Ĳ����ײ��Ӵ�
            OnGround = true;
            // �������������߼����������� CanJumpTwice Ϊ true
        }
        // ע�⣺����Ҫ else ��֧������ OnGround = false����Ϊ�����Ѿ��ڿ�ʼʱ��������
    }
}
