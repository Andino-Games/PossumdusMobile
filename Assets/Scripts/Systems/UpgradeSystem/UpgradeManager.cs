using Assets.Scripts.Systems.WalletSystem;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    public bool CanAfford(float fibersCost, float tearsCost)
    {
        return (fibersCost > 0 && WalletService.Instance.GetFibersAmount() >= fibersCost) || (tearsCost > 0 && WalletService.Instance.GetTearsAmount() >= tearsCost);
    }

    public void PurchaseUpgrade(UpgradeMethods upgrade, bool useFibers)
    {
        if (useFibers && CanAfford(upgrade.CurrentCostFibers(), 0))
        {
            WalletService.Instance.SpendFibers(Mathf.RoundToInt(upgrade.CurrentCostFibers()));
            upgrade.level++;
            upgrade.ApplyEffect();
        }
        else if (!useFibers && CanAfford(0, upgrade.CurrentCostTears()))
        {
            WalletService.Instance.SpendTears(Mathf.RoundToInt(upgrade.CurrentCostTears()));
            upgrade.level++;
            upgrade.ApplyEffect();
        }
        else
        {
            Debug.Log("No tienes suficientes Fibras Sintovivas para comprar esta mejora.");
        }
    }
}

       

   
    