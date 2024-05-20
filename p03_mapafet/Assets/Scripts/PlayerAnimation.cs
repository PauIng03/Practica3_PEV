using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private int IsWalkingHash;
    private int IsRunningHash;
    public InputController _input;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        IsWalkingHash = Animator.StringToHash("IsWalking");
        IsRunningHash = Animator.StringToHash("IsRunning");
    }

    void Update()
    {
        animator.SetBool(IsRunningHash, _input.Ran);
    }
}

