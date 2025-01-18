using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DataController : MonoBehaviour
{
    public static DataController Instance { get; private set; }
    public int time;//使用时间
    public int dides;//死亡次数
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        Timming();
    }
    //public float duration = 5.0f; // 计时器的总时长
    private float elapsedTime = 0.0f; // 已经过去的时间
    public void Timming()
    {
        elapsedTime += Time.deltaTime; // 每帧增加 deltaTime

        /*
       if (elapsedTime >= duration)
          {
              Debug.Log("计时结束");
              // 在这里执行计时结束后的操作
              elapsedTime = 0.0f; // 重置计时器
          }
        */
        time =(int) elapsedTime;

    }
}