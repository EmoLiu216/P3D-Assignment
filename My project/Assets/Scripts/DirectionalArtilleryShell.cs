using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ӵ�
/// </summary>
public class DirectionalArtilleryShell : MonoBehaviour
{
    //���Ŀ��
    private Transform Target;
    //�����ٶ�
    private float speed = 0f;
    //��С�ӽ�����
    private float min_distance = 0f;
    //�Ƿ���Ҫ׷��
    private bool IsTrace = false;
    //�ڵ���Ŀ������
    private float distanceToTarget;
    //�Ƿ��ƶ�
    private bool move_flag = true;
    //Ŀ�������
    private Vector3 TargetPosition = Vector3.zero;
    //����Ŀ���ʱ��Ŀ���ĽǶ�
    public float HitAngle = 45f;
    //������Ч
    //private GameObject HitEffect;
    [HideInInspector]
    public Vector3 targetPosition;

    private void Awake()
    {
        //HitEffect = Resources.Load("Prefabs/ShellHitEffect/FX_ZiMuDan_ChildHit") as GameObject;
    }

    /// <summary>
    /// ������ ����Ŀ��㡢�����ٶȡ���Сֹͣ�˶�����
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
    /// ������ ����Ŀ��㡢�����ٶȡ���Сֹͣ�˶�����
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
    /// �����ڵ�
    /// </summary>
    public void Shoot()
    {
        StartCoroutine(Parabola());
    }

    /// <summary>
    /// �ڵ���Ҫʵ��
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
            Vector3 oriPos = transform.position;//��¼ԭ����λ�� 
            transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
            float length = (transform.position - oriPos).magnitude;//���ߵĳ���  
            Vector3 direction = transform.position - oriPos;//����  
            RaycastHit hitinfo;
            bool isCollider = Physics.Raycast(oriPos, direction, out hitinfo, length);//������λ��֮�䷢��һ�����ߣ�Ȼ��ͨ����������ȥ�����û�з�����ײ  
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


