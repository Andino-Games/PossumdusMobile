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

    private void Awake()
    {
        targetProducer = GetComponent<ProductionMethods>();
    }
    public void ApplyEffect()
    {
        if(targetProducer != null)
        {
            level++;
            targetProducer.IncreaseProduction(productionIncrement);
            Debug.Log($"{upgradeName} mejorado a nivel {level}. Nueva producción: {targetProducer.baseProduction}");
        }
    }

}
