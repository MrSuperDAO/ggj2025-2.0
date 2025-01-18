
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DataController : MonoBehaviour
{
    public static DataController Instance { get; private set; }
    public int time;
    public int dides;
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
    
    private float elapsedTime = 0.0f; 
    public void Timming()
    {
        elapsedTime += Time.deltaTime; 

      
        time = (int)elapsedTime;

    }
}