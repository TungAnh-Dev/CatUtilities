
using CatUtilities;
using ScriptableObjectArchitecture;
using UnityEngine;
 
public class MoneySystem : Singleton<MoneySystem>
{
    //public int moneyEatenOnCurrentLevel;
  
    public bool isHackUnlimited = false;
    public GameEvent OnMoneyChange;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (isHackUnlimited)
        {
            if (UserData.Ins.money < 99999)
            {
                UserData.Ins.money = 99999;
            }
            
        }
    }

    // public static void EatMoneyGameplay(int amount)
    // {
    //     moneyEatenOnCurrentLevel += amount;
    //     UserData.Ins.money += amount;
        
    // }
    // public void AbortMoneyCollectedCurrentLevel()
    // {
    //     GlobalReference.gameData.money -= instance.moneyEatenOnCurrentLevel;
    // }
    // public void NewLevel()
    // {
    //     instance.moneyEatenOnCurrentLevel = 0;
    // }
    // public void ReduceMoney(int amount, MoneySpendType type, bool forceSaveInstantly = false)
    // {
    //     GlobalReference.gameData.money = GlobalReference.gameData.money - amount;
    //     EventManager.Raise(Events.MoneyChangeEvent);
    // }
    public void AddMoney(int amount, bool forceSaveInstantly = false)
    {
        int money = UserData.Ins.money;
        UserData.Ins.SetIntData(UserData.Key_Money, ref UserData.Ins.money, money + amount);
        OnMoneyChange.Raise();
    }
    
    public int GetCurrentMoneyAmount()
    {
        return UserData.Ins.money;
        //return GlobalReference.gameData.money;
    }
    
}
// public enum MoneySpendType
// {
//     None,
//     BuyWeapon
// }
 