using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flytrigger : MonoBehaviour
{
    public flying fly;
    public Rigidbody2D rb2D;
    public PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            rb2D.gravityScale = 0;
            pc.joystick = false;
            fly.takeoff = true;
        }
    }
}
