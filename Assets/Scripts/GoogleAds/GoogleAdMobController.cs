using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;
using UnityEngine.Events;

namespace SemihCelek.Sprinter.GoogleAds
{
    public class GoogleAdMobController : MonoBehaviour
    {
        private BannerView bannerView;

        private void HandleInitCompleteAction(InitializationStatus initstatus)
        {
            MobileAdsEventExecutor.ExecuteInUpdate(() => { RequestBannerAd(); });
        }

        void Start()
        {
            MobileAds.Initialize(HandleInitCompleteAction);
        }

        public void RequestBannerAd()
        {
#if UNITY_EDITOR
            string adUnitId = "unused";
#elif UNITY_ANDROID
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

            bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

            bannerView.LoadAd(CreateAdRequest());
        }

        private AdRequest CreateAdRequest()
        {
            return new AdRequest.Builder()
                .Build();
        }
    }
}