using GoogleMobileAds.Api;
using UnityEngine;

namespace DefaultNamespace
{
    public class GoogleAdMobRequestBannerAd : MonoBehaviour
    {
        private BannerView bannerView;
            
        public void Start()
        {
            // Initialize the Google Mobile Ads SDK.
            // MobileAds.Initialize(initStatus => { });

            this.RequestBanner();
        }

        private void RequestBanner()
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

            if (bannerView != null)
            {
                bannerView.Destroy();
            }
            
            // Create a 320x50 banner at the top of the screen.
            this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
            
            
            bannerView.LoadAd(CreateAdRequest());
        }
        private AdRequest CreateAdRequest()
        {
            return new AdRequest.Builder()
                // .AddKeyword()
                .Build();
        }
    }
}
