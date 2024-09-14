using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

[Serializable]
public class DailyRewardData
{
    public string day;
    public Sprite icon;
    public int amount;
}

public class DailyRewardUI : UICanvas
{
    [SerializeField] ButtonBase claimBtn;
    [SerializeField] ButtonBase exitBtn;
    [SerializeField] Sprite claimedSprite;
    [SerializeField] Sprite claimedSpriteday7;
    [SerializeField] Sprite todaySprite;
    [SerializeField] Sprite tomorrowSprite;
    [SerializeField] Sprite claimBtnSprite;
    [SerializeField] Sprite claimedBtnSprite;
    [SerializeField] List<DailyRewardData> dailyRewardDatas;
    [SerializeField] List<E_Rewards> days;
    

    private int currentDay;
    private const int totalDays = 7;

    void OnEnable()
    {
        claimBtn.onClick.AddListener(OnClaimBtn);
        //exitBtn.onClick.AddListener(OnExitBtn);
        StartCoroutine(CheckForNewDay());
    }

    void OnDisable()
    {
        claimBtn.onClick.RemoveListener(OnClaimBtn);
        //exitBtn.onClick.RemoveListener(OnExitBtn);
        StopCoroutine(CheckForNewDay());
    }

    public override void Open()
    {
        base.Open();



        
        
    }

    // private void OnExitBtn()
    // {
    //     Close(0.3f);
    // }

    private void OnClaimBtn()
    {
        // Check if a day has passed since the last claim
        string lastClaimDateStr = PlayerPrefs.GetString("LastClaimDate", DateTime.MinValue.ToString("yyyy-MM-dd"));
        DateTime lastClaimDate = DateTime.ParseExact(lastClaimDateStr, "yyyy-MM-dd", null);
        DateTime currentDate = DateTime.Now.Date;

        if (currentDate > lastClaimDate)
        {
            Debug.Log(dailyRewardDatas[currentDay].amount);
            MoneySystem.Instant.AddMoney(dailyRewardDatas[currentDay].amount);
            // Handle claiming the reward
            PlayerPrefs.SetInt("LastClaimedDay", currentDay);
            currentDay = (currentDay + 1) % totalDays;
            PlayerPrefs.SetInt("CurrentDay", currentDay);

            // Update the last claim date
            PlayerPrefs.SetString("LastClaimDate", currentDate.ToString("yyyy-MM-dd"));

            UpdateDayUI();

            claimBtn.image.sprite = claimedBtnSprite;
            claimBtn.interactable = false;

            Close(0.5f);
        }
        else
        {
            Debug.Log("You can only claim once per day.");
        }
    }

    private void UpdateDayUI()
    {
        currentDay = PlayerPrefs.GetInt("CurrentDay", 0);

        for (int i = 0; i < days.Count; i++)
        {
            days[i].UpdateRewards(dailyRewardDatas[i]);

            if (i < currentDay)
            {
                if(i == 6)
                {
                    days[i].SetStateClaimed(claimedSpriteday7, dailyRewardDatas[i].day);
                }
                else
                {
                    days[i].SetStateClaimed(claimedSprite, dailyRewardDatas[i].day);
                }
                
            }
            else if (i == currentDay)
            {
                if(i != 6)
                {
                    days[i].SetState(tomorrowSprite, "Tomorrow");
                }
                
            }
        }
    }


    private void UpdateUI()
    {
        currentDay = PlayerPrefs.GetInt("CurrentDay", 0);

        for (int i = 0; i < days.Count; i++)
        {
            days[i].UpdateRewards(dailyRewardDatas[i]);

            if (i < currentDay)
            {
                days[i].SetStateClaimed(claimedSprite, dailyRewardDatas[i].day);
            }
            else if (i == currentDay)
            {
                if(i != 6)
                {
                    days[i].SetState(todaySprite, "Today");
                }
                else if(i == 6)
                {
                    days[i].SetText("Today");
                }
                
            }
            else if (i == (currentDay + 1))
            {
                if(i != 6)
                {
                    days[i].SetState(tomorrowSprite, "Tomorrow");
                }
                
            }
            else
            {
                days[i].ResetSprite();
            }
        }
    }

    // void Start()
    // {
    //     UpdateUI();
    // }


    private IEnumerator CheckForNewDay()
    {
        while (true)
        {
            string lastCheckedDateStr = PlayerPrefs.GetString("LastCheckedDate", DateTime.MinValue.ToString("yyyy-MM-dd"));
            DateTime lastCheckedDate = DateTime.ParseExact(lastCheckedDateStr, "yyyy-MM-dd", null);
            DateTime currentDate = DateTime.Now.Date;

            Debug.Log(currentDate + "   dayly");
            Debug.Log(lastCheckedDate + "   dayly");


            if (currentDate > lastCheckedDate)
            {
                PlayerPrefs.SetString("LastCheckedDate", currentDate.ToString("yyyy-MM-dd"));
                UpdateUI();

                Debug.Log($"lololo");
            }
            else
            {
                TodayUI();
                Debug.Log($"lololo2");
            }

            yield return new WaitForSeconds(1); // Check every 60 seconds
        }
    }

    private void TodayUI()
    {
        currentDay = PlayerPrefs.GetInt("CurrentDay", 0);

        for (int i = 0; i < days.Count; i++)
        {
            days[i].UpdateRewards(dailyRewardDatas[i]);

            if (i == currentDay)
            {
                if(i != 6)
                {
                    days[i].SetState(todaySprite, "Today");
                }
                
            }
            else if(i == (currentDay + 1))
            {
                if(i != 6)
                {
                    days[i].SetState(tomorrowSprite, "Tomorrow");
                }
            }
            else if (i < currentDay)
            {
                if(i == 6)
                {
                    days[i].SetStateClaimed(claimedSpriteday7, dailyRewardDatas[i].day);
                }
                else
                {
                    days[i].SetStateClaimed(claimedSprite, dailyRewardDatas[i].day);
                }
                
            }
             

        }
    }
}
