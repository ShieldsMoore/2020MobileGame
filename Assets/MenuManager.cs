using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //The below two are animators for 2 UI components that contain both images, text and buttons
    public Animator simplenav;
    public Animator inventoryholder;
    public bool MenuOpen;

    // the below variables are needed to enabled the party hat and have it make a change to the player
    public PlayerController pc;
    public int PartyHat;
    public GameObject inventoryHat; // button in our inventory
    public bool wearHat; // bool that tells us if we are wearing the hat
    public GameObject Birthdayhat; // the actual hat object on the bird's head

    // this keeps track of the player's gold
    public int goldCount;
    public Text goldText;

    // All Items in my shop are buttons so that when I click them they can do something
    public Button ShopHat;
    public Button ShopSlime;
    public Button ShopSkelly;
    // if we own something we might not want to purchase it again
    public bool ownHat;
    public bool ownSlime;
    public bool ownSkelly;


    void Start()
    {
       //goldCount = PlayerPrefs.GetInt ("Gold");  //if you want to save gold across sessions
    }

    void Update()
    {

        //PlayerPrefs.SetInt("Gold", goldCount);  //if you want to save gold across sessions

        goldText.text = "Gold:" + goldCount;
        PartyHat = PlayerPrefs.GetInt("PartyHat"); 

        if (PartyHat == 1) 
        {
            inventoryHat.SetActive(true);  // turns on the hat button in our inventory
        }

        if (wearHat == true) 
        {
            pc.moveSpeed = 8; // +3 moveSpeed
            pc.jumpSpeed = 18; // +8 jumpSpeed
            Birthdayhat.SetActive(true); // lets us see the hat on the bird
        
        }
        if(wearHat == false)  // this will set up back to standard speed if we turn off the hat
        {
            pc.moveSpeed = 5;
            pc.jumpSpeed = 10;
            Birthdayhat.SetActive(false);
        }

        if (goldCount >= 1 && ownHat == false) // if we have enough gold and didn't buy the hat yet 
        {
            ShopHat.interactable = true; // the hat button is now clickable in the shop
        }
    }


    public void OpenNav()
    {
        if (MenuOpen == false)
        {
            simplenav.SetBool("Open", true);
            Time.timeScale = 0;
            MenuOpen = true;
        }

        else if (MenuOpen == true)
        {
            simplenav.SetBool("Open", false);
            Time.timeScale = 1;
            MenuOpen = false;
        }
      
    }

    public void CloseNav()
    {
        simplenav.SetBool("Open", false);
        Time.timeScale = 1;
        MenuOpen = false;
    }

    public void OpenInv()
    {
        inventoryholder.SetBool("Open", true);
    }

    public void CloseInv()
    {
        inventoryholder.SetBool("Open", false);
    }

    public void BuyHat()
    {
        goldCount -= 1;
        PlayerPrefs.SetInt("PartyHat", 1);
        ShopHat.interactable = false;
        ownHat = true;
    }

    public void PutOnHat()
    {
        wearHat = true;
        
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("PartyHat", 0);
        inventoryHat.SetActive(false);
        wearHat = false;
    }
}

 