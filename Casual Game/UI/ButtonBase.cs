using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class ButtonBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region Button Base
    [SerializeField] protected float clickScale = 0.95f;
    public bool invokeOnce = false;
    public bool interactable = true;
    public bool muteSoundClick = false;
    public UnityEvent onClick;

    const float ZoomOutTime = 0.1f;
    const float ZoomInTime = 0.1f;
    Vector3 originScale = new Vector3(1.0f, 1.0f, 1.0f);

    bool invoked = false;
    public bool pointerDown = false;
    internal Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    protected void Start()
    {
        originScale = transform.localScale;
    }

    protected void OnEnable()
    {
        ResetInvokeState();
    }

    public void ResetInvokeState()
    {
        invoked = false;
    }

    public virtual void SetState(bool enable)
    {
        interactable = enable;
    }

    public void AddListener(UnityAction action, bool resetAll = false)
    {
        if (!resetAll) onClick.RemoveListener(action);
        else onClick.RemoveAllListeners();
        onClick.AddListener(action);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //if (!EventSystem.current.IsPointerOverGameObject()) return;
        pointerDown = true;
        if (interactable)
        {
            StartCoroutine("StartClick");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!pointerDown) return;

        if (interactable && (!invokeOnce || !invoked))
        {
            invoked = true;
            InvokeOnClick();
        }

        pointerDown = false;
        StopCoroutine("StartClick");
    
        transform.localScale = originScale;
        //		StartCoroutine(StartExit());
    }
    
    protected virtual void InvokeOnClick()
    {

        GameSFXManager.PlaySFXByType(SFXType.btnClick);
        if (onClick != null)
        {
            onClick.Invoke();
        }
    }

    IEnumerator StartClick()
    {
        float tCounter = 0;
     //   AudioManager.instance.Play("ClickBtn");
        while (tCounter < ZoomOutTime)
        {
            tCounter += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originScale, originScale * clickScale, tCounter / ZoomOutTime);
            yield return null;
        }
    }

    IEnumerator StartExit()
    {
        float tCounter = 0;

        while (tCounter < ZoomInTime)
        {
            tCounter += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originScale * clickScale, originScale, tCounter / ZoomInTime);
            yield return null;
        }
    }
    #endregion

    public void SetActive(bool state) 
    {
        //Debug.Log(gameObject.name);
        gameObject.SetActive(state);
    }

    internal void RemoveListener(object onPauseBtn)
    {
        throw new NotImplementedException();
    }
}
