using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBears : MonoBehaviour
{
    public SpriteRenderer sr;
    public CircleCollider2D c2d;

    public SpriteRenderer sr2;
    public CircleCollider2D c2d2;

    public SpriteRenderer sr3;
    public CircleCollider2D c2d3;

    public SpriteRenderer sr4;
    public CircleCollider2D c2d4;

    public GameObject bear;
    public bool canPlace;

    public GameObject bluebear;
    public GameObject pinkbear;
    public GameObject greenbear;
    public GameObject goldbear;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);



        if (Input.GetMouseButtonDown(0) && canPlace == true) // this also works when you press with your finger on mobile
            {
                if (hit.collider != null && hit.collider.tag == "BearSpot")
                {
                    sr.enabled = false;
                    c2d.enabled = false;
                    Instantiate(bear, hit.point, Quaternion.identity);
                    Debug.Log("HIT");
                    bear = null;
                    canPlace = false;

            }

                if (hit.collider != null && hit.collider.tag == "BearSpot2")
                {
                    sr2.enabled = false;
                    c2d2.enabled = false;
                    Instantiate(bear, hit.point, Quaternion.identity);
                    Debug.Log("HIT2");
                    bear = null;
                    canPlace = false;
            }

                if (hit.collider != null && hit.collider.tag == "BearSpot3")
                {
                    sr3.enabled = false;
                    c2d3.enabled = false;
                    Instantiate(bear, hit.point, Quaternion.identity);
                    Debug.Log("HIT3");
                    bear = null;
                    canPlace = false;
            }

                if (hit.collider != null && hit.collider.tag == "BearSpot4")
                {
                    sr4.enabled = false;
                    c2d4.enabled = false;
                    Instantiate(bear, hit.point, Quaternion.identity);
                    Debug.Log("HIT4");
                    bear = null;
                    canPlace = false;

            }
            
            // you can have another if statement if you press an ingredient
            // set a PlayerPrefs value for the ingredient 0 = not having it 1 = having it
            // if you have all ingredients the fusion buttons becomes interactable (you could also show the ingredients appear as sprites as you collect them)

        }
    }

   public void Blue()
    {
        bear = bluebear;
        PlayerPrefs.SetInt("BlueBear", 0);
        canPlace = true;
    }

   public void Pink()
    {
        bear = pinkbear;
        PlayerPrefs.SetInt("PinkBear", 0);
        canPlace = true;
    }

   public void Green()
    {
        bear = greenbear;
        PlayerPrefs.SetInt("GreenBear", 0);
        canPlace = true;
    }

  public void Gold()
    {
        bear = goldbear;
        PlayerPrefs.SetInt("GoldBear", 0);
        canPlace = true;
    }
}
