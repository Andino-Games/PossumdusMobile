using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeButtonAndPanel : MonoBehaviour
{
    public static UpgradeButtonAndPanel instance;

    [Header("Panel Info")]
    public GameObject upgradePanel;
    public Button upgradeButton;
    public TextMeshProUGUI upgradeText;
    [SerializeField]private UpgradeMethods currentUpgrade;

   /* private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);

        upgradePanel.SetActive(false);
    }*/

    public void OpenUpgradePanel(UpgradeMethods upgrade)
    {
        currentUpgrade = upgrade;
        upgradePanel.SetActive(true);
        UpdateUpgradeInfo();
    }

    public void CloseUpgradePanel()
    {
        upgradePanel.SetActive(false);
    }

    private void UpdateUpgradeInfo()
    {
        if (currentUpgrade != null)
        {
            upgradeText.text = $"Costo: {currentUpgrade.currentCost} FS";
            upgradeButton.interactable = UpgradeManager.Instance.canAfford(currentUpgrade.currentCost);
        }
    }

    public void TryUpgrade()
    {
        if (currentUpgrade != null)
        {
            currentUpgrade.PurchaseUpgrade();
            UpdateUpgradeInfo();
        }
    }
}

    
