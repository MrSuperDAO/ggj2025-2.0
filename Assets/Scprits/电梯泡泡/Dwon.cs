using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dwon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject upGameObject;
    public Vector3 targetPosition; // 目标位置
    public float speed = 1.0f; // 移动速度
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!upGameObject.activeSelf)
        {
            Debug.Log("上面的为非激活状态");
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
