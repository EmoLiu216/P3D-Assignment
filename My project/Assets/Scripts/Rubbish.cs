using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbish : MonoBehaviour
{
    Collider objCollider;
    Camera cam;
    Plane[] planes;
    private Transform cubeManager;
    private Transform objectTransform;
    private Transform objectParent;
    public Texture2D texture;
    private float distance = 1.5f;
    private Transform force;
    private bool isHand;
    public Transform player;




    DirectionalArtilleryShell artilleryShell;
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


    void Start()
    {
        cam = Camera.main;
        objCollider = GetComponent<Collider>();
        cubeManager = GameObject.Find("CubeManger").transform;
        objectTransform = GameObject.Find("RubbishTransform").transform;
        objectParent = GameObject.Find("IndexFinger1_R").transform;
        force = GameObject.Find("force").transform;
        artilleryShell = GetComponent<DirectionalArtilleryShell>();
    }

    private void Update()
    {

        planes = GeometryUtility.CalculateFrustumPlanes(cam);

        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
        {
           //  Debug.Log(Vector3.Distance(transform.position, Camera.main.transform.position));
            if (Vector3.Distance(transform.position, Camera.main.transform.position) <= distance && Input.GetKey(KeyCode.E))
            {
              //  Debug.Log("123131231");
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.transform.position= objectTransform.position;
               gameObject.transform.SetParent(objectParent);
               isHand = true;
            }
           
            // Debug.Log(objCollider.name + "��⵽��");

        }
        if (isHand && Input.GetKey(KeyCode.G))
        {
            Debug.Log("564654");
            gameObject.transform.SetParent(cubeManager);
            //Vector3 camDirct = transform.TransformDirection(0,10, 0);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //Debug.Log(player.transform.position);
            //gameObject.GetComponent<Rigidbody>().AddForce(player.forward * 10, ForceMode.Impulse);

            artilleryShell.SetShellData(DirectionalArtilleryController.targetPosition, speed, min_distance, HitAngle, IsTrace);
            artilleryShell.Shoot();
            isHand = false;
        }
    }
}
