using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControaller : MonoBehaviour
{
    Animator anim;
    Vector3 move;
    Rigidbody rigid;


    //���Player��CharacterController���
    private CharacterController cc;
    [Header("�ƶ�����")]
    //����player���ƶ��ٶ�
    public float moveSpeed;
    [Header("��Ծ����")]
    //����player����Ծ�ٶ�
    public float jumpSpeed;
    //�����ð���ֵ����������
    private float horizontalMove, verticalMove;
    //������λ�������Ʒ���
    private Vector3 dir;
    //������������
    public float gravity;
    //����y��ļ��ٶ�
    private Vector3 velocity;

   
    private void Awake()
    {     
       
        
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        //��GetComponent<>()�������CharacterController
        cc = GetComponent<CharacterController>();
        //��ʼ������
        moveSpeed = 3;
        jumpSpeed = 5;
        gravity = 10;       
    }


    void Update()
    {
        
        //��Input.GetAxis()������ȡ���������ƶ���ֵ
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        //��Input.GetAxis()������ȡ����ǰ���ƶ���ֵ
      //  if (Input.GetKey(KeyCode.W))
         verticalMove = Input.GetAxis("Vertical") * moveSpeed;  
           
        

        //��������Ϣ�洢��dir��
        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        //��CharacterController�е�Move()�����ƶ�Player
        cc.Move(dir * Time.deltaTime);

        //�����̰��ո��ʱ�������ɽ�ɫ����Ծ
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpSpeed;
        }

        //ͨ��ÿ���ȥ������ֵ�����½�
        velocity.y -= gravity * Time.deltaTime;
        //��CharacterController�е�Move()�����ƶ�y��
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

