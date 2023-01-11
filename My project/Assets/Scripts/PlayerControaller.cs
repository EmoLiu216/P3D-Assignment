using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControaller : MonoBehaviour
{
    Animator anim;
    Vector3 move;
    Rigidbody rigid;


    //获得Player的CharacterController组件
    private CharacterController cc;
    [Header("移动参数")]
    //定义player的移动速度
    public float moveSpeed;
    [Header("跳跃参数")]
    //定义player的跳跃速度
    public float jumpSpeed;
    //定义获得按键值的两个变量
    private float horizontalMove, verticalMove;
    //定义三位变量控制方向
    private Vector3 dir;
    //定义重力变量
    public float gravity;
    //定义y轴的加速度
    private Vector3 velocity;

   
    private void Awake()
    {     
       
        
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        //用GetComponent<>()方法获得CharacterController
        cc = GetComponent<CharacterController>();
        //初始化参数
        moveSpeed = 3;
        jumpSpeed = 5;
        gravity = 10;       
    }


    void Update()
    {
        
        //用Input.GetAxis()方法获取按键左右移动的值
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        //用Input.GetAxis()方法获取按键前后移动的值
      //  if (Input.GetKey(KeyCode.W))
         verticalMove = Input.GetAxis("Vertical") * moveSpeed;  
           
        

        //将方向信息存储在dir中
        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        //用CharacterController中的Move()方法移动Player
        cc.Move(dir * Time.deltaTime);

        //当键盘按空格的时候可以完成角色的跳跃
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpSpeed;
        }

        //通过每秒减去重力的值不断下降
        velocity.y -= gravity * Time.deltaTime;
        //用CharacterController中的Move()方法移动y轴
        cc.Move(velocity * Time.deltaTime);

        move = new Vector3(horizontalMove, 0, verticalMove);

        UpadateAnim();
        pickup();
        dispose();
        AnimatorStateInfo animatorInfo;
        animatorInfo = anim.GetCurrentAnimatorStateInfo(0);
        if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("pick")))
        {
            anim.SetBool("pickup", false);
        }
        if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("dispose")))
        {
            anim.SetBool("dispose", false);
        }
        footaudio();
    }

    void footaudio() {
        
        if (move.magnitude==0) {
            gameObject.GetComponent<AudioSource>().Play();

        }
    }
    void pickup()
    {
        if (Input.GetKey(KeyCode.E)&& move.magnitude==0)
        {
            anim.SetBool("pickup", true);
          //  anim.SetTrigger("pick");
        }
       
        

    }
    void dispose() {
        if (Input.GetKey(KeyCode.G) && move.magnitude == 0)
        {
            anim.SetBool("dispose", true);
        }
    }
    void UpadateAnim()
    {
        anim.SetFloat("Speed", move.magnitude);
    }


}

