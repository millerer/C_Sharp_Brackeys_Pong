/*
                Adapted from the Brackeys.com 2D Pong Game tutorial by Eric Miller on 2-17-2018

                Description: 

                This is my attempt at the Brackey's Unity Tutorial for a 2D pong game. The tutorial series was done in Javascript,
                however I adapted it to use C# scripting instead. The original video tutorial series can be found at the following 
                link: https://www.youtube.com/watch?v=9h-z0AyG42k&list=PLPV2KyIb3jR4_IYZY2V0G3IUYcx1zZkJe

                Please note that all graphical and sound assets were created by the staff at Brackeys.com
 */


using UnityEngine;
using UnityEngine.Audio;

public class BallScript : MonoBehaviour {


	//Launch the ball after a 2 sec delay at start of game
	void Start () {
        Invoke("LaunchBall", 2f);
    }

    //Change velocity when colliding with a paddle in proportion to
    //the paddle's speed
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        if(colInfo.collider.tag == "Player")
        {
            //new Y velocity
            float velocityY = gameObject.GetComponent<Rigidbody2D>().velocity.y;
            velocityY = velocityY / 2 + colInfo.collider.GetComponent<Rigidbody2D>().velocity.y / 3;

            //apply velocity to the ball object
            gameObject.GetComponent<Rigidbody2D>().velocity.Set(gameObject.GetComponent<Rigidbody2D>().velocity.x, velocityY);

            //play sound fx with a random pitch
            gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.5f, 2f);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
    
    //Reset the ball to the center of the arena and launch after 1 second
    public void ResetBall()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        gameObject.GetComponent<Transform>().position = new Vector2(0f, 0f);
        Invoke("LaunchBall", 1f);
    }

    // Send the ball randomly left or right when initialized
    private void LaunchBall()
    {
        int randomNum = Random.Range(0, 2);
        if (randomNum < 1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(65, 10 ));
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-65, 10));
        }
    }
}
