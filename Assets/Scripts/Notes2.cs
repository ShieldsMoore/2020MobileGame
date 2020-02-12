using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // this lets you call Images which are used in the UI Buttons, Toggles
using UnityEngine.SceneManagement; // This lets you call scenemanager which loads levels
using UnityEngine.Audio; // this calls the audio mixer
public class Notes2 : MonoBehaviour
{
    //Rob Shields
    public Notes2 n2;
    public GameObject GO;
    public Image myimage;
    public Button mybutton;
    public float timer;
    // Start is called before the first frame update
    //AI
    //MOVE TOWARDS (moves object towards another) flying follower enemy uses this
    public Vector3 start; // the start location
    public Vector3 finish; // the end location or target
    public float speed; // how fast the mover goes from start to finish
    //LOOT
    public GameObject money;

    //ARRAY an array is a collection of gameObjects. arrays allows us to affect large groups
    // of objects

    public GameObject[] alltheenemies; // the straight brackets signify a collection of gameobjects

    //PLAYER PREFS
    // these are values that will save even after the player leaves the game.  this is good
    // for unlockable content or overall progress. this can also work for character skins

    public int GreenBird;// this is not a player pref just a normal int

    void Start()
    {
        PlayerPrefs.SetInt("GreenBird", 2); // this will unlock the green bird so I would only
        // do this when I am ready to unlock it before this it would be set to 0 or 1

        if (PlayerPrefs.HasKey("GreenBird"))
        {
            GreenBird = PlayerPrefs.GetInt("GreenBird"); // if I beat the game it will be 2
            // if I didn't the beat the game yet it will be 1
        }

        if(GreenBird == 2)
        {
            // I can select the green bird
        }

        alltheenemies = GameObject.FindGameObjectsWithTag("enemy"); // this grabs all enemies
        //ENABLED VS SET ACTIVE
        // we enabled and disable components attached to gameObjects 
        // we set active true or false entire gameObjects

        n2.enabled = true; // enabled the notes2 script (box collider, scripts, any componenet)
        GO.SetActive(true); // enabled the entire gameobject
        StartCoroutine(StarPower());// this line calls the IEnumerator (don't do this in update)
    }

    // Update is called once per frame
    void Update()
    {
        //TIMERS
        //we can create timers using the commaned Time.deltaTime.  This means time that has
        // passed since the last frame (so a constant timer). we can take a float and add or
        // subtract Time.deltaTime to create a timer that counts up or down
        timer -= Time.deltaTime; // -= subtracts time from the timer consistently
        timer += Time.deltaTime; // += adds time to the timer

        if(timer >= 0)
        {
            mybutton.interactable = true;// this allows the button to be pressed
        }

        if (timer < 0)
        {
            mybutton.interactable = false;// this greys the button out and cannot be prssed
        }

        Vector3.MoveTowards(start, finish, speed); // this line will move the object
        // the start position is set to the movers position
        // the target position gets set to another gamobject (usually the player)
        // the speed is constant 


        //INSTANTIATE is a way to make things appear in our scene, this could be enemies loot
        //power ups 

        GameObject loot = Instantiate(money, transform.position, transform.rotation);
        // the above line makes a new gameobject by creating money at out current location
        // we say GameObject loot because we are creating a new gameobject in the hierachy call loot
        // money is usually a prefab that we can call over and over again  this means money
        // won't be in the hierarchy but inside the game's asset folder
        Destroy(money, 5f); // this destroys the money if we don't get it fast enough

        //AUTOPOOLING  we are using a plugin called Mob Farm Auto Pooler
        GameObject loot2 = MF_AutoPool.Spawn(money, transform.position, transform.rotation);
        // this is the mobile friendly version 
        MF_AutoPool.Despawn(this.gameObject, 5f); // this line would be on the money gameObject 
        //put it back into the pool without any left over issues 

        //ARRAY (How to go through your list and affect each object one at a time)
        //FOR LOOP
        for (int i = 0; i < alltheenemies.Length; i++)
        {
            alltheenemies[i].SetActive(true);// we set each enemy active
        }
        // int i = 0 means we start at the top of the list
        // i < allenemies, means as long as the number we are on isn't larger than the list
        // i++ we move down the list by one
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this statement is used when we want the player to walk into a specific area and
        //trigger something.  this could be an animation, enemy, really anything we want
        // an event is triggered when the player passes through a colldier that is marked
        // as a trigger.  Either the player or the collider must have a rigidbody in order
        // for the hit to register.

        if(collision.tag == "Player")
        {
            //then we trigger the event.  this will only trigger if the collider has the tag
            //player so enemies can't trigger this event
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // unlike a trigger a collision happens when two colliders bump into eachother but
        // do not pass through
    }

    //CO-ROUTINE  which unit calls IEnumerator
    // normal functions in unity are read top to bottom all at once.  sometimes we want
    // to pause before finishing the function which is when we use IEnumerator
    //think of this as the star power is SMB, when you get the star the player is invincible
    // for a short time, the sprite changes, the music changes and then eventually it wears off

    public IEnumerator StarPower()
    {
        //give Mario star power
        //change music
        //change sprite graphics
        // then we want to wait
        yield return new WaitForSeconds(5f); // this line makes Unity wait for 5 seconds
                                             // star power wears off
                                             //change music back
                                             //change sprite back
        yield return new WaitForSeconds(5f);
    }

    // to call an IEnumerator we use the word Co-Routine (see Start loop)
}
