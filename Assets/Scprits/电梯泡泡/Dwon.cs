using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dwon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject upGameObject;
    public Vector3 targetPosition; // Ŀ��λ��
    public float speed = 1.0f; // �ƶ��ٶ�
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!upGameObject.activeSelf)
        {
            Debug.Log("�����Ϊ�Ǽ���״̬");
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
