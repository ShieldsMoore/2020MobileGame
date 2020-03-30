using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public string mainMenu;
    private LevelManager theLevelManager;

    public string leveltoload;
 

    // Use this for initialization
    void Start() {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void Restart()
    {
        // if we restart the level we can also reset our progress
        //PlayerPrefs.SetInt ("CoinCount", 0);
        //PlayerPrefs.SetInt ("PlayerLives", theLevelManager.startingLives);

        // this is the command to reload our current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void LoadLevel()
    {
    SceneManager.LoadScene(leveltoload);  // we want to load a new loading scene depending
                                          // on which level you want

    }

	public void QuitToMainMenu()
	{
		SceneManager.LoadScene (mainMenu);
	}


}
