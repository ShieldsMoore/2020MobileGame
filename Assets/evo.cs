using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class evo : MonoBehaviour
{
    public Image evobar1;
    public Image evobar2;
    public float evo1;
    public float evo2;
    public float current;
    public Animator anim;
    public bool evo1complete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        evobar1.fillAmount = (current/evo1);
        evobar2.fillAmount = (current/evo2);

        if (evobar1.fillAmount == 1 && evo1complete == false)
        {
            current = 0;
            // you can also enable text that say "TO NEXT EVO" 
            evobar1.enabled = false;
            evobar2.enabled = true;
            anim.SetBool("evo1", true);
            evo1complete = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "absorb")
        {
           
            current += 1;
            // also subtract one from "TO NEXT EVO"
        }
    }
}
