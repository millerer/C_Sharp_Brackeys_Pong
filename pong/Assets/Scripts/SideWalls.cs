/*
                Adapted from the Brackeys.com 2D Pong Game tutorial by Eric Miller on 2-17-2018

                Description: 

                This is my attempt at the Brackey's Unity Tutorial for a 2D pong game. The tutorial series was done in Javascript,
                however I adapted it to use C# scripting instead. The original video tutorial series can be found at the following 
                link: https://www.youtube.com/watch?v=9h-z0AyG42k&list=PLPV2KyIb3jR4_IYZY2V0G3IUYcx1zZkJe

                Please note that all graphical and sound assets were created by the staff at Brackeys.com
 */

using UnityEngine;

public class SideWalls : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Assign a new score when the ball hits the left or right walls
        if(collision.name =="Ball")
        {
            //play sound FX to indicate a score
            gameObject.GetComponent<AudioSource>().Play();

            string playerName;
            
            if(gameObject.name == "LeftWall")
            {
                playerName = "PlayerTwo";
            }
            else
            {
                playerName = "PlayerOne";
            }

            FindObjectOfType<GameSetUp>().Score(playerName);

            //Reset the ball position by calling the colliding ball object
            collision.gameObject.SendMessage("ResetBall");

        }
    }
}
