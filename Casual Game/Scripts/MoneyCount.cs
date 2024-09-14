using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
public class MoneyCount : MonoBehaviour
{
    public TMP_Text moneyText;
 
    HorizontalLayoutGroup layoutGroup;
    private float m_lastTimeMoneyTextChange;
    public float animScaleThreshold = 0.1f;
    bool isMaxSpace = false;
    public GameEvent OnMoneyChange;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        OnMoneyChange.AddListener(UpdateTextMoneyEffect);
        //EventManager.AddListener<PlayMoneyChangedEffect>(OnEatMoneyEffectPlay);

        UpdateTextMoney();

        
    }
    private void OnDisable()
    {
        OnMoneyChange.RemoveListener(UpdateTextMoneyEffect);
        //EventManager.RemoveListener<PlayMoneyChangedEffect>(OnEatMoneyEffectPlay);

    }

    private void UpdateTextMoneyEffect()
    {
        UpdateTextMoney();
        PlayEatMoneyEffect(1);
    }

    private void Start()
    {
        layoutGroup = GetComponent<HorizontalLayoutGroup>();
        UpdateTextMoney();
    }


    void UpdateTextMoney()
    {
        if (m_IsEatMoneyEffectPlaying == false)
            m_lastTimeMoneyTextChange = Time.time;

        moneyText.text = MoneySystem.Instant.GetCurrentMoneyAmount().ToString();
        //PlayEatMoneyEffect(1);

        StartCoroutine(UpdateLayoutGroup());
    }
    IEnumerator UpdateLayoutGroup()
    {
        if (layoutGroup == null) yield break;
        layoutGroup.spacing += 0.1f;
        yield return new WaitForEndOfFrame();
        layoutGroup.spacing -= 0.1f;
    }

    private bool m_IsEatMoneyEffectPlaying = false;

    public async void PlayEatMoneyEffect(float duration)
    {
        m_IsEatMoneyEffectPlaying = true;
        int currentMoney = MoneySystem.Instant.GetCurrentMoneyAmount();
        int currentMoneyFake = currentMoney - 400;
        moneyText.text = currentMoneyFake.ToString();
        float valFloat = currentMoneyFake;
        Tween t = DOTween.To(() => valFloat, x => valFloat = x, currentMoney, duration);

        while (true)
        {
            if (valFloat < 0) valFloat = -valFloat;
            moneyText.text = (Mathf.RoundToInt(valFloat)).ToString();
            await UniTask.WaitForEndOfFrame();
            m_lastTimeMoneyTextChange = Time.time;
            if (Mathf.Approximately(valFloat, currentMoney))
            {
                m_IsEatMoneyEffectPlaying = false;
                return;
            }
        }

    }


    private void Update()
    {
        if(MoneySystem.Instant.GetCurrentMoneyAmount() >= 100)
        {
            if(!isMaxSpace)
            {
                layoutGroup.spacing = -27.62f;
                isMaxSpace = true;
            }
        }
        else
        {
            layoutGroup.spacing = 0;
        }

        if (Time.time - m_lastTimeMoneyTextChange < animScaleThreshold)
        {
            moneyText.transform.localScale = Vector3.MoveTowards(moneyText.transform.localScale, Vector3.one * 1.2f, 5 * Time.deltaTime);
        }
        else
        {
            if (moneyText.transform.localScale != Vector3.one)
            {
                moneyText.transform.localScale = Vector3.MoveTowards(moneyText.transform.localScale, Vector3.one, 2 * Time.deltaTime);
            }

        }
    }
}
