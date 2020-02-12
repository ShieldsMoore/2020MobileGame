using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batfly : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector2(-moveSpeed, 0);
    }
}
