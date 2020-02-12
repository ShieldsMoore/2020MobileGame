using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTimer : MonoBehaviour
{
    public float timer;
    public float waitTime;
  
    public Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            myButton.interactable = true;
        }
        if(timer < waitTime)
        {
            myButton.interactable = false;

        }
    }

    public void Resettimer()
    {
        timer = 0;
    }
}
