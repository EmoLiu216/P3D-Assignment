using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGrow : MonoBehaviour
{

    private Animator m_Animator;

    Collider objCollider;
    Camera cam;
    Plane[] planes;

    private float distance = 1;

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
        //    Debug.Log(Vector3.Distance(transform.localPosition, Camera.main.transform.position));
            if (Vector3.Distance(transform.position, Camera.main.transform.position) <= distance)
            {
                m_Animator.SetBool("Grow", true);
            }
            else
            {
                m_Animator.SetBool("Grow", false);
            }
            // Debug.Log(objCollider.name + "¼ì²âµ½ÁË");

        }
    }
    //private void OnTriggerEnter(Collider other)
    //{

    //    if(other.tag=="MainCamera")
    //    {
    //        m_Animator.SetBool("Grow", true);
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "MainCamera")
    //    {
    //        m_Animator.SetBool("Grow", false);
    //    }
    //}
}
