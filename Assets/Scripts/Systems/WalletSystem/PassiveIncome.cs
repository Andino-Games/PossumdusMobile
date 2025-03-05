using Assets.Scripts.Systems.WalletSystem;
using System.Collections;
using UnityEngine;

public class PassiveIncome : MonoBehaviour
{
    public static PassiveIncome Instance;

    [Header("Ingreso Pasivo")]
    public int basePassiveProduction = 1;
    public int newPassiveProduction;
    public int basePassiveInterval = 4;
    public int newPassiveInterval;
    [SerializeField]private int minPassiveInterval = 1;
    [SerializeField] private bool isPassiveIncomeActive = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        TycoonManager.instance.OnActivatedMachine += IncreasePasiveIncome;
        IncreasePasiveIncome();
        StartCoroutine(PasiveIncomeRoutine());
    }
    private IEnumerator PasiveIncomeRoutine()
    {
        while (isPassiveIncomeActive)
        {
            yield return new WaitForSeconds(newPassiveInterval);
            if (newPassiveProduction > 0)
            {
                WalletService.Instance.AddFibers(newPassiveProduction);
            }
        }
    }
    
    public void IncreasePasiveIncome()
    {
        int ActiveMachinesCount = TycoonManager.instance.activatedTycoonElements.Count;
        float productionMultiplier = basePassiveProduction * (1 + ActiveMachinesCount * 0.05f);
        float frecuencyMultiplier = basePassiveInterval * (1 + ActiveMachinesCount * 0.02f);

        newPassiveProduction = Mathf.RoundToInt(basePassiveProduction * productionMultiplier);
        newPassiveInterval = (int)Mathf.Max(minPassiveInterval, basePassiveInterval * frecuencyMultiplier);
        Debug.Log($"Nueva produccion: {newPassiveProduction} cada {newPassiveInterval} segundos");
    }
}
    
   
