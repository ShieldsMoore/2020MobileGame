using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmover : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float moveSpeed;
    public float boostSpeed;
    public bool boost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boost == false)
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
        
        else if (boost == true)
        {
            rb2d.velocity = new Vector2(-boostSpeed, rb2d.velocity.y);
        }
        
    }
}
