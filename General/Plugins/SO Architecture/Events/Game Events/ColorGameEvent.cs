using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "IntGameEvent.asset",
        menuName = SOArchitecture_Utility.GAME_EVENT + "Color",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 20)]
    public sealed class ColorGameEvent : GameEventBase<Color>
    {
    } 
}