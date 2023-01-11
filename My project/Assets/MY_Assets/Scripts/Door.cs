using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator m_Animator;
    private float RayDis=100f;
    private KeyCode openKey=KeyCode.F;

    Collider objCollider;
    Camera cam;
    Plane[] planes;
  
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        cam = Camera.main;
        objCollider = GetComponent<Collider>();
    }
    private void Update()
    {
       
        planes = GeometryUtility.CalculateFrustumPlanes(cam);

        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
        {
            // Debug.Log(objCollider.name + "ºÏ≤‚µΩ¡À");
            if (Input.GetKeyDown(openKey))
            {
                AnimatorStateInfo stateinfo = m_Animator.GetCurrentAnimatorStateInfo(0);
                if (stateinfo.IsName("Idle") || stateinfo.IsName("CloseDoor"))
                    m_Animator.SetBool("Open", true);
                else
                    m_Animator.SetBool("Open", false);
            }

        }
    }
}
