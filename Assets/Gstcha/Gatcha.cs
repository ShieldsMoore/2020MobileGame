using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gatcha : MonoBehaviour {

    public Button got;
    public Image button;
    public Text gotText;
    public Animator myanim;
    public Toggle spinToggle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (spinToggle.isOn == true)
        {
            myanim.SetBool("Wheel", true);
        }

        if (spinToggle.isOn == false)
        {
            myanim.SetBool("Wheel", false);
        }

    }

    public void ButtonON()
    {
        button.enabled = true;
        got.enabled = true;
        gotText.enabled = true;
    }

    public void ButtonOFF()
    {
        button.enabled = false;
        got.enabled = false;
        gotText.enabled = false;
    }


}
