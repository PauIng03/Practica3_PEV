using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Player_Controller : MonoBehaviour
{
    private Animator animator;
    private int IsPatrollingHash;
    private int IsChasingHash;

    CharacterController _characterController;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        IsPatrollingHash = Animator.StringToHash("IsPatrolling");
        IsChasingHash = Animator.StringToHash("IsChasing");
    }

}
