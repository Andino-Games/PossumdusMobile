using System.Collections;
using UnityEngine;

public class ProductionMethods : MonoBehaviour
{
    public int BaseFibersProduction { get; private set; } = 10;
    public int BaseTearsProduction { get; private set; } = 1;
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
        fibersProductionStored += BaseFibersProduction;
        Debug.Log($"{name} ha producido {BaseFibersProduction} fibras. Acumulado: {fibersProductionStored} fibras");

    }

    private void GenerateTears()
    {
        tearsProductionStored += BaseTearsProduction;
        Debug.Log($"{name} ha producido {BaseTearsProduction} lagrimas. Acumulado: {tearsProductionStored} lagrimas");
    }
    public void IncreaseProduction(float fiberMultiplier, float tearsMultiplier)
    {
       BaseFibersProduction = Mathf.RoundToInt(BaseFibersProduction * fiberMultiplier);
       BaseTearsProduction = Mathf.RoundToInt(BaseTearsProduction * tearsMultiplier);
    }
}



