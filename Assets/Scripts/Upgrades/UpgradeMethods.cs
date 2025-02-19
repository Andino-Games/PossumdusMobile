using UnityEngine;

public class UpgradeMethods : MonoBehaviour
{
    [Header("Upgrade Data")]
    public string upgradeName;
    public int level = 0;
    public float baseCost = 100f;
    public float costMultiplier = 1.2f;
    public float productionIncrement = 1.5f;
    public ProductionMethods targetProducer;
    public float currentCost => baseCost * Mathf.Pow(costMultiplier, level);
    public void PurchaseUpgrade()
    {
        if (UpgradeManager.Instance.canAfford(currentCost))
        {
            UpgradeManager.Instance.SpendFibers(currentCost);
            level++;
            ApplyEffect();
            Debug.Log($"{upgradeName} mejorado a nivel {level}");
        }else
        {
            Debug.Log("No tienes suficientes Fibras Sintovivas para comprar esta mejora.");
        }
    }
    private void ApplyEffect()
    {
        if(targetProducer != null)
        {
            targetProducer.IncreaseProduction(productionIncrement);
        }
    }

}
