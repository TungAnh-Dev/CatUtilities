using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class IngameEventListener : MonoBehaviour
{
   public IngameEvent eventToListen;
    public UnityEvent m_event;
    private void OnEnable()
    {
       
            eventToListen.AddListener(TriggerEvent);
        
        
    }
    private void OnDisable()
    {
        
            eventToListen.RemoveListener(TriggerEvent);
        
    }
    private void TriggerEvent()
    {
        if (m_event!=null) m_event.Invoke();   
    }
}
