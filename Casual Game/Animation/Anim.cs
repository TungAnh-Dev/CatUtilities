

using JetBrains.Annotations;
using ScriptableObjectArchitecture;
using UnityEngine;

public class Anim : MonoBehaviour
{
    // private const string OnEndAtkConst = "OnEndAtk";
    // private const string OnAtkConst = "OnAtk";
    // private const string OnKickConst = "Kick";
    // private const string OnEndKickConst = "EndKick";
    public Animator anim;
    protected string currentAnim;

    // [SerializeField] protected EventHandle Handler;
    // public GameEvent OnEndAttack;
    // public GameEvent OnAttack;
    // public GameEvent OnKick;
    // public GameEvent EndKick;


    // void Start()
    // {
    //     if(Handler == null) return;
    //     anim.SetBool("isWalking", false);
    //     Handler.Callback += OnEventHandler;
    // }

    // void OnDestroy()
    // {
    //     if(Handler == null) return;

    //     Handler.Callback -= OnEventHandler;
    // }


    // protected void OnEventHandler(string name)
    // {
    //     switch (name)
    //     {
    //         case OnEndAtkConst:
    //             OnEndAttack?.Raise();
    //             break;
    //         case OnAtkConst:
    //             OnAttack?.Raise();
    //             break;
    //         case OnKickConst:
    //             OnKick?.Raise();
    //             break;
    //         case OnEndKickConst:
    //             EndKick?.Raise();
    //         break;
    //     }
        
        
    // }


    
    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }

    public void ResetAnimAfterSecond(float second)
    {
        Invoke(nameof(ResetAnim), second);
    }

    public void ResetAnim()
    {
        //Debug.Log($"Reset Anim");
        currentAnim = "";
    }

}
