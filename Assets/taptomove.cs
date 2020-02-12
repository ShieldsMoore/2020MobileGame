using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taptomove : MonoBehaviour
{
    Vector3 myposition;

    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {

    }


    void Update()
    
        {
            transform.position = Vector3.Lerp(transform.position, myposition, Time.deltaTime);
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
                myposition = touchPosition;
            }
        }
    }
