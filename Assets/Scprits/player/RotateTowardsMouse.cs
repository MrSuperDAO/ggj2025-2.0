using UnityEditor.Media;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 12f;
    public float needleRadius = 2f; // 针围绕玩家的固定半径
    public float jumpForce;//设置跳跃力度
    public LayerMask bubbleLayer; // 用于检测泡泡的Layer
    public float bubbleRespawnTime = 3f; // 泡泡重生时间
    private Transform needle; // 针的Transform组件
    private GameObject currentBubble; // 当前被针接触的泡泡
    private bool isBubblePunctured = false; // 标记泡泡是否被戳破
    private float bubblePunctureTime; // 记录戳破泡泡的时间

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        needle = transform.Find("针"); // 查找针
        if (needle == null)
        {
            Debug.LogError("针(针)未找到在玩家对象上！");
        }
    }

    private void Update()
    {
        RotateNeedle();
        CheckPunctureBubble();
        if (Input.GetMouseButtonDown(0) && currentBubble != null)
        {
            PunctureBubble();
        }
    }

    private void RotateNeedle()
    {
        // 将鼠标屏幕位置转换为世界位置
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        mousePosition.z = transform.position.z; // 确保z轴与玩家对象相同

        // 计算从玩家位置到鼠标位置的方向向量，并限制在needleRadius半径内
        Vector3 direction = (mousePosition - transform.position).normalized * needleRadius;

        // 设置针的位置
        needle.position = transform.position + direction;

        // 计算旋转角度
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90;

        // 设置针的旋转，使其面向鼠标位置（其实这里不需要，因为直接设置了位置）
        // 但如果为了视觉效果，可以保留或调整
        needle.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void CheckPunctureBubble()
    {
        Collider2D collider = Physics2D.OverlapCircle(needle.position, 0.1f, bubbleLayer); // 使用小半径检测针尖是否接触泡泡
        if (collider != null)
        {
            currentBubble = collider.gameObject;
            if (!isBubblePunctured)
            {
                //添加游戏效果（提示接触到泡泡或者指针变色），也可以忽略
            }
        }
        else
        {
            currentBubble = null;
        }
    }

    private void PunctureBubble()
    {
        //Destroy(currentBubble); // 销毁泡泡
        isBubblePunctured = true;
        bubblePunctureTime = Time.time; // 记录戳破时间

        // 施加反向力使玩家跳跃
        Vector2 JumpForce = (needle.position - transform.position).normalized * jumpForce; // 调整力的大小和方向,
        rb.AddForce(-JumpForce, ForceMode2D.Impulse);

        // 可以在这里添加音效等反馈
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 如果泡泡重生逻辑需要在这里处理（比如通过触发器重生），可以添加相关代码
        // 但通常重生逻辑会在Update中根据bubblePunctureTime和bubbleRespawnTime来处理
    }

    private void LateUpdate()
    {
        // 检查是否需要重生泡泡
        if (isBubblePunctured && Time.time - bubblePunctureTime > bubbleRespawnTime)
        {
            // 这里需要实现泡泡的重生逻辑，可能是通过实例化预制件等
            // 例如：Instantiate(bubblePrefab, bubbleSpawnPoint, Quaternion.identity);
            // 注意：bubblePrefab和bubbleSpawnPoint需要您自行定义

            isBubblePunctured = false; // 重置标记
        }
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
