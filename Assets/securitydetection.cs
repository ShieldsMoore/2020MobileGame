using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class securitydetection : MonoBehaviour
{

    public GameObject[] seekers;
    public bool found;
    public Text exclimation;
    // Start is called before the first frame update
    void Start()
    {
        seekers = GameObject.FindGameObjectsWithTag("seeker"); 
    }

    // Update is called once per frame
    void Update()
    {
        if(found == true)
        {

       for(int i = 0; i < seekers.Length; i++)
        {
            seekers[i].GetComponent<FlyingEnemy>().playertarget = true;
        }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            found = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            exclimation.enabled = true;
            //play a warning sound  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exclimation.enabled = false;
    }
}
