using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    public static UpgradeView instance;

    [Header("Panel Info")]
    public GameObject upgradePanel;
    public TextMeshProUGUI panelText;
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
        panelText.text = "Upgrade Machine";
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
            upgradeFibersText.text = $"{upgrade.CurrentCostFibers()} FS";
            upgradeTearsText.text = $"{upgrade.CurrentCostTears()} LG";
            upgradeFibersButton.interactable = UpgradeManager.Instance.CanAfford(upgrade.CurrentCostFibers(), 0);
            upgradeTearsButton.interactable = UpgradeManager.Instance.CanAfford(0, upgrade.CurrentCostTears());
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

    
