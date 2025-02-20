using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductionView : MonoBehaviour
{
    public TextMeshProUGUI resourceText;

    private void Start()
    {
        ProductionManager.instance.OnResourceUpdated += UpdateUI;
    }

    private void UpdateUI( int newAmount)
    {
        resourceText.text = $"{newAmount}";
    }
}
