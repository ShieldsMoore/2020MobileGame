using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomattack : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attack()
    {
        int randomNumber = Random.Range(1, 3);
        anim.SetTrigger("atk" + randomNumber);
       
    }
}
