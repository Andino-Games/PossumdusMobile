using System;
using UnityEngine;

public class ProductionManager : MonoBehaviour
{
    public static ProductionManager instance;
    public event Action<int> OnFibersUpdated;
    public event Action<int> OnTearsUpdated;
    private int _fibersAmount;
    public int fibersAmount
    {
        get { return _fibersAmount; }
        set
        {
            _fibersAmount = Mathf.Max(0, value);
            OnFibersUpdated?.Invoke(_fibersAmount);
        }
    }
    private int _gaiaTearsAmount;
    public int gaiaTearsAmount
    {
        get { return _gaiaTearsAmount;}
        set
        {
            _gaiaTearsAmount = Mathf.Max(0, value);
            OnTearsUpdated?.Invoke(_gaiaTearsAmount);
        }
    }
           
    private void Awake()
    {
      if(instance == null)
            instance = this;
      else Destroy(gameObject);
    }

    public void CollectFibersProduction(int FibersAmount)
    {
        fibersAmount += FibersAmount;
        OnFibersUpdated?.Invoke(_fibersAmount);
    }

    public void CollectGaiaTearsProduction(int tearsAmount)
    {
        gaiaTearsAmount += tearsAmount;
        OnTearsUpdated?.Invoke(_gaiaTearsAmount);
    }

    public void CollectClickerProduction(int clickAmount)
    {
        fibersAmount += clickAmount;
        OnFibersUpdated?.Invoke(_fibersAmount);
    }

    public void SpendResources(float fibersCost, float tearsCost)
    {
        fibersAmount -= Mathf.RoundToInt(fibersCost);
        gaiaTearsAmount -= Mathf.RoundToInt(tearsCost);
        OnFibersUpdated?.Invoke(_fibersAmount);
    }
}
