using System.Collections.Generic;
using System.Linq;
using UnityEditor.Media;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public bool isOnGround;
    public bool isJumping;
    public bool isFalling;
    private float jumpStartTime;

    public float lowJumpMultiplier;
    public float jumpDuration ;
    public float FallMultiplier;
    public float decelerationRate;

    private Rigidbody2D rb;
    public float moveSpeed = 12f;
    public float needleRadius = 2f; // 针围绕玩家的固定半径
    public float jumpForce;//设置跳跃力度
    public float bubbleRespawnTime = 3f; // 泡泡重生时间
    private Transform needle; // 针的Transform组件
    private GameObject currentBubble; // 当前被针接触的泡泡
    private bool isBubblePunctured = false; // 标记泡泡是否被戳破
    private float bubblePunctureTime; // 记录戳破泡泡的时间

    [Header("泡泡类型")]
    public LayerMask bubbleLayer; // 用于检测泡泡的Layer
    public LayerMask normalBubbleLayer;//普通
    public LayerMask strongBubbleLayer;//强力
    public LayerMask nonRespawnBubbleLayer;//不可再生
    public LayerMask pushableBubbleLayer;//可被吹动
    [Header("泡泡预制体")]
    public GameObject NormalBubblePrefab;
    public GameObject StrongBubblePrefab;

    //动画相关
    private Animator anim;
    private bool isMoving = false;
    #region 泡泡字典
    //添加数据字典存放被戳破的泡泡
    private Dictionary<GameObject, float> puncturedBubbles = new Dictionary<GameObject, float>();
    #endregion
    private void Start()
    {
        anim = GetComponent<Animator>();
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
        Anim();
        if (Input.GetMouseButtonDown(0) && currentBubble != null)
        {
            PunctureBubble();
        }
        playerMove();

    }
    private void Anim()
    {
        if (rb.velocity == Vector2.zero) { isMoving = false; }
        else { isMoving = true; }
        anim.SetBool("IsMoving", isMoving);//转换移动或静止
        anim.SetFloat("Direction", rb.velocity.x);//跳跃的面朝方向
    }
    public bool canmove = true;
    void FixedUpdate()
    {
        if(canmove)
        {
            float elapsedTime = Time.time - jumpStartTime;

            // 如果跳跃持续时间未结束，则应用缓动效果
            if (rb.velocity.y > 0)
            {
                float velocityModifier = Physics2D.gravity.y * lowJumpMultiplier * Time.fixedDeltaTime;
                rb.velocity += Vector2.up * velocityModifier;
            }
            else if (rb.velocity.y < 0)
            {
                // 跳跃上升结束，下落进行减速，缓缓下落
                rb.velocity += Vector2.up * Physics2D.gravity.y * FallMultiplier * Time.fixedDeltaTime;//给向下的力加速下落

            }
            if (rb.velocity.x != 0)
            {
                float decelerationAmount = Mathf.Abs(rb.velocity.x) * decelerationRate * Time.fixedDeltaTime;

                if (rb.velocity.x > 0)
                {
                    rb.velocity = new Vector2(Mathf.Max(0, rb.velocity.x - decelerationAmount), rb.velocity.y);
                }
                else if (rb.velocity.x < 0)
                {
                    rb.velocity = new Vector2(Mathf.Min(0, rb.velocity.x + decelerationAmount), rb.velocity.y);
                }
            }

            // 设置一个阈值，当速度小于这个阈值时直接将其设置为0
            float speedThreshold = 0.01f; // 你可以根据需要调整这个值
            if (Mathf.Abs(rb.velocity.x) < speedThreshold)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
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
        Collider2D collider = Physics2D.OverlapCircle(needle.position, 0.3f); // 使用小半径检测针尖是否接触泡泡
        if (collider != null)
        {
            currentBubble = collider.gameObject;
            if (!isBubblePunctured)
            {
                //添加游戏效果（提示接触到泡泡或者指针变色），也可以忽略
                if (Input.GetMouseButtonDown(0))
                {
                    currentBubble.GetComponent<Animator>();
                    //currentBubble.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            currentBubble = null;
        }
    }

    float jumpForceMagnitude ; // 默认跳跃力
    private void PunctureBubble()
    {

        bool respawn = true; // 默认泡泡是可重生的
        jumpForceMagnitude = jumpForce;
        isBubblePunctured = true;
        bubblePunctureTime = Time.time; // 记录戳破时间

        if (LayerMask.LayerToName(currentBubble.layer) == "NormalBubble")
        {
            // 常规泡泡

        }
        else if (LayerMask.LayerToName(currentBubble.layer) == "StrongBubble")
        {
            // 强力泡泡，增加跳跃力
            jumpForceMagnitude *= 2f; // 例如，跳跃力加倍
        }
        else if (LayerMask.LayerToName(currentBubble.layer) == "NonRespawnBubble")
        {
            // 不可重生泡泡
            respawn = false;
        }
        else if (LayerMask.LayerToName(currentBubble.layer) == "PushableBubble")
        {
            // 可被其他泡泡爆破推动的泡泡（这里可能需要额外的逻辑来处理推动效果）
            // 例如，可以设置一个触发器来检测其他泡泡的爆破并应用力
        }
        else{ return; }

        PlayParticles(currentBubble);
        puncturedBubbles[currentBubble] = Time.time;//将泡泡添加到字典中
        /*        if (!respawn)
                {
                    Destroy(currentBubble);
                }
                else
                {
                    //isBubblePunctured = true;
                    bubblePunctureTime = Time.time;
                    currentBubble.SetActive(false); // 暂时禁用泡泡，以便在LateUpdate中重生
                    puncturedBubbles[currentBubble] = Time.time;//将泡泡添加到字典中
                }*/





        //currentBubble = null; // 重置当前泡泡（可能不需要，出问题可以看看一这里）
        // 设置跳跃状态为true，并记录跳跃开始时间
        isJumping = true;
        jumpStartTime = Time.time;

    }

    public float jumpBufferTimer;
    public float jumpBuffer;
    public GameObject GroundCollider;

    public void playerMove()
    {
        if (Input.GetMouseButtonDown(0) && currentBubble != null)
        {
            jumpBufferTimer = jumpBuffer;
            if (jumpBufferTimer > 0)
            {
                if (GroundCollider.GetComponent<jump>().OnGround)//倒计时结束前如果
                {
                    rb.velocity = new Vector2(0,0);
                    Vector2 jumpDirection = (needle.position - transform.position).normalized;
                    Vector2 JumpForce = jumpDirection * jumpForceMagnitude;//加一个小写的jumpForce是方便在页面修改
                                                                           // 应用跳跃冲力
                    rb.AddForce(-JumpForce, ForceMode2D.Impulse);
                    jumpBufferTimer = 0;//如果跳跃了，则把倒计时归零，等待下一次按下空格
                }
                jumpBufferTimer--;//如果没有跳跃，则一直倒计时直至结束或者按下跳跃键
            }
        }


    }
    private void LateUpdate()
    {
        // 遍历被戳破的泡泡字典
        if(puncturedBubbles.Count > 0)
        {
            foreach (var bubble in puncturedBubbles.ToArray())
            {
                if (Time.time - bubble.Value > bubbleRespawnTime)
                {
                    // 根据泡泡类型加载预设体
                    GameObject bubblePrefab = null;
                    string prefabName = null;//这里添加预制体路径，根据我们文件的预制体文件夹来找
                    string bubbleLayerName = LayerMask.LayerToName(bubble.Key.layer);
                    switch (bubbleLayerName)
                    {
                        case "NormalBubble":
                            prefabName = "NormalBubblePrefab";//预制体的命名必须和引号内相同
                            bubblePrefab = NormalBubblePrefab;
                            break;
                        case "StrongBubble":
                            prefabName = "StrongBubblePrefab";
                            bubblePrefab = StrongBubblePrefab;
                            break;
                        //添加其他的泡泡类型
                        default:
                            Debug.LogError("未知的泡泡类型: " + bubbleLayerName);
                            continue;
                    }
                    //bubblePrefab = Resources.Load<GameObject>(prefabPath);
                    if (bubblePrefab != null)
                    {
                        Instantiate(bubblePrefab, bubble.Key.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Debug.LogError("无法加载泡泡预设体: " + prefabName);
                    }

                    // 从字典中移除已处理的泡泡
                    puncturedBubbles.Remove(bubble.Key);
                }
            }
        }
        
    }

    // 用于存储最近离开的存档点
    public GameObject lastSaveArea;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SaveArea"))
        {
            lastSaveArea = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SaveArea"))
        {
            lastSaveArea = other.gameObject;
        }
    }

    private Animator animator;
    private ParticleSystem particleSystem; // 引用粒子系统组件
    private AudioSource audioSource;//获取音频组件 
    public void PlayParticles(GameObject Bubble)//戳泡泡时调用
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();//播放音频
        //播放泡泡破裂动画，并在销毁最后一帧
        animator = Bubble.GetComponent<Animator>();
        animator.SetTrigger("burst");
        Bubble.transform.Find("GameObject").gameObject.SetActive(true);
        Transform particleSystemTransform = Bubble.transform.Find("GameObject"); 
        if (particleSystemTransform != null)
        {
            particleSystem = particleSystemTransform.GetComponent<ParticleSystem>();
            Vector2 direction = (Bubble.transform.position - transform.position).normalized;

            particleSystemTransform.forward = direction;

            // 播放粒子系统
            particleSystem.Play();
        }

    }
    public void StopParticles(GameObject Bubble)//在泡泡破裂最后一帧调用
    {
        ParticleSystem ps = Bubble.transform.Find("GameObject").GetComponent<ParticleSystem>();
        if (ps != null && ps.isPlaying)
        {
            ps.Stop();
            Bubble.transform.Find("GameObject").gameObject.SetActive(false);
        }
        if (LayerMask.LayerToName(Bubble.layer) == "NonRespawnBubble")
        {
            Destroy(Bubble);
        }
        else
        {
            //isBubblePunctured = true;
            //bubblePunctureTime = Time.time;
            Bubble.SetActive(false); // 暂时禁用泡泡，以便在LateUpdate中重生
            
        }
    }

}
