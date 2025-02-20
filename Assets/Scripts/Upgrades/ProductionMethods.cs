using System.Collections;
using UnityEngine;

public class ProductionMethods : MonoBehaviour
{
    public int baseProduction { get; private set; } = 10;
    public float productionInterval = 3f;
    [SerializeField] private int productionStored = 0;

    private void Start()
    {
        InvokeRepeating(nameof(GenerateResources), productionInterval, productionInterval);
    }
    private void OnMouseDown()
    {
        if (productionStored > 0)
        {
            ProductionManager.instance.CollectFibersProduction(productionStored);
            productionStored = 0;
        }
    }
    private void GenerateResources()
    {
        productionStored += baseProduction;
        Debug.Log($"{name} ha producido {baseProduction}. Acumulado: {productionStored}");

    }
    public void IncreaseProduction(float multiplier)
    {
       baseProduction = Mathf.RoundToInt(baseProduction * multiplier);
    }
}



