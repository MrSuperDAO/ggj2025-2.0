using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventMediator : MonoBehaviour
{
    public GameObject targetGameObject; 
    public string methodName; 

    // 动画事件回调
    public void OnAnimationEvent()
    {
        if (targetGameObject != null && !string.IsNullOrEmpty(methodName))
        {
            targetGameObject.GetComponent<RotateTowardsMouse>().StopParticles(gameObject);
        }
    }
}
