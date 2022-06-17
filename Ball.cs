using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D myRigidBody;

    private GameObject playerGoal;
    private GameObject enemyGoal;
    public float speedX = 10f;
    public float speedY = 10f;
    Vector2 force;

    Goal playerScore;
    Goal enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        playerGoal = GameObject.Find("LeftGoal");
        playerScore = playerGoal.GetComponent<Goal>();

        enemyGoal = GameObject.Find("RightGoal");
        enemyScore = enemyGoal.GetComponent<Goal>();

        myRigidBody = this.gameObject.GetComponent<Rigidbody2D>();

        force = new Vector2(speedX, speedY);


        Invoke("StartBall", 3.5f);


    }

    // Update is called once per frame
    void Update()
    {
        if(playerScore.score == 11 || enemyScore.score == 11)
        {
            Destroy(this);
        }
    }


    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerGoal")
        {
            transform.position = new Vector2(0, 0);
            LoserBall();
            myRigidBody.velocity = Vector2.zero;
            yield return new WaitForSeconds(3.0f);
            Vector2 force = new Vector2(-speedX, speedY);
            myRigidBody.AddForce(force);
        }
        else if(collision.gameObject.tag == "EnemyGoal")
        {
            transform.position = new Vector2(0, 0);
            LoserBall();
            myRigidBody.velocity = Vector2.zero;
            Vector2 force = new Vector2(speedX, speedY);
            yield return new WaitForSeconds(3.0f);
            myRigidBody.AddForce(force);
        }



        if (collision.gameObject.tag == "Mallet" || collision.gameObject.tag == "Wall")
        {
            GetComponent<AudioSource>().Play();
        }
    }


    void LoserBall()
    {
        speedY = Random.Range(0.0f, 600.0f);
        speedY -= 300.0f;
    }

    void StartBall()
    {
        myRigidBody.AddForce(force);
    }
}
