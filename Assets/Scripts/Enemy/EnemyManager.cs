using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*距離に応じてアニメーションを遷移させたい
・Idle：遠い：7以上：speedを0
・Run：やや近い：7～2：speedを2
・Attack：近い：2以下 ：speedを0 
*/

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
    public Collider WeaponCollider; //武器判定の有無


    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        HideColliderWeapon();


    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance);

    }


    private void OnTriggerEnter(Collider other)
    {
        Damager damager = other.GetComponent<Damager>();
        if (damager != null)
        {
            //ダメージを与えるものにぶつかったらダメージアニメーションになる
            animator.SetTrigger("Hurt");

        }

    }

    //武器判定の有無を付与する関数
    public void HideColliderWeapon()
    {
        WeaponCollider.enabled = false;
    }

    public void ShowColliderWeapon()
    {
        WeaponCollider.enabled = true;

    }


}
