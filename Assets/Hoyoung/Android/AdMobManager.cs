using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdMobManager : MonoBehaviour
{
    public bool isTestMode;
    //public Text LogText;
    //public Button FrontAdsBtn, RewardAdsBtn;

    bool isPlayedforB = false;
    bool isPlayedforI = false;

    void Start()
    {
        DontDestroyOnLoad(this);
        LoadBannerAd();
        LoadFrontAd();
        //LoadRewardAd();
    }

    void Update()
    {
        //FrontAdsBtn.interactable = frontAd.IsLoaded();
        //RewardAdsBtn.interactable = rewardAd.IsLoaded();


        // 크레딧 씬에서 배너광고
        if (SceneManager.GetActiveScene().name == "Credit")
        {
            if (isPlayedforB == false)
            {
                ToggleBannerAd(true);
                isPlayedforB = true;
            }
        }
        else
        {
            ToggleBannerAd(false);
            isPlayedforB = false;
        }

        // 겜오버씬에서 전면광고
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (isPlayedforI == false)
            {
                ShowFrontAd();
                isPlayedforI = true;
            }
        }
        else
            isPlayedforI = false;
    }

    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().AddTestDevice("22E52B418E54011F").Build();
    }



    #region 배너 광고
    const string bannerTestID = "ca-app-pub-3940256099942544/6300978111";
    const string bannerID = "ca-app-pub-4769546235671440/9351981882";
    BannerView bannerAd;


    void LoadBannerAd()
    {
        bannerAd = new BannerView(isTestMode ? bannerTestID : bannerID,
            AdSize.SmartBanner, AdPosition.Top);
        bannerAd.LoadAd(GetAdRequest());
        ToggleBannerAd(false);
    }

    public void ToggleBannerAd(bool b)
    {
        if (b) bannerAd.Show();
        else bannerAd.Hide();
    }
    #endregion



    #region 전면 광고
    const string frontTestID = "ca-app-pub-3940256099942544/1033173712";
    const string frontID = "ca-app-pub-4769546235671440/9160410198";
    InterstitialAd frontAd;


    void LoadFrontAd()
    {
        frontAd = new InterstitialAd(isTestMode ? frontTestID : frontID);
        frontAd.LoadAd(GetAdRequest());
        frontAd.OnAdClosed += (sender, e) =>
        {
            //LogText.text = "전면광고 성공";
        };
    }

    public void ShowFrontAd()
    {
        frontAd.Show();
        LoadFrontAd();
    }
    #endregion
}



//    #region 리워드 광고
//    const string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
//    const string rewardID = "";
//    RewardedAd rewardAd;


//    void LoadRewardAd()
//    {
//        rewardAd = new RewardedAd(isTestMode ? rewardTestID : rewardID);
//        rewardAd.LoadAd(GetAdRequest());
//        rewardAd.OnUserEarnedReward += (sender, e) =>
//        {
//            //LogText.text = "리워드 광고 성공";
//        };
//    }

//    public void ShowRewardAd()
//    {
//        rewardAd.Show();
//        LoadRewardAd();
//    }
//    #endregion
//}