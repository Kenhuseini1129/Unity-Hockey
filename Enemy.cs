using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;//追いかける対象のTransform
    [SerializeField] private Transform line;
    [SerializeField] private float enemySpeed;  　 //弾の速度
    [SerializeField] private float limitSpeed;      //弾の制限速度
    private Rigidbody2D rb;                         //弾のRigidbody2D
    private Transform enemyTrans;                  //弾のTransform

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 follow = Vector2.zero;


        if(ballTransform.position.x < -3.0f)
        {
            follow = new Vector2(limitSpeed * (ballTransform.position.x - enemyTrans.position.x), limitSpeed * (ballTransform.position.y - enemyTrans.position.y));
            rb.MovePosition(rb.position + follow * Time.fixedDeltaTime);
        }

        if (ballTransform.position.x > -3.0f)
        {
            follow = new Vector2(enemySpeed * (line.position.x - enemyTrans.position.x), enemySpeed * (ballTransform.position.y - enemyTrans.position.y));
            rb.MovePosition(rb.position + follow * Time.fixedDeltaTime);
        }  
    }
}
