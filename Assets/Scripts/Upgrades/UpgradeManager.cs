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

    public bool canAfford(float amount)
    {
        return ProductionManager.instance.fibersAmount >= amount;
    }

    public void PurchaseUpgrade(UpgradeMethods upgrade)
    {
        if (UpgradeManager.Instance.canAfford(upgrade.currentCost))
        {
           ProductionManager.instance.SpendFibers(upgrade.currentCost);
            upgrade.ApplyEffect();
        }
        else
        {
            Debug.Log("No tienes suficientes Fibras Sintovivas para comprar esta mejora.");
        }
    }
}

   
    