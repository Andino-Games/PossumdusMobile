using System.Collections;
using UnityEngine;

public class ProductionMethods : MonoBehaviour
{
    [Header("Production Data")]
    public int BaseFibersProduction { get; private set; } = 10;
    public int BaseTearsProduction { get; private set; } = 1;
    public int fibersProductionLimit;
    public int tearsProductionLimit;
    public float fibersProductionInterval = 3f;
    public float tearsProductionInterval = 5f;
    public float shutdownTime = 60;
    [SerializeField] private int fibersProductionStored = 0;
    [SerializeField] private int tearsProductionStored = 0;
    [SerializeField] private bool isProducing = true;
    private Coroutine shutdownCoroutine;

    private void Start()
    {
        InvokeRepeating(nameof(GenerateFibers), fibersProductionInterval, fibersProductionInterval);
        InvokeRepeating(nameof(GenerateTears), tearsProductionInterval, tearsProductionInterval);
    }
    private void OnMouseDown()
    {
        bool isCollected = false;
        if (fibersProductionStored > 0)
        {
            ProductionManager.instance.CollectFibersProduction(fibersProductionStored);
            fibersProductionStored = 0;
            isCollected = true;
        }
        if (tearsProductionStored > 0)
        {
            ProductionManager.instance.CollectGaiaTearsProduction(tearsProductionStored);
            tearsProductionStored = 0;
            isCollected = true;
        }

        if (isCollected)
        {
            Debug.Log($"{name} ha vaciado su produccion. Reactivando produccion...");
            RestartProduction();
        }
    }
    private void GenerateFibers()
    {
        if (fibersProductionStored < fibersProductionLimit)
        {
            fibersProductionStored += BaseFibersProduction;
            Debug.Log($"{name} ha producido {BaseFibersProduction} fibras. Acumulado: {fibersProductionStored} fibras");
        }else
        {
            Debug.Log($"{name} ha alcanzado su limite de produccion de fibras");
            StopProduction();
        }
    }
    private void GenerateTears()
    {
        if (tearsProductionStored < tearsProductionLimit)
        {
            tearsProductionStored += BaseTearsProduction;
            Debug.Log($"{name} ha producido {BaseTearsProduction} lagrimas. Acumulado: {tearsProductionStored} lagrimas");
        }else
        {
            Debug.Log($"{name} ha alcanzado su limite de produccion de lagrimas");
            StopProduction();
        }
    }
    public void IncreaseProduction(float fiberMultiplier, float tearsMultiplier, int extraStorage)
    {
       BaseFibersProduction = Mathf.RoundToInt(BaseFibersProduction * fiberMultiplier);
       BaseTearsProduction = Mathf.RoundToInt(BaseTearsProduction * tearsMultiplier);

        fibersProductionLimit += extraStorage;
        tearsProductionLimit += extraStorage/5;
        Debug.Log($"{name} ha mejorado su produccion: Fibras: {BaseFibersProduction}, Lagrimas: {BaseTearsProduction}, Nuevo limite: {fibersProductionLimit}, {tearsProductionLimit}");
    }

    private void StopProduction()
    {
        if(isProducing)
        {
            isProducing = false;
            CancelInvoke(nameof(GenerateFibers));
            CancelInvoke(nameof(GenerateTears));
            Debug.Log($"{name} se ha apagado por alcanzar el limite de produccion");
            shutdownCoroutine = StartCoroutine(AutoShutdown());
        }
    }

    private void RestartProduction()
    {
        if(!isProducing)
        {
            isProducing = true;
            InvokeRepeating(nameof(GenerateFibers), fibersProductionInterval, fibersProductionInterval);
            InvokeRepeating(nameof(GenerateTears), tearsProductionInterval, tearsProductionInterval);
            Debug.Log($"{name} ha sido reactivada");
            if(shutdownCoroutine != null)
            {
                StopCoroutine(shutdownCoroutine);
            }
        }
    }

    private IEnumerator AutoShutdown()
    {
        yield return new WaitForSeconds(shutdownTime);

        if(fibersProductionStored >= fibersProductionLimit || tearsProductionStored >= tearsProductionLimit)
        {
            Debug.Log($"{name} se ha apagado por inactividad");
        }
    }
}



