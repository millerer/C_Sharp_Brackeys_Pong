/*
                Adapted from the Brackeys.com 2D Pong Game tutorial by Eric Miller on 2-17-2018

                Description: 

                This is my attempt at the Brackey's Unity Tutorial for a 2D pong game. The tutorial series was done in Javascript,
                however I adapted it to use C# scripting instead. The original video tutorial series can be found at the following 
                link: https://www.youtube.com/watch?v=9h-z0AyG42k&list=PLPV2KyIb3jR4_IYZY2V0G3IUYcx1zZkJe

                Please note that all graphical and sound assets were created by the staff at Brackeys.com
 */

using UnityEngine;

public class PlayerControls : MonoBehaviour {

    //Movement input
    public KeyCode moveUp;
    public KeyCode moveDown;

    //Paddle Object
    public Rigidbody2D paddle;

    //Paddle Speed
    public float speed = 100f;

	// Update is called once per frame
	void Update () {
		
        //Move up or down depending on input. If niehter direction
        //is pushed, stop movement
        if (Input.GetKey(moveUp))
        {
            paddle.velocity = new Vector2(0,speed);
        }
        else if (Input.GetKey(moveDown))
        {
            paddle.velocity = new Vector2(0, -speed);
        }
        else
        {
            paddle.velocity = new Vector2(0, 0);
        }
        
	}
}
