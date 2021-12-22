using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoogleAdMobController : MonoBehaviour
{
    private BannerView bannerView;
    // public Text statusText;

    public UnityEvent OnAdLoadedEvent;
    public UnityEvent OnAdFailedToLoadEvent;
    public UnityEvent OnAdOpeningEvent;
    public UnityEvent OnAdFailedToShowEvent;
    public UnityEvent OnUserEarnedRewardEvent;
    public UnityEvent OnAdClosedEvent;
   
    private static bool created = false;

    // private void Awake()
    // {
    //
    //     // Ensure the script is not deleted while loading.
    //     if (!created)
    //     {
    //         DontDestroyOnLoad(this.gameObject);
    //         created = true;
    //     }
    //     else
    //     {
    //         Destroy(this.gameObject);
    //     }
    // }

    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
        // Callbacks from GoogleMobileAds are not guaranteed to be called on
        // main thread.
        // In this example we use MobileAdsEventExecutor to schedule these calls on
        // the next Update() loop.
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            // statusText.text = "Initialization complete";
            RequestBannerAd();
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(HandleInitCompleteAction);

    }
    public void RequestBannerAd()
    {
        // statusText.text = "Requesting Banner Ad.";

        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up banner before reusing
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Add Event Handlers
        bannerView.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        bannerView.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        bannerView.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        bannerView.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();

        // Load a banner ad
        bannerView.LoadAd(CreateAdRequest());
    }
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            // .AddKeyword()
            .Build();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
