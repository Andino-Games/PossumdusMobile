using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TycoonPanel : MonoBehaviour
{
    public static TycoonPanel instance;

    [Header("Panel Settings")]
    public GameObject purchasePanel;
    public TextMeshProUGUI panelText;
    public Button buyFibersButton;
    public Button buyTearsButton;
    public TextMeshProUGUI fibersText;
    public TextMeshProUGUI tearsText;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
        }
        purchasePanel.SetActive(false);
    }

    public void OpenPanel(TycoonMethods tycoon)
    {
        if (tycoon != null)
        {
            panelText.text = "Purchase Machine";
            purchasePanel.SetActive(true);
            buyFibersButton.onClick.RemoveAllListeners();
            buyTearsButton.onClick.RemoveAllListeners();
            buyFibersButton.onClick.AddListener(() => TryUpgrade(tycoon, true));
            buyTearsButton.onClick.AddListener(() => TryUpgrade(tycoon, false));
            UpdatePurchaseInfo(tycoon);
        }
    }
    public void ClosePanel()
    {
        purchasePanel.SetActive(false);
        buyFibersButton.onClick.RemoveAllListeners(); 
        buyTearsButton?.onClick.RemoveAllListeners();
    }

    public void UpdatePurchaseInfo(TycoonMethods tycoon)
    {
        if (tycoon != null)
        {
            fibersText.text = $"{tycoon.CurrentCostFibers()} FS";
            tearsText.text = $"{tycoon.CurrentCostTears()} LG";
            buyFibersButton.interactable = TycoonEconomy.CanAfford(tycoon.CurrentCostFibers(), 0);
            buyTearsButton.interactable = TycoonEconomy.CanAfford(0, tycoon.CurrentCostTears());
        }
    }

    public void TryUpgrade(TycoonMethods tycoon, bool useFibers)
    {
        if (tycoon != null)
        {
            TycoonEconomy.Instance.PurchaseElement(tycoon, useFibers);
            UpdatePurchaseInfo(tycoon);

            if(tycoon.tycoonElement.activeSelf)
            {
                FindFirstObjectByType<TycoonTrigger>()?.DissapearAfterPurchase();
            }
        }
    }
}
