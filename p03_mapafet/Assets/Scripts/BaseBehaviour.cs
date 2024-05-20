using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : StateMachineBehaviour
{
    protected Transform _player;
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected bool CheckPlayer(Transform mySelf)
    {
        float distance = Vector3.Distance(_player.position, mySelf.position);
        return distance < 200 && distance >= 100;
    }
    protected bool CheckAttack(Transform mySelf)
    {
        float distance = Vector3.Distance(_player.position, mySelf.position);
        return distance < 100;
    }

    protected bool EnemicsVius(Transform mySelf)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemic");
        int count = 0;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(_player.position, mySelf.position);
            if (distance >= 100)
            {
                count++;
            }
            else count = 3;
        }
        return count < 3;
    }

    protected virtual void CheckTriggers(Animator animator)
    {
        bool IsPlayerClose = CheckPlayer(animator.transform);
        bool EstanEnemicsVius = EnemicsVius(animator.transform);
        Debug.Log(EstanEnemicsVius);
        animator.SetBool("IsChasing", IsPlayerClose || EstanEnemicsVius);
    }
    protected virtual void CheckAttacks(Animator animator)
    {
        bool IsPlayerCloseAttack = CheckAttack(animator.transform);
        animator.SetBool("IsAttacking", IsPlayerCloseAttack);
    }

}
