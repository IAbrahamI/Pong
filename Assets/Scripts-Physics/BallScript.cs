using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public float speed = 30f;
    int scorePlayerOne;
    int scorePlayerTwo;
    public Text textPlayerOne;
    public Text textPlayerTwo;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0)*speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       //print(collision.gameObject.name);

        if (collision.gameObject.name == "PlayerOne")
        {
            //Hit PlayerOne
            float y = hitObject(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            //print("Calculation: " + y);

            //Calculate the direction
            Vector2 direction = new Vector2(1, y);
            //Change the Physics of the ball
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        if (collision.gameObject.name == "PlayerTwo")
        {
            //Hit PlayerTwo
            float y = hitObject(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            //Calculate the direction
            Vector2 direction = new Vector2(-1, y);
            //Change the Physics of the ball
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        if(collision.gameObject.name == "LeftGoal")
        {
            print("Score for PlayerTwo");
            scorePlayerTwo++;
            textPlayerTwo.text = scorePlayerTwo.ToString();
            //restart
            restart();
        }
        if(collision.gameObject.name== "RightGoal")
        {
            print("Score for PlayerOne");
            scorePlayerOne++;
            textPlayerOne.text = scorePlayerOne.ToString();
            restart();
        }
        print(scorePlayerOne + " : " + scorePlayerTwo);
    }

    float hitObject(Vector2 ballPosition, Vector2 PlayerPosition, float PlayerHeight)
    {
        return (ballPosition.y - PlayerPosition.y) / PlayerHeight;
    }
    void restart()
    {
        //Restart the game set ball in the center
        Vector2 position = new Vector2(0, 0);
        gameObject.transform.position = position;
    }
}
