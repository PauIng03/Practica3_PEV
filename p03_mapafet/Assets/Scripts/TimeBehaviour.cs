using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBehaviour : BaseBehaviour
{
    protected float _timer;
    public float WaitTime=2;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _timer = 0;
    }
    protected bool CheckTime()
    {
        _timer += Time.deltaTime;
        return _timer > WaitTime;
    }
    protected override void CheckTriggers(Animator animator)
    {
        base.CheckTriggers(animator);
        bool isTimeUp = CheckTime();
        animator.SetBool("IsPatrolling", isTimeUp);
    }
}
