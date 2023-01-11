using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子弹
/// </summary>
public class DirectionalArtilleryShell : MonoBehaviour
{
    //打击目标
    private Transform Target;
    //发射速度
    private float speed = 0f;
    //最小接近距离
    private float min_distance = 0f;
    //是否需要追踪
    private bool IsTrace = false;
    //炮弹与目标点距离
    private float distanceToTarget;
    //是否移动
    private bool move_flag = true;
    //目标点坐标
    private Vector3 TargetPosition = Vector3.zero;
    //击中目标点时与目标点的角度
    public float HitAngle = 45f;
    //集中特效
    //private GameObject HitEffect;
    [HideInInspector]
    public Vector3 targetPosition;

    private void Awake()
    {
        //HitEffect = Resources.Load("Prefabs/ShellHitEffect/FX_ZiMuDan_ChildHit") as GameObject;
    }

    /// <summary>
    /// 参数： 攻击目标点、发射速度、最小停止运动距离
    /// </summary>
    public void SetShellData(Transform target, float speed, float distance, float hitAngle, bool isTrace)
    {
        Target = target;
        TargetPosition = Target.position;
        this.speed = speed;
        min_distance = distance;
        HitAngle = hitAngle;
        IsTrace = isTrace;
        distanceToTarget = Vector3.Distance(transform.position, Target.position);
    }
    /// <summary>
    /// 参数： 攻击目标点、发射速度、最小停止运动距离
    /// </summary>
    public void SetShellData(Vector3 targetPosition, float speed, float distance, float hitAngle, bool isTrace)
    {

        TargetPosition = targetPosition;
        this.speed = speed;
        min_distance = distance;
        HitAngle = hitAngle;
        IsTrace = isTrace;
        distanceToTarget = Vector3.Distance(transform.position, targetPosition);
    }

    /// <summary>
    /// 发射炮弹
    /// </summary>
    public void Shoot()
    {
        StartCoroutine(Parabola());
    }

    /// <summary>
    /// 炮弹主要实现
    /// </summary>
    /// <returns></returns>
    IEnumerator Parabola()
    {
        while (move_flag)
        {
            if (IsTrace)
            {
                // TargetPosition = Target.position;
                targetPosition = DirectionalArtilleryController.targetPosition;
                TargetPosition = targetPosition;
            }
            transform.LookAt(TargetPosition);
            float angle = Mathf.Min(1, Vector3.Distance(transform.position, TargetPosition) / distanceToTarget) * HitAngle;
            transform.rotation = transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
            float currentDist = Vector3.Distance(transform.position, TargetPosition);
            if (currentDist < min_distance)
            {
                move_flag = false;
            }
            Vector3 oriPos = transform.position;//记录原来的位置 
            transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
            float length = (transform.position - oriPos).magnitude;//射线的长度  
            Vector3 direction = transform.position - oriPos;//方向  
            RaycastHit hitinfo;
            bool isCollider = Physics.Raycast(oriPos, direction, out hitinfo, length);//在两个位置之间发起一条射线，然后通过这条射线去检测有没有发生碰撞  
            if (isCollider)
            {
              
                move_flag = false;
               
            }
            yield return null;
        }
        move_flag = true;
        //if (move_flag == false)
        //{
        //    transform.position = TargetPosition;
        //    StopCoroutine(Parabola());
        //    // GameObject vfx = Instantiate(HitEffect);
        //    // vfx.transform.position = transform.position;
        //    // Destroy(gameObject);
        //}
    }
}


