using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DataController : MonoBehaviour
{
    public static DataController Instance { get; private set; }
    public int time;//ʹ��ʱ��
    public int dides;//��������
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
    //public float duration = 5.0f; // ��ʱ������ʱ��
    private float elapsedTime = 0.0f; // �Ѿ���ȥ��ʱ��
    public void Timming()
    {
        elapsedTime += Time.deltaTime; // ÿ֡���� deltaTime

        /*
       if (elapsedTime >= duration)
          {
              Debug.Log("��ʱ����");
              // ������ִ�м�ʱ������Ĳ���
              elapsedTime = 0.0f; // ���ü�ʱ��
          }
        */
        time =(int) elapsedTime;

    }
}