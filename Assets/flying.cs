using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flying : MonoBehaviour
{

    public bool takeoff;
    public Rigidbody2D rb2D;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (takeoff == true)
        {

            rb2D.velocity = new Vector2(moveSpeed, 0);

            if (Input.touchCount > 0)
            {
                // The screen has been touched so store the touch

                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {

                    // If the finger is on the screen, move the object smoothly to the touch position

                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0.0f));

                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, touchPosition.y, transform.position.z), Time.deltaTime * 5.0f);
                }

            }
        }
    }
}
