using Feel;
using UnityEngine;

public class ClickerSimpleTest : MonoBehaviour
{
    public int fibersPerClick = 1;
    private void OnMouseDown()
    {
        AddResources();
        FeelClickerEffects.Instance.PlayMoveFeedback();
        Debug.Log("Hice Click :D");
    }

    public void AddResources()
    {
        ProductionManager.instance.CollectClickerProduction(fibersPerClick);
    }
}
