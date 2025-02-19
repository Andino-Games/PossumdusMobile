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

    public void SpendFibers(float amount)
    {
        if(canAfford(amount))
        {
            ProductionManager.instance.fibersAmount -= Mathf.RoundToInt(amount);
        }else
        {
            Debug.Log("No tienes suficientes Fibras Sintovivas");
        }
    }


}
