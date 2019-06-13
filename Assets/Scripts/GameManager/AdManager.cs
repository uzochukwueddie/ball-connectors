// using System.Collections;
// using System.Collections.Generic;
// using System;
// using UnityEngine;
// using GoogleMobileAds.Api;

// public class AdManager : MonoBehaviour
// {

//     // private string APP_ID = "ca-app-pub-5016812855157623~9060341143";
//     private string APP_ID = "ca-app-pub-3940256099942544~3347511713";
//     private BannerView bannerAD;
//     private InterstitialAd interstitialAD;
//     private RewardBasedVideoAd rewardAD;

//     // Start is called before the first frame update
//     void Start()
//     {

//         // Initialize the Google Mobile Ads SDK.
//         MobileAds.Initialize(APP_ID);

//         RequestBanner();
//         RequestInterstitial();
//         RequestVideoAD();
        
//     }

//     void RequestBanner()
//     {
//         string BANNER_ID = "ca-app-pub-3940256099942544/6300978111";
//         bannerAD = new BannerView(BANNER_ID, AdSize.SmartBanner, AdPosition.Bottom);

//         AdRequest request = new AdRequest.Builder()
//                                 .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

//         bannerAD.LoadAd(request);
//     }
//     void RequestInterstitial()
//     {
//         string INTERSTITIAL_ID = "ca-app-pub-3940256099942544/1033173712";
//         interstitialAD = new InterstitialAd(INTERSTITIAL_ID);

//         AdRequest request = new AdRequest.Builder()
//                                 .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

//         interstitialAD.LoadAd(request);
//     }

//     void RequestVideoAD()
//     {
//         string REWARD_ID = "ca-app-pub-3940256099942544/5224354917";
//         rewardAD = RewardBasedVideoAd.Instance;

//         AdRequest request = new AdRequest.Builder()
//                                 .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

//         rewardAD.LoadAd(request, REWARD_ID);
//     }

//     public void DIsplayBanner() {
//         bannerAD.Show();
//     }

//     public void DIsplayInterstitial() {
//         if (interstitialAD.IsLoaded()) {
//             interstitialAD.Show();
//         }
//     }

//     public void DIsplayVideoAD() {
//         if (rewardAD.IsLoaded()) {
//             rewardAD.Show();
//         }
//     }

//     // HANDLE EVENTS
//     public void HandleOnAdLoaded(object sender, EventArgs args)
//     {
//         // ad is loaded
//         // display it
//         DIsplayBanner();
//     }

//     public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//     {
//         // ad fails to load
//         // request it again
//         RequestBanner();
//     }

//     public void HandleOnAdOpened(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleAdOpened event received");
//     }

//     public void HandleOnAdClosed(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleAdClosed event received");
//     }

//     public void HandleOnAdLeavingApplication(object sender, EventArgs args)
//     {
//         MonoBehaviour.print("HandleAdLeavingApplication event received");
//     }

//     void HandleBannerAdEvents (bool subscribe) {
//         if (subscribe) {
//             // Called when an ad request has successfully loaded.
//             bannerAD.OnAdLoaded += HandleOnAdLoaded;
//             // Called when an ad request failed to load.
//             bannerAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
//             // Called when an ad is clicked.
//             bannerAD.OnAdOpening += HandleOnAdOpened;
//             // Called when the user returned from the app after an ad click.
//             bannerAD.OnAdClosed += HandleOnAdClosed;
//             // Called when the ad click caused the user to leave the application.
//             bannerAD.OnAdLeavingApplication += HandleOnAdLeavingApplication;
//         } else {
//             // unsubscribe from events
//             bannerAD.OnAdLoaded -= HandleOnAdLoaded;
//             bannerAD.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
//             bannerAD.OnAdOpening -= HandleOnAdOpened;
//             bannerAD.OnAdClosed -= HandleOnAdClosed;
//             bannerAD.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
//         }
//     }
//     void OnEnable()
//     {
//         HandleBannerAdEvents(true);
//     }

//     void OnDisable() {
//         HandleBannerAdEvents(false);
//     }
// }
