using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;

    float x ;
    float z ;
    public float MoveSpeed ;//移動速度の倍速


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //キーボード入力で移動
         x = Input.GetAxisRaw("Horizontal");
         z = Input.GetAxisRaw("Vertical");

        //攻撃入力:Spaceボタンを押したら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }

    }

    private void FixedUpdate()
    {
        //移動方向に振り向く
        Vector3 direction = transform.position + new Vector3(x, 0, z) * MoveSpeed;
        transform.LookAt(direction);

        //速度設定
        rb.velocity = new Vector3(x, 0, z) * MoveSpeed;

        //Speedの大きさを取得 → アニメーションの切り替え時に必要
        animator.SetFloat("Speed", rb.velocity.magnitude);

    }
}
