using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeTrigger : MonoBehaviour
{
    [Header("TapInteraction Info")]
    [SerializeField]private bool isHolding = false;
    [SerializeField]private float holdTime = 0f;
    [SerializeField]private float holdDuration = 1f;

    private void Update()
    {
        if (isHolding)
        {
            holdTime += Time.deltaTime;
            if (holdTime >= holdDuration)
            {
                OpenUpgradePanel();
                isHolding = false;
            }
        }
    }
    public void OnMouseDown()
    {

        Debug.Log($"presionado {name}");
        isHolding = true;
        holdTime = 0f;
    }

    public void OnMouseUp()
    {
        isHolding = false;
    }

    public void OpenUpgradePanel()
    {
        UpgradeButtonAndPanel.instance.OpenUpgradePanel(GetComponent<UpgradeMethods>());
    }
}
