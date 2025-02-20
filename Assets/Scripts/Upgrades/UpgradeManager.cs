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

    public bool canAfford(float fibersCost, float tearsCost)
    {
        return (fibersCost > 0 && ProductionManager.instance.fibersAmount >= fibersCost) || (tearsCost > 0 && ProductionManager.instance.gaiaTearsAmount >= tearsCost);
    }

    public void PurchaseUpgrade(UpgradeMethods upgrade, bool useFibers)
    {
        if (useFibers && canAfford(upgrade.currentCostFibers, 0))
        {
            ProductionManager.instance.SpendResources(upgrade.currentCostFibers, 0);
            upgrade.level++;
            upgrade.ApplyEffect();
        }
        else if (!useFibers && canAfford(0, upgrade.currentCostTears))
        {
            ProductionManager.instance.SpendResources(0, upgrade.currentCostTears);
            upgrade.level++;
            upgrade.ApplyEffect();
        }
        else
        {
            Debug.Log("No tienes suficientes Fibras Sintovivas para comprar esta mejora.");
        }
        /*if  (UpgradeManager.Instance.canAfford(upgrade.currentCostFibers, 0))
        {
           ProductionManager.instance.SpendFibers(upgrade.currentCostFibers);
            upgrade.ApplyEffect();
        }*/
    }
}

   
    