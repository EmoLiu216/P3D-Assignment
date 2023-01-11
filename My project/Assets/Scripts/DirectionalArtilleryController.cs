using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 发射台
/// </summary>

public class DirectionalArtilleryController : MonoBehaviour
{
    [Header("攻击目标点")]
    public Transform Target;

    [Header("运动速度")]
    public float speed = 10;

    [Header("最小接近距离, 以停止运动")]
    public float min_distance = 0.5f;

    [Header("到达目标时与目标的角度")]
    public float HitAngle = 45f;

    [Header("是否追踪")]
    public bool IsTrace = false;

    //炮弹实例
    private GameObject DirShell;

    //炮弹发射位置
    private DirectionalArtilleryShootPoint ShootPoint = null;


    public static Vector3 targetPosition;

    private float forwordDis=6;

    private void Awake()
    {
        DirShell = Resources.Load("DirectionalArtilleryShell") as GameObject;
    }

    private void Start()
    {
        if (ShootPoint == null)
        {
            ShootPoint = GetComponentInChildren<DirectionalArtilleryShootPoint>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = transform.position + this.transform.forward * forwordDis;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    DirectionalArtilleryShell artilleryShell = CreatShell();
        //    //  artilleryShell.transform.SetParent(ShootPoint.transform);
        //    //   artilleryShell.transform.localPosition = Vector3.zero;
        //    //  artilleryShell.SetShellData(Target, speed, min_distance, HitAngle, IsTrace);

        //    artilleryShell.SetShellData(targetPosition, speed, min_distance, HitAngle, IsTrace);
        //    artilleryShell.Shoot();
        //}
    }

    /// <summary>
    /// 创建定向炮弹实例
    /// </summary>
    /// <returns></returns>
    private DirectionalArtilleryShell CreatShell()
    {
        GameObject shellObj = Instantiate(DirShell, ShootPoint.shootPoint, Quaternion.identity, null);
        shellObj.transform.TryGetComponent(out DirectionalArtilleryShell shell);

        return shell;
    }
}

