using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleController : MonoBehaviour
{
    public bool turn;
    public Rigidbody2D myRigidBody;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (turn == true)
        {
            myRigidBody.velocity = new Vector2(0, moveSpeed);
        }

        if (turn == false)
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    public void turnbird()
    {
        if (turn == true)
        {
            turn = false;
        }
        else if (turn == false)
        {
            turn = true;
        }
    }
}
