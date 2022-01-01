using GoogleMobileAds.Api;
using UnityEngine;

namespace SemihCelek.Sprinter.GoogleAds
{
    public class GoogleAdMobRequestBannerAd : MonoBehaviour
    {
        private BannerView _bannerView;

        public void Start()
        {
            RequestBanner();
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

            _bannerView?.Destroy();

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