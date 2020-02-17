using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTimer : MonoBehaviour
{
    public float timer;
    public float waitTime;
  
    public Button myButton;
    public int hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;

       // if (timer > waitTime)
       // {
       //     myButton.interactable = true;
       // }
       // if(timer < waitTime)
       // {
       //     myButton.interactable = false;
       //
       // }

        /// above or below but not both

        if(hit < 3)
        {
            myButton.interactable = true;
        }
        
        else if (hit == 3)
        {
            myButton.interactable = false;
            StartCoroutine(ResetHits());
        }
    }

    public void Resettimer()
    {
        timer = 0;
    }

    public void addhit()
    {
        hit += 1;
    }

    IEnumerator ResetHits()
    {
        yield return new WaitForSeconds(2f);
        hit = 0;
    }
}
