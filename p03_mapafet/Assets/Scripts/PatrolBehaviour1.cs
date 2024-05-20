using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PatrolBehaviour1 : TimeBehaviour
{
    public float Speed = 20f;
    public Transform[] Waypoints;

    private int currentWaypointIndex = 0;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        animator.transform.LookAt(Waypoints[currentWaypointIndex]);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(animator.transform.position, Waypoints[currentWaypointIndex].position) < 1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % Waypoints.Length;
            animator.transform.LookAt(Waypoints[currentWaypointIndex]);
        }
        else
        {
            Move(animator.transform);
        }
        CheckTriggers(animator);
        CheckAttacks(animator);
    }

    private void Move(Transform mySelf)
    {
        mySelf.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
