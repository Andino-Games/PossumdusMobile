using Assets.Scripts.Systems.WalletSystem;
using UnityEngine;

public class TycoonEconomy : MonoBehaviour
{
    public static TycoonEconomy Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static bool CanAfford(float fibersCost, float tearsCost)
    {
        return (fibersCost > 0 && WalletService.Instance.GetFibersAmount() >= fibersCost) || (tearsCost > 0 && WalletService.Instance.GetTearsAmount() >= tearsCost);
    }

    public void PurchaseElement(TycoonMethods methods, bool useFibers)
    {
        if (useFibers && CanAfford(methods.CurrentCostFibers(), 0))
        {
            WalletService.Instance.SpendFibers(Mathf.RoundToInt(methods.CurrentCostFibers()));
            methods.ActivateElement();
        }
        else if (!useFibers && CanAfford(0, methods.CurrentCostTears()))
        {
            WalletService.Instance.SpendTears(Mathf.RoundToInt(methods.CurrentCostTears()));
            methods.ActivateElement();
        }
        else
        {
            Debug.Log("No tienes suficientes Fibras Sintovivas para comprar esta mejora.");
        }
    }
}


