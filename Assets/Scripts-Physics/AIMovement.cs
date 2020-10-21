using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform ball;
    public float ballYPos;
    public Transform ai;
    public Rigidbody2D aiRigidBody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball").transform;
        ai = gameObject.transform;
        aiRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ballYPos = ball.position.y;

        if(ballYPos > ai.position.y+0.2)
        {
            aiRigidBody.velocity = new Vector2(0,speed);
        } else if(ballYPos < ai.position.y -0.2)
        {
            aiRigidBody.velocity = new Vector2(0, -speed);
        }
        else
        {
            aiRigidBody.velocity = new Vector2(0, 0);
        }
    }
}
