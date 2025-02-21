using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    public static UpgradePanel instance;

    [Header("Panel Info")]
    public GameObject upgradePanel;
    public Button upgradeFibersButton;
    public Button upgradeTearsButton;
    public TextMeshProUGUI upgradeFibersText;
    public TextMeshProUGUI upgradeTearsText;
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
        upgradeFibersButton.onClick.RemoveAllListeners();
        upgradeFibersButton.onClick.AddListener(() => TryUpgrade(upgrade, true));
        upgradeTearsButton.onClick.RemoveAllListeners();
        upgradeTearsButton.onClick.AddListener(() => TryUpgrade(upgrade, false));
    }

    public void CloseUpgradePanel()
    {
        upgradePanel.SetActive(false);
        upgradeFibersButton.onClick.RemoveAllListeners();
        upgradeTearsButton.onClick.RemoveAllListeners();
    }

    private void UpdateUpgradeInfo(UpgradeMethods upgrade)
    {
        if (upgrade != null)
        {
            upgradeFibersText.text = $"{upgrade.currentCostFibers} FS";
            upgradeTearsText.text = $"{upgrade.currentCostTears} LG";
            upgradeFibersButton.interactable = UpgradeManager.Instance.canAfford(upgrade.currentCostFibers, 0);
            upgradeTearsButton.interactable = UpgradeManager.Instance.canAfford(0, upgrade.currentCostTears);
        }
    }

    public void TryUpgrade(UpgradeMethods upgrade, bool useFibers)
    {
        if (upgrade != null)
        {
            UpgradeManager.Instance.PurchaseUpgrade(upgrade, useFibers);
            UpdateUpgradeInfo(upgrade);
        }
    }
}

    
