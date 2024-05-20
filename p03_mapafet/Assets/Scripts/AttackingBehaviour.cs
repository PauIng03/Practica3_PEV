using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingBehaviour : BaseBehaviour
{
    private float Speed = 60;
    private Animator animator;
    private HealthSystem playerHealth;
    private float attackTimer = 0f;
    private float attackCooldown = 1f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        this.animator = animator;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        Animator.StringToHash("IsChasing");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckAttacks(animator);
        CheckTriggers(animator);

        attackTimer += Time.deltaTime;

        if (CheckAttack(animator.transform) && attackTimer >= attackCooldown)
        {
            playerHealth.TakeDamage(10);

            attackTimer = 0f;
        }

        Move(animator.transform);
    }

    private void Move(Transform mySelf)
    {
        Vector3 targetPos = new Vector3(_player.position.x, mySelf.position.y, _player.position.z);

        mySelf.LookAt(targetPos);
        mySelf.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
    }
}
