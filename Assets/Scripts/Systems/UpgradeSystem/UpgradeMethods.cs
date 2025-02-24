using UnityEngine;

public class UpgradeMethods : MonoBehaviour
{
    [Header("Upgrade Data")]
    public string upgradeName;
    public int level = 0;
    public float baseCostFibers = 100f;
    public float baseCostTears = 10f;
    public float fibersCostMultiplier = 1.2f;
    public float tearsCostMultiplier = 2f;
    public float fibersProductionIncrement = 1.5f;
    public float tearsProductionIncrmeent = 0.5f;
    public ProductionMethods targetProducer;
    public float currentCostFibers => baseCostFibers * Mathf.Pow(fibersCostMultiplier, level);
    public float currentCostTears => baseCostTears * Mathf.Pow(tearsCostMultiplier, level);

    private void Awake()
    {
        targetProducer = GetComponent<ProductionMethods>();
    }
    public void ApplyEffect()
    {
        if(targetProducer != null)
        {
            level++;
            targetProducer.IncreaseProduction(fibersProductionIncrement, tearsProductionIncrmeent);
            Debug.Log($"{upgradeName} mejorado a nivel {level}. Nueva producción: {targetProducer.baseFibersProduction}");
        }
    }

}
