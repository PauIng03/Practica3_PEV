using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkController : MonoBehaviour
{
    Animator _animator;
    public Transform RightHandTarget;
    public Transform EnemyTarget;

    public float IkWeight = 1;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        IkWeight = 0;
    }

    public void SetEnemyTarget(Transform head)
    {
        EnemyTarget = head;
        IkWeight = 1;
    }
    public void SetEnemyTargetOut(Transform head)
    {
        EnemyTarget = head;
        IkWeight = 0;
    }

    public void OnAnimatorIK(int layerIndex)
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, IkWeight);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, EnemyTarget.position);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, IkWeight);
        _animator.SetIKRotation(AvatarIKGoal.RightHand, EnemyTarget.rotation);
    }
}
