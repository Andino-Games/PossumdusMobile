using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductionView : MonoBehaviour
{
    public TextMeshProUGUI fibersText;
    public TextMeshProUGUI tearsText;

    private void Start()
    {
        ProductionManager.instance.OnFibersUpdated += UpdateFibersUI;
        ProductionManager.instance.OnTearsUpdated += UpdateTearsUI;
    }

    private void UpdateFibersUI( int newAmount)
    {
        fibersText.text = $"{newAmount}";
    }

    private void UpdateTearsUI(int newAmount)
    {
        tearsText.text = $"{newAmount}";
    }
}
