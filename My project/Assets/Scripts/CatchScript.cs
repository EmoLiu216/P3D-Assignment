using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchScript : MonoBehaviour
{
    private GameObject gameobj;
    private bool CubeFlag = false;
    private bool SphereFlag = false;
    private bool CapsuleFlag = false;
    public Texture2D texture;
    private Transform CameraParent;
    private Transform cubeManager;
    private Transform objectTransform;
    private bool IsHand=false;
    [HideInInspector]
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int SetCursorPos(int x, int y);
    void Start()
    {
        CameraParent = GameObject.Find("Main Camera").transform;
        cubeManager = GameObject.Find("CubeManger").transform;
        objectTransform = GameObject.Find("ObjectTransform").transform;
    }
    void Update()
    {
       // SetCursorPos((int)Screen.width / 2, (int)Screen.height / 2);     

        //������ �Ƿ���
        if (Input.GetMouseButtonDown(0))
        {
            //�������� Camera.main ֻ�Ǵ���tag��ǩΪmain camera ������� ������滻Ϊ�κ������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //������ײ�����
            RaycastHit hit;
            //�ж��Ƿ���ײ
            if (Physics.Raycast(ray, out hit))
            {
                //��ӡʰȡ���������
                Debug.Log(hit.transform.name);
                SetObj(hit.transform.name);
            }
            else
            {
                CubeFlag = false;
                CapsuleFlag = false;
                SphereFlag = false;
            }
        }

        if (CubeFlag)
        {
            gameobj.GetComponent<Renderer>().material.mainTexture = texture;
            gameobj.transform.position = objectTransform.position;
            gameobj.transform.SetParent(CameraParent);
            IsHand = true;
            //gameobj.GetComponent<Rigidbody>().useGravity = false;
            //�ж϶����Ƿ������ϣ��ǵĻ���G�����ӳ�ȥ
            if (IsHand && Input.GetKeyDown(KeyCode.G))
            {
                gameobj.transform.SetParent(cubeManager);
               // Vector3 camDirct = transform.TransformDirection(0,10, 0);
                gameobj.GetComponent<Rigidbody>().AddForce(transform.forward*10, ForceMode.Impulse);
                CubeFlag = false;
                IsHand = false;
            }
        }

        if (SphereFlag)
        {
            gameobj.transform.Translate(0, 0.02f, 0);
        }
        if (CapsuleFlag)
        {
            gameobj.transform.Rotate(0, 10, 0);
        }

    }
    void SetObj(string hitname)
    {
        switch (hitname)
        {
            case "Cube":

                gameobj = GameObject.Find("Cube");
                CubeFlag = true;
                CapsuleFlag = false;
                SphereFlag = false;
                break;
            case "Sphere":
                gameobj = GameObject.Find("Sphere");
                SphereFlag = true;
                CubeFlag = false;
                CapsuleFlag = false;
                break;
            case "Capsule":
                gameobj = GameObject.Find("Capsule");
                CapsuleFlag = true;
                CubeFlag = false;
                SphereFlag = false;
                break;
            default:
                CubeFlag = false;
                CapsuleFlag = false;
                SphereFlag = false;
                break;
        }
    }
}