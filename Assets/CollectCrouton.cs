using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCrouton : MonoBehaviour
{
    public bool ownFake;
    public int fake;
    public Rigidbody2D cRB;
    public SpriteRenderer sr;
    public SpriteRenderer sr2;
    public GameObject securitycam;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Fake", 1);  //only do this when you buy the fake crouton
    }

    // Update is called once per frame
    void Update()
    {
        fake = PlayerPrefs.GetInt("Fake");
        if(fake > 0)
        {
            ownFake = true;
        }
        else
        {
            ownFake = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(ownFake == true)
            {
                sr.enabled = false;
                sr2.enabled = true;
                PlayerPrefs.SetInt("Fake", 0);
                //also the player gets a big crouton bonus
            }

            else if (ownFake == false)
            {
                sr.enabled = false;
                cRB.mass = 1;
                //the player still gets a big crouton bonus
                //but the alarm is triggered because we didn't replace it
            }
        }
    }

    public void DisableSecurity()
    {
        securitycam.SetActive(false);
    }
}
