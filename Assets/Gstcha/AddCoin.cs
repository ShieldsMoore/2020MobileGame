using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoin : MonoBehaviour {

    public BearManager bm;
    public int coinsToAdd;
	// Use this for initialization
	void Start () {

        bm = FindObjectOfType<BearManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddCoins()
    {
        bm.coins += coinsToAdd;
    }
}
