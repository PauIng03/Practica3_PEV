using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public LayerMask WhatIsShootable;
    public Transform FirePoint;


    LineRenderer line;
    public Transform StartPoint;
    public Transform EndPoint;


    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();


        SetPoints();
    }



    void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(FirePoint.position, FirePoint.forward, out hit, 300, WhatIsShootable))
        {
            Debug.Log("Shoot at " + hit.transform.name);
            EndPoint.position = hit.point;
            line.enabled = true;
        }
        else
        {
            EndPoint.position = StartPoint.position + 300 * FirePoint.forward;
            line.enabled = false;
        }
    }
    private void SetPoints()
    {
        line.SetPosition(0, StartPoint.position);
        line.SetPosition(1, EndPoint.position);
    }
}
