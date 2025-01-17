using UnityEditor.Media;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed=12f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        Sround();
        if(Input.GetMouseButtonDown(0))
        {
           Move();
        }
    }

    public void Sround()//角色旋转
    {
        // 将鼠标屏幕位置转换为世界位置
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint
        (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

        // 计算从角色位置到鼠标位置的方向向量
        Vector3 direction = mousePosition - transform.position;

        // 计算旋转角度
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 设置角色的旋转，使其面向鼠标位置
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Move()//角色移动
    {
        float moveInput = Input.GetAxis("Horizontal");

        Transform weapon = transform.Find("针");//查找武器
       
        weapon.transform.position = transform.position; 
        Vector3 weaponPosition = weapon.transform.position;// 获取武器位置

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint
        (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z)); // 将鼠标屏幕位置转换为世界位置

        Vector2 forceDirection = (mousePosition - weaponPosition).normalized;// 计算推力方向
        rb.AddForce(-forceDirection* 10f, ForceMode2D.Impulse);// 施加反向推力
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}