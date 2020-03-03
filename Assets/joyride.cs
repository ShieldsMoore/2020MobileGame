using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class joyride : MonoBehaviour
{

    public Rigidbody2D myRB2d;
    public float jetpower;
    public bool up;
    public GameObject cannonball;
    // Start is called before the first frame update
    void Start()
        
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(up == true)
        {
            myRB2d.velocity = new Vector2 (0, jetpower);
        }

        else
        {
            myRB2d.velocity = new Vector2(0, 0);
        }

        if (CnInputManager.GetButtonDown("Shoot"))
        {

            MF_AutoPool.Spawn(cannonball, transform.position, transform.rotation);
            cannonball.GetComponent<cannonball>().powerup = 10;
        }
    }

    public void poweron() 
    {
        up = true;

    }

    public void poweroff()
    {
        up = false;
    }
}
