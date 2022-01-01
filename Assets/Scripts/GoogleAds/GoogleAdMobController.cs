using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;
using UnityEngine.Events;

namespace SemihCelek.Sprinter.GoogleAds
{
    public class GoogleAdMobController : MonoBehaviour
    {
        private BannerView _bannerView;

        private void HandleInitCompleteAction(InitializationStatus initStatus)
        {
            MobileAdsEventExecutor.ExecuteInUpdate(() => { RequestBannerAd(); });
        }

        void Start()
        {
            MobileAds.Initialize(HandleInitCompleteAction);
        }

        private void RequestBannerAd()
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

            if (_bannerView != null)
            {
                _bannerView.Destroy();
            }

            _bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

            _bannerView.LoadAd(CreateAdRequest());
        }

        private AdRequest CreateAdRequest()
        {
            return new AdRequest.Builder()
                .Build();
        }
    }
}