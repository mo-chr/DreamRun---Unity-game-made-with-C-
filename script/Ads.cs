using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour
{
    public static Ads instance;
    private String bannerID = "ca-app-pub-3940256099942544/6300978111";
    private String appID = "ca-app-pub-2977242973490744~4671119083";
    public BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardAd;
    private infiniteRunner player;
    public RewardBasedVideoAd rewardedAd;
    private string rewardedAdId = "ca-app-pub-3940256099942544/5224354917";
    public static readonly Ads Instance = new Ads();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            RequestBanner();

        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            hideBanner();

        }

        

        RequestRewardAd();

    }
  
    public void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.TopRight);
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        //AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(adRequest);
    }
    public void RequestRewardAd()
    {
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adRequest, rewardedAdId);
    }
    public void showRewardAd() 
    {
        if(rewardedAd.IsLoaded())
         {

            rewardAd.Show();
        }
        
    
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        RequestRewardAd();
    }
    public void hideBanner()
    {
        bannerView.Hide();

    }


    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
             "HandleRewardedAdRewarded event received for "
                 + amount.ToString() + " " + type);
        player.RewardCoins();
    }
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
 
        RequestRewardAd();
    }





    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
    }
    public void RequestRewardBasedVideo()
    {
#if UNITY_EDITOR
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_ANDROID
        string adUnitId = "INSERT_AD_UNIT_HERE";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_AD_UNIT_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

        RewardBasedVideoAd rewardBasedVideo = RewardBasedVideoAd.Instance;

        AdRequest request = new AdRequest.Builder().Build();
        rewardBasedVideo.LoadAd(request, adUnitId);

        //Show Ad
        ShowAdd(rewardBasedVideo);

        if (rewardBasedVideo.IsLoaded())
        {
            //Subscribe to Ad event
            rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
            rewardBasedVideo.Show();
        }
    }

    public void ShowAdd(RewardBasedVideoAd rewardBasedVideo)
    {
    }
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        //Reawrd User here
        player.RewardCoins();
        print("User rewarded with: " + amount.ToString() + " " + type);
    }
}

