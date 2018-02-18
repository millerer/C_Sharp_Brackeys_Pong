/*
                Adapted from the Brackeys.com 2D Pong Game tutorial by Eric Miller on 2-17-2018

                Description: 

                This is my attempt at the Brackey's Unity Tutorial for a 2D pong game. The tutorial series was done in Javascript,
                however I adapted it to use C# scripting instead. The original video tutorial series can be found at the following 
                link: https://www.youtube.com/watch?v=9h-z0AyG42k&list=PLPV2KyIb3jR4_IYZY2V0G3IUYcx1zZkJe

                Please note that all graphical and sound assets were created by the staff at Brackeys.com
 */

using UnityEngine;
using UnityEngine.UI;

public class GameSetUp : MonoBehaviour {

    //Camerca
    public Camera myCamera;

    //Player Paddles
    public Transform playerOne;
    public Transform playerTwo;

    //Arena Boundries
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;
	
    //Score text
    public  Text player1TextScore;
    public  Text player2TextScore;

    //Score int
    public  int player1Score;
    public  int player2Score;

    //init. Game settings
	void Start () {

        PlayerPrefs.SetInt("Screenmanager Resolution Width", 800);
        PlayerPrefs.SetInt("Screenmanager Resolution Height", 600);
        PlayerPrefs.SetInt("Screenmanager Is Fullscreen mode", 0);
        Screen.fullScreen = false;

        //move arena boundries
        topWall.size = new Vector2(myCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f,0f,0f)).x, 1f);
        topWall.offset = new Vector2(0f, myCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f) ;

        bottomWall.size = new Vector2(myCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, myCamera.ScreenToWorldPoint(new Vector3(0f, -10f, 0f)).y + 0.5f);

        leftWall.size = new Vector2(1f, myCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(myCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, myCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(myCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

        //Move the players to a fixed distance from the edges of the screen: 
        playerOne.transform.position = new Vector3(myCamera.ScreenToWorldPoint(new Vector3(50f, 0f, 0f)).x, playerOne.transform.position.y, 0f);
        playerTwo.transform.position = new Vector3(myCamera.ScreenToWorldPoint(new Vector3(Screen.width - 50f, 0f, 0f)).x, playerTwo.transform.position.y, 0f);

        //set scores to 0
        player1TextScore.text = "0";
        player2TextScore.text = "0";

    }

    //Add +1 to the score of either "PlayerOne" or "PlayerTwo" when called
    public void Score(string playerName)
    {
        if(playerName == "PlayerOne")
        {
            player1Score += 1;
            player1TextScore.text = player1Score.ToString();
        }
        else
        {
            player2Score += 1;
            player2TextScore.text = player2Score.ToString();
        }
    }
}
