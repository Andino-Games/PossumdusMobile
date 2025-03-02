using Assets.Scripts.Systems.WalletSystem;
using System;
using UnityEngine;

public class ProductionManager : MonoBehaviour
{
    public static ProductionManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("Production Manager Instance is assigned");
        }
        else Destroy(gameObject);
    }

    public void CollectFibersProduction(int FibersAmount)
    {
        WalletService.Instance.AddFibers(FibersAmount);
    }

    public void CollectGaiaTearsProduction(int tearsAmount)
    {
        WalletService.Instance.AddTears(tearsAmount);
    }

    public void CollectClickerProduction(int clickAmount)
    {
        WalletService.Instance.AddFibers(clickAmount);
    }
}

   
