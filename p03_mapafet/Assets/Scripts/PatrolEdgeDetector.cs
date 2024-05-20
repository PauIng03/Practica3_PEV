using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatrolEdgeDetector : MonoBehaviour
{
    public Transform CheckPoint;
    public float Speed = 2;
    public LayerMask WhatIsGround;
    public LayerMask WhatIsWall;

    public float Range = 3f;    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NoGround())
            Turn();
        Move();
    }

    private bool NoGround()
    {
        if (Physics.Raycast(CheckPoint.position, Vector3.down, Range, WhatIsGround))
        {
            return false;
        }
        if (Physics.Raycast(CheckPoint.position, Vector3.forward, 5.55f, WhatIsWall))
        {
            return false;
        }
        return true;
    }

    private void Turn()
    {
        float angle = Random.Range(90f, 270f);
        transform.Rotate(new Vector3(0, angle, 0));
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}