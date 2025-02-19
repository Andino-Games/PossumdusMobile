using System.Collections;
using UnityEngine;

public class ProductionMethods : MonoBehaviour
{
    public int baseProduction = 10;
    public float productionMultiplier = 1f;
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
        int totalProduction = Mathf.RoundToInt(baseProduction * productionMultiplier);
        productionStored += totalProduction;
        Debug.Log($"{name} ha producido {totalProduction}. Acumulado: {productionStored}");

    }
    public void IncreaseProduction(float multiplier)
    {
        productionMultiplier *= multiplier;
    }
}

   