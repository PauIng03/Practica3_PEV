using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : BaseBehaviour
{
    private float Speed = 75;
    private Animator animator;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        this.animator = animator;
        Animator.StringToHash("IsChasing");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Check triggers
        CheckTriggers(animator);
        CheckAttacks(animator);
        //Do stuff
        Move(animator.transform);
    }

    private void Move(Transform mySelf)
    {
        Vector3 targetPos = new Vector3(_player.position.x, mySelf.position.y, _player.position.z);

        mySelf.LookAt(targetPos);
        mySelf.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
    }
}
