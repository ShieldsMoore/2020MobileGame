using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedCruoton : MonoBehaviour
{
    public securitydetection sd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Crouton")
        {
            if(collision.gameObject.GetComponent<Rigidbody2D>().mass > 2)
            {
                Debug.Log("we are safe");
            }
            else if (collision.gameObject.GetComponent<Rigidbody2D>().mass <= 2)
            {
                Debug.Log("we are in trouble");
                sd.found = true;
            }
        }
    }
}
