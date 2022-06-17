using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    public float playerSpeed = 10;
    const float XMIN = 2.0f;
    const float XMAX = 7.75f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = this.gameObject.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerControl();

    }

    void PlayerControl()
    {

        Vector2 force = Vector2.zero;

        if (Input.GetKey(KeyCode.Space))
        {
            playerSpeed = 20;
        }
        else
        {
            playerSpeed = 10;
        }



        //transform.position.y >= 3.75f && transform.position.x <= XMAX
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= XMIN)
        {
            force = new Vector2(playerSpeed * -1, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= XMAX)
        {
            force = new Vector2(playerSpeed, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            force = new Vector2(0, playerSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            force = new Vector2(0, playerSpeed * -1);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && transform.position.x >= XMIN)
        {
            force = new Vector2(playerSpeed * -1, playerSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) && transform.position.x >= XMIN)
        {
            force = new Vector2(playerSpeed * -1, playerSpeed * -1);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && transform.position.x <= XMAX)
        {
            force = new Vector2(playerSpeed, playerSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow) && transform.position.x <= XMAX)
        {
            force = new Vector2(playerSpeed, playerSpeed * -1);
        }

        myRigidBody.MovePosition(myRigidBody.position + force * Time.fixedDeltaTime);
    }

}
