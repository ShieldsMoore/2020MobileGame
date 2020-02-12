using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    //Rob Shields
    //Two forwards slashes allow you to write notes which Unity does not read as code
    // The top of the script is generally where we place variables which we manipulate later
    // Variables have 3 parts, 
    // public vs private
    // the type of variable
    // the name we give for the variable

    //NUMBER VARIABLES
    // the two most common types are floats and ints
    public float number; // floats are floating point numbers or decimal numbers 1.25 is a float
    public int wholenumber; // ints are whole numbers 1,2,3 etc no decimals allowed
    private float myhiddennumber;// private variables are not shown in the Unity inspector

    //BOOLS
    public bool yesorno; // a bool is a true or flase statement, a binary, think of it like a 
    //light switch its either on or off no in between

    //OTHER COMMON VARIABLES
    public GameObject myGameObject; // we can reference any object in our scene.  every items
    // in the hierarchy is considered a gameobject
    public Notes mynotescript; // we can reference scripts as well as long as they are public
    public Rigidbody2D myRB2D; // we use rigidbodies to make gameobjects affected by unity's 
    //physics engine 2D and 3D are independent
    public BoxCollider2D myboxcollider; // we can reference colliders of all types as well
    public CircleCollider2D mycirclecollider; // if you make a 3D game just drop the 2D
    // pretty much any component that we can add to a gameobject can be reference as a variable
    // Start is called before the first frame update
    void Start()
    {
        //ENABLED VS SET ACTIVE 
        //componenets in the inspector can be enabled and disabled
        myboxcollider.enabled = true; // small check boxes inside the gameobject
        myGameObject.SetActive(true); // the whole game object
        //anything that we want to happen when the game starts goes here. it is only called once
        //when the game first starts
        //if we don't want to drag and drop all variables into the inspector there are a few
        //commands that will do this for us automatically but they do take processing power
        //generally we only do this when we have to such as when we spawn the player
        myRB2D = GetComponent<Rigidbody2D>(); // this will get the rigidbody but only if it is
        // on the same object as our script
        myRB2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        // this allows us to get our rigid body from another gameobject with the tag player
        myRB2D = GameObject.FindObjectOfType<Rigidbody2D>();
        // the above will only work for one rigidbody 2D and will grab the first one it can find
        // generally we only use FindObjectofType when there only a singular object of that type

        //another thing we look at in START is a gameobjects Transform
        // a Transform is the position, rotation and scale of a gameobject

        transform.position = new Vector2(0, 0); // this is our location on the x and y axis
        transform.position = new Vector3(0, 0, 0); // this is x, y, z in 3D space
        // x is horizontal axis (walking)
        // y is vertical axis (jumping)
        // z is depth (also walking if in a 3D game)
        transform.position = new Vector2(24, 128); // this line would teleport the game object
        // 24 units horizontally and 128 units vertically

        transform.localScale = new Vector2(1, 1); //this is standard scale (0,0) would be invisible
        // rotation is a bit different we have to use Quaternion and EULER (oiler)
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.identity; //this is the current rotation of the object

    }
    // Update is called once per frame
    void Update()
    {
        // inside update we call things that we want to change in real time as the player is playing
        // player controls, enemy controlls, points, health etc all happen inside the update loop

        //IF STATEMENTS
        // if (something)
        //{
        //  then we do this
        // }

        if (yesorno == true)
        {
            //we say yes
            //the player lives
        }

        if (yesorno == false)
        {
            //we say no
            // the player dies
        }
        // this is bascially how a bool works we check the value and execute different commands
        // depending on the value of the bool (true or false) (check on unchecked)
        // the double equal sign is needed for this to work as its checks to see IF the statement
        // is true of false  "yesorno = true" automatically sets the bool to be true
        if (number >= 10)
        {
            //we do something
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            //move the player
            myRB2D.velocity = new Vector2(2, myRB2D.velocity.y);// we don't alter the y here
            // so that the jump doesn't get affected
        }

        if(Input.GetAxis("Horizontal") == 0)
        {
            //stop the player
            myRB2D.velocity = new Vector2(0, myRB2D.velocity.y);
        }

        //RIGID BODY PROPERTIES
        myRB2D.gravityScale = 0; //this turns off gravity
        myRB2D.simulated = false; // this makes you invicible (things can pass through you)
        myRB2D.isKinematic = true; // when this is true the rigidbody only moves when the code
                                   //tells it to
        myRB2D.isKinematic = false; // gravity will affect me when this is false

        //IF ELSE STATEMENTS
        // normally if statement are read one after the other which can cause weird behavior
        // we can use if else statements to stop the if statements 

        if (yesorno == true)
        {
            //we say yes
            //the player lives
            // sometimes bools (or if statements)change too fast which makes for weird behavior
        }

        else if (yesorno == false)
        {
            // this only happens if the above if statement is not true
            //we say no
            // the player dies
        }
    }

    private void FixedUpdate()
    {
        // regular update is dependent of the frame of the game.  this means newer devices 
        // will play the game faster and older devices will play the game slower which is not
        // ideal.  FIXED UPDATE updates at a set interval which means all machines run the code
        // at the same speed.  we put physics code inside fixed update
    }

    //TRIGGER STATEMENTS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // this statement is used generally when we want the player to trigger something
        // it could an enemy, an animation, music really anything we want
        // an event is triggered when the player passes through a collider marked as trigger
        if(collision.tag == "Player")
        {
            //we execute the event
        }

        // normally we check to see the tag of the collision so only the player can trigger
        // the event
        // for the event to trigger one object needs to have a rigidbody(either the player or
        // the object that has the trigger collider on it
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // same as trigger except we don't pass through the collider and the collider is not
        //marked as a trigger.  this will trigger events when we bump into a collider 
    }

}
