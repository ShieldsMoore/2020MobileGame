using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gothit : MonoBehaviour
{
    public GameObject mover;
    public MovingObject mo;
    public Animator anim;
    public bool hit;
    public SpriteRenderer sr;
    public BoxCollider2D b2;
    public Transform start;
    
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
        if(collision.tag == "Player" && hit == false)
        {
            mo.enabled = false;
            anim.SetBool("fall", true);
            StartCoroutine(Vulnerable());
        }

        if(collision.tag == "Player" && hit == true)
        {
            StartCoroutine(Finish());
        }
    }

    IEnumerator Vulnerable()
    {
        b2.enabled = false;
        yield return new WaitForSeconds(2f);
        b2.enabled = true;
        hit = true;
    }

    IEnumerator Finish()
    {
        mo.enabled = true;
        anim.SetBool("fall", false);
        hit = false;
        transform.position = start.position;
        yield return new WaitForSeconds(.01f);
        MF_AutoPool.Despawn(mover);

    }
}
