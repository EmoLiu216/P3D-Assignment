using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����̨
/// </summary>

public class DirectionalArtilleryController : MonoBehaviour
{
    [Header("����Ŀ���")]
    public Transform Target;

    [Header("�˶��ٶ�")]
    public float speed = 10;

    [Header("��С�ӽ�����, ��ֹͣ�˶�")]
    public float min_distance = 0.5f;

    [Header("����Ŀ��ʱ��Ŀ��ĽǶ�")]
    public float HitAngle = 45f;

    [Header("�Ƿ�׷��")]
    public bool IsTrace = false;

    //�ڵ�ʵ��
    private GameObject DirShell;

    //�ڵ�����λ��
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
    /// ���������ڵ�ʵ��
    /// </summary>
    /// <returns></returns>
    private DirectionalArtilleryShell CreatShell()
    {
        GameObject shellObj = Instantiate(DirShell, ShootPoint.shootPoint, Quaternion.identity, null);
        shellObj.transform.TryGetComponent(out DirectionalArtilleryShell shell);

        return shell;
    }
}

