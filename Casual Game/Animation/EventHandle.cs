using System;

using UnityEngine;

public class EventHandle : MonoBehaviour
{
    public Action<string> Callback;
    public void OnEventCustom(string name){
        Callback?.Invoke(name);
    }
}
