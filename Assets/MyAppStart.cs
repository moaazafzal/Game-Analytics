using UnityEngine;
using System.Collections;
using GameAnalyticsSDK;
public class MyAppStart : MonoBehaviour
{
    public static MyAppStart instance;
	public  string uniqueUserId = "demoUserUnity";
	public  string appKey = "a934fc75";
    GameObject InitText;
    GameObject ShowButton;
    GameObject ShowText;
    GameObject AmountText;
    int userTotalCredits = 0;
    // Use this for initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
          

        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    void Start ()
	{
        GameAnalytics.Initialize();
        IronSource.Agent.setAdaptersDebug(true);
        Debug.Log ("unity-script: MyAppStart Start called");

		//Dynamic config example
		IronSourceConfig.Instance.setClientSideCallbacks (true);

		string id = IronSource.Agent.getAdvertiserId ();
	
		

		



        IronSourceEvents.onBannerAdLoadedEvent += BannerAdLoadedEvent;
        IronSourceEvents.onBannerAdLoadFailedEvent += BannerAdLoadFailedEvent;
        IronSourceEvents.onBannerAdClickedEvent += BannerAdClickedEvent;
        IronSourceEvents.onBannerAdScreenPresentedEvent += BannerAdScreenPresentedEvent;
        IronSourceEvents.onBannerAdScreenDismissedEvent += BannerAdScreenDismissedEvent;
        IronSourceEvents.onBannerAdLeftApplicationEvent += BannerAdLeftApplicationEvent;



        IronSourceEvents.onInterstitialAdReadyEvent += InterstitialAdReadyEvent;
        IronSourceEvents.onInterstitialAdLoadFailedEvent += InterstitialAdLoadFailedEvent;
        IronSourceEvents.onInterstitialAdShowSucceededEvent += InterstitialAdShowSucceededEvent;
        IronSourceEvents.onInterstitialAdShowFailedEvent += InterstitialAdShowFailedEvent;
        IronSourceEvents.onInterstitialAdClickedEvent += InterstitialAdClickedEvent;
        IronSourceEvents.onInterstitialAdOpenedEvent += InterstitialAdOpenedEvent;
        IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;



        IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedVideoAdOpenedEvent;
        IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedVideoAdClosedEvent;
        IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
        IronSourceEvents.onRewardedVideoAdStartedEvent += RewardedVideoAdStartedEvent;
        IronSourceEvents.onRewardedVideoAdEndedEvent += RewardedVideoAdEndedEvent;
        IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedVideoAdRewardedEvent;
        IronSourceEvents.onRewardedVideoAdShowFailedEvent += RewardedVideoAdShowFailedEvent;
























        // SDK init
        Debug.Log ("unity-script: IronSource.Agent.init");
	//	IronSource.Agent.init (appKey);
		IronSource.Agent.init (appKey, IronSourceAdUnits.REWARDED_VIDEO, IronSourceAdUnits.INTERSTITIAL, IronSourceAdUnits.OFFERWALL, IronSourceAdUnits.BANNER);
        //IronSource.Agent.initISDemandOnly (appKey, IronSourceAdUnits.REWARDED_VIDEO, IronSourceAdUnits.INTERSTITIAL);
        //For Rewarded Video
        IronSource.Agent.init(appKey, IronSourceAdUnits.REWARDED_VIDEO);
        //For Interstitial
        IronSource.Agent.init(appKey, IronSourceAdUnits.INTERSTITIAL);
        //For Offerwall
        IronSource.Agent.init(appKey, IronSourceAdUnits.OFFERWALL);
        //For Banners
        IronSource.Agent.init(appKey, IronSourceAdUnits.BANNER);
        //Set User ID For Server To Server Integration
        //// IronSource.Agent.setUserId ("UserId");
        IronSource.Agent.validateIntegration();
        // Load Banner example
        //IronSource.Agent.loadBanner (IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
    }

    // Update is called once per frame
    #region reward
  

    /************* RewardedVideo Delegates *************/ 
	void RewardedVideoAvailabilityChangedEvent (bool canShowAd)
	{
		Debug.Log ("unity-script: I got RewardedVideoAvailabilityChangedEvent, value = " + canShowAd);
		if (canShowAd) {
			ShowText.GetComponent<UnityEngine.UI.Text> ().color = UnityEngine.Color.blue;
		} else {
			ShowText.GetComponent<UnityEngine.UI.Text> ().color = UnityEngine.Color.red;
		}
	}

	void RewardedVideoAdOpenedEvent ()
	{
		Debug.Log ("unity-script: I got RewardedVideoAdOpenedEvent");
	}

	void RewardedVideoAdRewardedEvent (IronSourcePlacement ssp)
	{
		Debug.Log ("unity-script: I got RewardedVideoAdRewardedEvent, amount = " + ssp.getRewardAmount () + " name = " + ssp.getRewardName ());
		userTotalCredits = userTotalCredits + ssp.getRewardAmount ();
		AmountText.GetComponent<UnityEngine.UI.Text> ().text = "" + userTotalCredits;
	}
	
	void RewardedVideoAdClosedEvent ()
	{
		Debug.Log ("unity-script: I got RewardedVideoAdClosedEvent");
	}

	void RewardedVideoAdStartedEvent ()
	{
		Debug.Log ("unity-script: I got RewardedVideoAdStartedEvent");
	}

	void RewardedVideoAdEndedEvent ()
	{
		Debug.Log ("unity-script: I got RewardedVideoAdEndedEvent");
	}
	
	void RewardedVideoAdShowFailedEvent (IronSourceError error)
	{
		Debug.Log ("unity-script: I got RewardedVideoAdShowFailedEvent, code :  " + error.getCode () + ", description : " + error.getDescription ());
	}

	

    #endregion


    #region interStitial

   

    /************* Interstitial Delegates *************/
    void InterstitialAdReadyEvent()
    {
        Debug.Log("unity-script: I got InterstitialAdReadyEvent");
        ShowText.GetComponent<UnityEngine.UI.Text>().color = UnityEngine.Color.blue;
    }

    void InterstitialAdLoadFailedEvent(IronSourceError error)
    {
        Debug.Log("unity-script: I got InterstitialAdLoadFailedEvent, code: " + error.getCode() + ", description : " + error.getDescription());
    }

    void InterstitialAdShowSucceededEvent()
    {
        Debug.Log("unity-script: I got InterstitialAdShowSucceededEvent");
        ShowText.GetComponent<UnityEngine.UI.Text>().color = UnityEngine.Color.red;
    }

    void InterstitialAdShowFailedEvent(IronSourceError error)
    {
        Debug.Log("unity-script: I got InterstitialAdShowFailedEvent, code :  " + error.getCode() + ", description : " + error.getDescription());
        ShowText.GetComponent<UnityEngine.UI.Text>().color = UnityEngine.Color.red;
    }

    void InterstitialAdClickedEvent()
    {
        Debug.Log("unity-script: I got InterstitialAdClickedEvent");
    }

    void InterstitialAdOpenedEvent()
    {
        Debug.Log("unity-script: I got InterstitialAdOpenedEvent");
    }

    void InterstitialAdClosedEvent()
    {
        Debug.Log("unity-script: I got InterstitialAdClosedEvent");
    }

 

   
    #endregion


    #region Banner
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


    #endregion



    void OnApplicationPause (bool isPaused)
	{
		Debug.Log ("unity-script: OnApplicationPause = " + isPaused);
		IronSource.Agent.onApplicationPause (isPaused);
	}
 
   

}