using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayEnemy : MonoBehaviour
{
    public Rigidbody2D enemyRB;
    public Animator myanim;
    public float moveSpeed;
    public float jumpSpeed;
    public float leapSpeed;
    private RaycastHit2D lookRight;
    private RaycastHit2D lookLeft;
    private RaycastHit2D lookUp;
    private RaycastHit2D lookDown;
    public LayerMask layerMask;
    public LayerMask groundMask;
    public bool facingRight;


    void Start()
    {
        facingRight = false;

    }

    // Update is called once per frame
    void Update()
    {

        lookRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, 3f, layerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.right, Color.yellow);

        lookLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, 3f, layerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.left, Color.blue);

        lookUp = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.up, 3f, layerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.up, Color.red);

        lookDown = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, 1f, groundMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.down, Color.green);

        if (lookLeft.collider != null && lookLeft.collider.tag == "Player")
        {
            enemyRB.velocity = new Vector2(-moveSpeed, enemyRB.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
            facingRight = false;
            myanim.SetBool("Seen", true);
        }

        else if (lookRight.collider != null && lookRight.collider.tag == "Player")
        {
            enemyRB.velocity = new Vector2(moveSpeed, enemyRB.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
            facingRight = true;
            myanim.SetBool("Seen", true);
        }

        else
        {
            enemyRB.velocity = new Vector2(enemyRB.velocity.x, enemyRB.velocity.y);
            myanim.SetBool("Seen", false);
        }


        if (lookUp.collider != null && lookUp.collider.tag == "Player")
        {

            enemyRB.velocity = new Vector2(enemyRB.velocity.x, jumpSpeed);
            myanim.SetBool("Seen", true);
        }

        if (lookDown.collider != null && lookDown.collider.tag == "Gap")
        {
            if (facingRight == true)
            {
                enemyRB.velocity = new Vector2(leapSpeed, jumpSpeed);
                myanim.SetBool("Seen", true);
            }

            else if (facingRight == false)
            {
                enemyRB.velocity = new Vector2(-leapSpeed, jumpSpeed);
                myanim.SetBool("Seen", true);
            }
        }
    }
}


