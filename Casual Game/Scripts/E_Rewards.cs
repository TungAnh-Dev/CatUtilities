using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class E_Rewards : MonoBehaviour
{
    [SerializeField] Image bg;
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI day;
    [SerializeField] Sprite bgSprite;
    [SerializeField] GameObject tickObject;

    public void UpdateRewards(DailyRewardData rewardData)
    {
        // Update icon
        icon.sprite = rewardData.icon;
        day.SetText(rewardData.day);

        // Update text
        text.SetText(rewardData.amount.ToString());
    }

    public void SetState(Sprite sprite, string day)
    {
        bg.sprite = sprite;
        this.day.SetText(day);
        tickObject.gameObject.SetActive(false);
    }

    public void ResetSprite()
    {
        bg.sprite = bgSprite;
        bg.color = Color.white;
    }

    public void SetStateClaimed(Sprite sprite, string day)
    {
        bg.sprite = sprite;
        this.day.SetText(day);
        tickObject.gameObject.SetActive(true);
    }

    public void SetText(string day)
    {
        this.day.SetText(day);
    }


}
