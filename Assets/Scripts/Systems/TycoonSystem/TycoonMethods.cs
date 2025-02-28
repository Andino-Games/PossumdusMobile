using UnityEngine;

public class TycoonMethods : MonoBehaviour
{
    [Header("Purchase Data")]
    public GameObject tycoonElement;
    public float baseCostFibers = 100f;
    public float baseCostTears = 10f;
    public float fibersCostMultiplier = 1.2f;
    public float tearsCostMultiplier = 2f;
    [SerializeField] private bool isActive;
    public float CurrentCostFibers()
    {
        return baseCostFibers * Mathf.Pow(fibersCostMultiplier, TycoonManager.instance.GameProgress);
    }
    public float CurrentCostTears()
    {
        return baseCostTears * Mathf.Pow(tearsCostMultiplier, TycoonManager.instance.GameProgress);
    }
    
    private void Start()
    {
           TycoonManager.instance.RegisterTycoonElement(this);
        if(isActive )
        {
            ActivateElement();
        }
    }

    public void ActivateElement() 
    {
        if(!isActive)
        {
            isActive = true;
            tycoonElement.SetActive(true);
            TycoonManager.instance.ActivateTycoonElement(this);
        }
    }
}
