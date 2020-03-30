using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd2 : MonoBehaviour {

	public string levelToLoad;

	public PlayerController thePlayer;
	public CameraController theCamera;
	public LevelManager theLevelManager;

	public float waitToMove;
	public float waitToLoad;
	private bool movePlayer;

	public GameObject pauseScreen;

    public bool tutorial;

    public float score;
    public float scoretobeatlevel;
    public GameObject LevelEndScreen;
    public Text scoreText;
    public bool levelactive;
    public Text finalscore;
    public Image goldstar;



	// Use this for initialization
	void Start () {

       
        

    }
	
    //IEnumerator FindPlayer()
    //{
    //    //yield return new WaitForSeconds(.25f);
    //  
    //
    //}
	// Update is called once per frame
	void FixedUpdate () {
        if(levelactive == true)
        {
            scoreText.text = "score:" + (Mathf.RoundToInt(score));
            score += .025f; // this just adds score over time
                            // would need to set score back to 0 when player dies
        }

        finalscore.text = "FINAL SCORE:" + (Mathf.RoundToInt(score));
        // this could also count collectibles or even give the person a rank (bronze, silver, gold)

        if (score > 100)
        {
            //goldstar.enabled = true;
            // have a gold star show up or a silver star etc
        }

        thePlayer = FindObjectOfType<PlayerController>();
        if (movePlayer) 
		{
			thePlayer.myRigidBody.velocity = new Vector3 (thePlayer.moveSpeed, thePlayer.myRigidBody.velocity.y, 0f);
		}

        if (score >= scoretobeatlevel)
        {
            LevelEnd(); // we call the end of the level when we get the right score
        }
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "Player")
			{
            //SceneManager.LoadScene(levelToLoad);
            LevelEnd();
			}

        if (tutorial == true)
        {
            PlayerPrefs.SetInt("LvlStart", 1);
        }
	}

	public void LevelEnd()
	{
        levelactive = false;
		thePlayer.canMove = false;
		theCamera.followTarget = false;
		//pauseScreen.SetActive (false);
		theLevelManager.invincible = true;
		thePlayer.myRigidBody.velocity = Vector3.zero;

        //ADD ANY PLAYER PREFS YOU WANT THE GAME TO REMEMBER
        // POWER UP, LIVES, CURRENT LEVEL ETC (you can name as many as you want)
		//PlayerPrefs.SetInt ("CoinCount", theLevelManager.coinCount);
		//PlayerPrefs.SetInt ("PlayerLives", theLevelManager.currentLives);
        //PlayerPrefs.SetInt("GB", 2);

        theLevelManager.levelMusic.Stop ();
		theLevelManager.gameOverMusic.Play ();

        // COMMENT OUT ALL BELOW HERE

        //yield return new WaitForSeconds (waitToMove);
        //movePlayer = true;
        //
        //yield return new WaitForSeconds (waitToLoad);
        //SceneManager.LoadScene(levelToLoad);

        LevelEndScreen.SetActive(true); // this will turn on our level end screen which will
                                        // be a graphic overlay with buttons that we can use to
                                        // open the next scene, visit the shop or remove ads whatever we want
       
	}
}
