
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DataController : MonoBehaviour
{
    public static DataController Instance { get; private set; }
    public int time = 0;
    public int dides = 0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public RotateTowardsMouse rotateTowardsMouse = null;
    private void Update()
    {
        if(rotateTowardsMouse.canmove)
        {
            Timming();
        }
        
    }
    
    private float elapsedTime = 0.0f; 
    public void Timming()
    {
        elapsedTime += Time.deltaTime; 

      
        time = (int)elapsedTime;

    }
}