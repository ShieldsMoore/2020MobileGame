using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platforms;
    public bool boosting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        platforms = GameObject.FindGameObjectsWithTag("MP");

        if (boosting == true)
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].GetComponent<platformmover>().boost = true;
            }
        }

        else
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].GetComponent<platformmover>().boost = false;
            }
        }
    }

    //public void moveFaster()
    //{
    //    boosting = true;
    //}
    //
    //public void moveSlower()
    //{
    //    boosting = false;
    //}
}
