using System.Collections;
using UnityEngine;

public class ProductionMethods : MonoBehaviour
{
    public int baseFibersProduction { get; private set; } = 10;
    public int baseTearsProduction { get; private set; } = 1;
    public float fibersproductionInterval = 3f;
    public float tearsProductionInterval = 5f;
    [SerializeField] private int fibersProductionStored = 0;
    [SerializeField] private int tearsProductionStored = 0;

    private void Start()
    {
        InvokeRepeating(nameof(GenerateFibers), fibersproductionInterval, fibersproductionInterval);
        InvokeRepeating(nameof(GenerateTears), tearsProductionInterval, tearsProductionInterval);
    }
    private void OnMouseDown()
    {
        if (fibersProductionStored > 0)
        {
            ProductionManager.instance.CollectFibersProduction(fibersProductionStored);
            fibersProductionStored = 0;
        }
        if(tearsProductionStored > 0)
        {
            ProductionManager.instance.CollectGaiaTearsProduction(tearsProductionStored);
            tearsProductionStored = 0;
        }
    }
    private void GenerateFibers()
    {
        fibersProductionStored += baseFibersProduction;
        Debug.Log($"{name} ha producido {baseFibersProduction} fibras. Acumulado: {fibersProductionStored} fibras");

    }

    private void GenerateTears()
    {
        tearsProductionStored += baseTearsProduction;
        Debug.Log($"{name} ha producido {baseTearsProduction} lagrimas. Acumulado: {tearsProductionStored} lagrimas");
    }
    public void IncreaseProduction(float fiberMultiplier, float tearsMultiplier)
    {
       baseFibersProduction = Mathf.RoundToInt(baseFibersProduction * fiberMultiplier);
       baseTearsProduction = Mathf.RoundToInt(baseTearsProduction * tearsMultiplier);
    }
}



