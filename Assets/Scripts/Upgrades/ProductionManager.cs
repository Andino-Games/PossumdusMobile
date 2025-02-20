using System;
using UnityEngine;

public class ProductionManager : MonoBehaviour
{
   public static ProductionManager instance;
    public event Action<int> OnResourceUpdated;
    private int _fibersAmount;
    public int fibersAmount
    {
        get { return _fibersAmount; }
        set
        {
            _fibersAmount = Mathf.Max(0, value);
            OnResourceUpdated?.Invoke(_fibersAmount);
        }
    }
    private int _gaiaTearsAmount;
    public int gaiaTearsAmount
    {
        get { return _gaiaTearsAmount;}
        set
        {
            _gaiaTearsAmount = Mathf.Max(0, value);
            OnResourceUpdated?.Invoke(_gaiaTearsAmount);
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
        OnResourceUpdated?.Invoke(_fibersAmount);
    }

    public void CollectGaiaTearsProduction(int tearsAmount)
    {
        gaiaTearsAmount += tearsAmount;
        OnResourceUpdated?.Invoke(_gaiaTearsAmount);
    }

    public void CollectClickerProduction(int clickAmount)
    {
        fibersAmount += clickAmount;
        OnResourceUpdated?.Invoke(_fibersAmount);
    }

    public void SpendFibers(float cost)
    {
        fibersAmount -= Mathf.RoundToInt(cost);
        OnResourceUpdated?.Invoke(_fibersAmount);
    }
}
