using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ShowBanner : MonoBehaviour
{
    GameObject InitText;
    GameObject ShowButton;
    GameObject ShowText;
    GameObject AmountText;
    int userTotalCredits = 0;

    public static String REWARDED_INSTANCE_ID = "0";

    // Use this for initialization
    void Start()
    {
       
        Debug.Log("unity-script: ShowRewardedVideoScript Start called");

        ShowButton = GameObject.Find("ShowRewardedVideo");
        ShowText = GameObject.Find("ShowRewardedVideoText");
        ShowText.GetComponent<UnityEngine.UI.Text>().color = UnityEngine.Color.red;

        AmountText = GameObject.Find("RVAmount");

        IronSourceEvents.onBannerAdLoadedEvent += BannerAdLoadedEvent;
        IronSourceEvents.onBannerAdLoadFailedEvent += BannerAdLoadFailedEvent;
        IronSourceEvents.onBannerAdClickedEvent += BannerAdClickedEvent;
        IronSourceEvents.onBannerAdScreenPresentedEvent += BannerAdScreenPresentedEvent;
        IronSourceEvents.onBannerAdScreenDismissedEvent += BannerAdScreenDismissedEvent;
        IronSourceEvents.onBannerAdLeftApplicationEvent += BannerAdLeftApplicationEvent;
        IronSource.Agent.loadBanner(new IronSourceBannerSize(320, 50), IronSourceBannerPosition.BOTTOM);
    }
    //Invoked once the banner has loaded
    void BannerAdLoadedEvent()
    {
    }
    //Invoked when the banner loading process has failed.
    //@param description - string - contains information about the failure.
    void BannerAdLoadFailedEvent(IronSourceError error)
    {
    }
    // Invoked when end user clicks on the banner ad
    void BannerAdClickedEvent()
    {
    }
    //Notifies the presentation of a full screen content following user click
    void BannerAdScreenPresentedEvent()
    {
    }
    //Notifies the presented screen has been dismissed
    void BannerAdScreenDismissedEvent()
    {
    }
    //Invoked when the user leaves the app
    void BannerAdLeftApplicationEvent()
    {
       
    }

    public void LoadBanner()
    {

    }



    public void Show_Banner()
    {
        IronSource.Agent.displayBanner();
    }
    public void HideBanner()
    {
        IronSource.Agent.hideBanner();
    }
    public void DestroyBanner()
    {
        IronSource.Agent.destroyBanner();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
