using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����
/// </summary>
public class DirectionalArtilleryShootPoint : MonoBehaviour
{
    [HideInInspector]
    public Vector3 shootPoint;
    private void Update()
    {
        shootPoint = transform.position;
    }
}
