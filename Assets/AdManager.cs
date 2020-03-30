using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdManager : MonoBehaviour
{
    private string adID = "3521438";// you will get this number from the dashboard

    private string videoAD = "video"; // type of ad you want to display
    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(adID, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAd()
    {
        if(Monetization.IsReady(videoAD))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoAD) as ShowAdPlacementContent;
            if(ad !=null)
            {
                ad.Show();
            }
        }
    }
}
