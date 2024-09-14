using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class IngameEvent : MonoBehaviour
{
   public UnityEvent m_MyEvent;
    void Awake()
    {
        if (m_MyEvent == null)
            m_MyEvent = new UnityEvent();

        
    }
    public void AddListener(UnityAction action)
    {
        m_MyEvent.AddListener(action);
    }
    public void RemoveListener(UnityAction action)
    {
        m_MyEvent.RemoveListener(action);
    }
    public void Raise()
    {
        if ( m_MyEvent != null)
        {
            m_MyEvent.Invoke();
        }
    }
}
