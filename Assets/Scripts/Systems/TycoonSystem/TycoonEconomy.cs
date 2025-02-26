using Assets.Scripts.Systems.WalletSystem;
using UnityEngine;

public class TycoonEconomy : MonoBehaviour
{
    public static bool CanAfford(int cost, WalletService service)
    {
        return service.GetFibersAmount() >= cost;
    }

    public static bool TryPurchase(int cost, WalletService service)
    {
        if(CanAfford(cost, service))
        {
            service.SpendFibers(cost);
            return true;
        }
        return false;
    }
}


