using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBeheviour : StateMachineBehaviour
{
    //アニメーション開始時に実行されるもの
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //速度を0にする
        animator.GetComponent<PlayerManager>().MoveSpeed = 0.6f;
        //攻撃されたときだけ遷移する（タイムラグでくらわない）
        animator.ResetTrigger("Hurt");

    }

    //アニメーション中に実行されるもの
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerManager>().MoveSpeed = 0.6f;
    }

    //アニメーション遷移時に実行されるもの
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //速度を元に戻す
        animator.GetComponent<PlayerManager>().MoveSpeed = 3;
        //攻撃されたときだけ遷移する（タイムラグでくらわない）
        animator.ResetTrigger("Hurt");


    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
