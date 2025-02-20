using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    public static UpgradePanel instance;

    [Header("Panel Info")]
    public GameObject upgradePanel;
    public Button upgradeButton;
    public TextMeshProUGUI upgradeText;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);

        upgradePanel.SetActive(false);
    }

    public void OpenUpgradePanel(UpgradeMethods upgrade)
    {
        upgradePanel.SetActive(true);
        UpdateUpgradeInfo(upgrade);
        upgradeButton.onClick.RemoveAllListeners();
        upgradeButton.onClick.AddListener(() => TryUpgrade(upgrade));
    }

    public void CloseUpgradePanel()
    {
        upgradePanel.SetActive(false);
        upgradeButton.onClick.RemoveAllListeners();
    }

    private void UpdateUpgradeInfo(UpgradeMethods upgrade)
    {
        if (upgrade != null)
        {
            upgradeText.text = $"{upgrade.currentCost} FS";
            upgradeButton.interactable = UpgradeManager.Instance.canAfford(upgrade.currentCost);
        }
    }

    public void TryUpgrade(UpgradeMethods upgrade)
    {
        if (upgrade != null)
        {
            UpgradeManager.Instance.PurchaseUpgrade(upgrade);
            UpdateUpgradeInfo(upgrade);
        }
    }
}

    
