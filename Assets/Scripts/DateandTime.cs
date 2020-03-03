using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DateandTime : MonoBehaviour
{
    public DateTime quitTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(System.DateTime.UtcNow);
       
    }

    public void OnApplicationQuit()
    {
        quitTime = System.DateTime.UtcNow;
        
    }

    public void telltime()
    {
        Debug.Log(System.DateTime.UtcNow);
    }
}
