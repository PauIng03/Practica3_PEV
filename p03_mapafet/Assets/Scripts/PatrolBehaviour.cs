using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PatrolBehaviour : TimeBehaviour
{
    private float Speed = 20;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        Vector3 rdmPointInPlane = new Vector3(Random.Range(-1000, 1000), animator.transform.position.y, Random.Range(-1000, 1000));

        animator.transform.LookAt(rdmPointInPlane);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Check triggers
        CheckTriggers(animator);

        //Do stuff
        Move(animator.transform);
    }

    private void Move(Transform mySelf)
    {
        mySelf.Translate(mySelf.forward * Speed * Time.deltaTime);
    }
}