using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpMenu : MonoBehaviour
{
    public Animator anim;
    public int Umbrella;
    public Button Ellabutton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Umbrella = PlayerPrefs.GetInt("Umbrella");

        if (Umbrella > 0)
        {
            Ellabutton.interactable = true;
        }
        else
        {
            Ellabutton.interactable = false;
        }
    }

    public void OpenMenu()
    {
        anim.SetBool("up", true);
        Time.timeScale = 0;
        PlayerPrefs.SetInt("Umbrella", 1); // you would do this in the shop when the player buys the umbrella
    }

    public void UseUmbrella()
    {
        PlayerPrefs.SetInt("Umbrella", 0);
        Time.timeScale = 1;
        anim.SetBool("up", false);

    }
}
