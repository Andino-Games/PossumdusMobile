using UnityEngine;

public class ClickerSimpleTest : MonoBehaviour
{
    public int fibersPerClick = 1;
    private void OnMouseDown()
    {
        AddResources();
    }

    public void AddResources()
    {

        ProductionManager.instance.CollectClickerProduction(fibersPerClick);
    }
}
