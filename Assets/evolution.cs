using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evolution : MonoBehaviour
{
    public int red;
    public int green;
    public int blue;

    public int total;

    public Animator anim;

    public bool canRed;
    public bool canGreen;
    public bool canBlue;

    public int maxBlue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        total = red + green + blue;


        // SINGLE EVO 

        if (red > 5)
        {
            canRed = true;
        }

        if (green > 5)
        {
            canGreen = true;
        }

        if(blue > maxBlue)
        {
            canBlue = true;
        }

       if ((red/total) >= .75f && canRed)
            {
            anim.SetBool("evo1", true);
            anim.SetBool("evo2", false);
            anim.SetBool("evo3", false);

            if (red > 250)
            {
                anim.SetBool("evo1A", true);
            }

            }

        if ((green/total) >= .75f && canGreen)
        {
            anim.SetBool("evo1", false);
            anim.SetBool("evo2", true);
            anim.SetBool("evo3", false);
          
            if (green > 250)
            {
                anim.SetBool("evo2A", true);
            }

            if (green > 500)
            {
                anim.SetBool("evo2B", true);
            }

        }

        if ((blue/total) >= .75f && canBlue)
        {
            anim.SetBool("evo1", false);
            anim.SetBool("evo2", false);
            anim.SetBool("evo3", true);

            if (blue > 250)
            {
                canRed = false;
                canGreen = false;
                anim.SetBool("evo3A", true);
            }
        }

        // COMBO EVO x 2
        // THESE DO NOT HAVE A MAX SO JUST 1 of each color would cause the evolution

        if((red/total) >= .5f && (blue/total) >= .5f)
        {
            anim.SetBool("evo4", true);
        }

        if ((green/ total) >= .5f && (blue / total) >= .5f)
        {
            anim.SetBool("evo5", true);
        }

        if ((red / total) >= .5f && (green / total) >= .5f)
        {
            anim.SetBool("evo6", true);
        }

        //COMBO EVO x 3

        if ((red / total) >= .33f && (blue / total) >= .33f  && (green/total) >= .33f)
        {
            anim.SetBool("evo7", true);
        }






    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "red")
        {
            red += 1;
        }

        if (collision.tag == "green")
        {
            green += 1;
        }

        if(collision.tag == "blue")
        {
            blue += 1;
        }
    }
}

