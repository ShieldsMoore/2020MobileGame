using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BearManager : MonoBehaviour {

    public Animator myAnim;
    public float waitTime;
    public int bear;
    public SpriteRenderer sr;
    public Sprite bear1;
    public Sprite bear2;
    public Sprite bear3;
    public Sprite bear4;
    public ParticleSystem ps;
    public Button spinButton;
    public int coins;
    public Text CoinText;
    public bool spinning;

    public Image bluebear;
    public Image pinkbear;
    public Image greenbear;
    public Image goldbear;
    public Button blueButton;
    public Button pinkButton;
    public Button greenButton;
    public Button goldButton;

    public bool reset;

    //public int bearCount;

    // Use this for initialization
    void Start () {
        CoinText.text = "Coins:" + coins;

        if (reset == true)
        {
            PlayerPrefs.SetInt("BlueBear", 0);
            PlayerPrefs.SetInt("PinkBear", 0);
            PlayerPrefs.SetInt("GreenBear", 0);
            PlayerPrefs.SetInt("GoldBear", 0);
        }
    }
	
	// Update is called once per frame
	void Update () {

        CoinText.text = "Coins:" + coins;

        if (coins < 25 && !spinning)
        {
            spinButton.interactable = false;
        }

        if (coins >= 25 && !spinning)
        {
            spinButton.interactable = true;
        }

        if (bear == 0)
        {
            sr.enabled = false;
        }

        if  ( bear > 0 && bear < 75)
        {
            sr.enabled = true;
            sr.sprite = bear1;
            bluebear.enabled = true;
            StartCoroutine("BlueBear");
            ps.Play();
           
        }

        if (bear >= 75 && bear < 95)
        {
            sr.enabled = true;
            sr.sprite = bear2;
            StartCoroutine("PinkBear");
            ps.Play();
        }

        if (bear >= 95 && bear < 99)
        {
            sr.enabled = true;
            sr.sprite = bear3;
            StartCoroutine("GreenBear");
            ps.Play();
        }

        if (bear >=99)
        {
            sr.enabled = true;
            sr.sprite = bear4;
            StartCoroutine("GoldBear");
            ps.Play();
        }

        //BLUE BEAR PLAYER PREF REACTION
        if (PlayerPrefs.GetInt("BlueBear") > 0)
        {
            bluebear.enabled = true;
            blueButton.enabled = true;
        }

        if (PlayerPrefs.GetInt("BlueBear") <= 0)

        {
            bluebear.enabled = false;
            blueButton.enabled = false;
        }


        //PINK BEAR PLAYER PREF REACTION
        if (PlayerPrefs.GetInt("PinkBear") > 0)
        {
            pinkbear.enabled = true;
            pinkButton.enabled = true;
        }
        if (PlayerPrefs.GetInt("PinkBear") <= 0)

        {
            pinkbear.enabled = false;
            pinkButton.enabled = false;
        }


        //GREEN BEAR PLAYER PREF REACTION
        if (PlayerPrefs.GetInt("GreenBear") > 0)
        {
            greenbear.enabled = true;
            greenButton.enabled = true;
        }
        if (PlayerPrefs.GetInt("GreenBear") <= 0)

        {
            greenbear.enabled = false;
            greenButton.enabled = false;
        }


        //GOLD BEAR PLAYER PREF REACTION
        if (PlayerPrefs.GetInt("GoldBear") > 0)
        {
            goldbear.enabled = true;
            goldButton.enabled = true;
        }
        if (PlayerPrefs.GetInt("GoldBear") <= 0)

        {
            goldbear.enabled = false;
            goldButton.enabled = false;
        }

    }


    public void Spin()
    {
        StartCoroutine("BearLotto");
    }

    IEnumerator BearLotto()
    {
        myAnim.SetBool("Spin", true);
        spinning = true;
        spinButton.interactable = false;
        coins -= 25;
        yield return new WaitForSeconds(waitTime);
    
        myAnim.SetBool("Spin", false);
        bear = (Random.Range(1, 100));

        yield return new WaitForSeconds(1.95f);
        spinning = false;
        spinButton.interactable = true;
        bear = 0;
             
    }

    IEnumerator BlueBear()
    {
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetInt("BlueBear", PlayerPrefs.GetInt("BlueBear") + 1);
    }

    IEnumerator PinkBear()
    {
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetInt("PinkBear", PlayerPrefs.GetInt("PinkBear") + 1);
    }

    IEnumerator GreenBear()
    {
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetInt("GreenBear", PlayerPrefs.GetInt("GreenBear") + 1);
    }

    IEnumerator GoldBear()
    {
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetInt("GoldBear", PlayerPrefs.GetInt("GoldBear") + 1);
    }



}
