using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeTrigger : MonoBehaviour
{
    [Header("TapInteraction Info")]
    [SerializeField] private bool isHolding = false;
    [SerializeField] private float holdTime = 0f;
    [SerializeField] private float holdDuration = 1f;

    private void Update()
    {
        if (isHolding)
        {
            holdTime += Time.deltaTime;
            if (holdTime >= holdDuration)
            {
                UpgradePanel.instance.OpenUpgradePanel(GetComponent<UpgradeMethods>());
                isHolding = false;
            }
        }
    }
    public void OnMouseDown()
    {

        Debug.Log($"presionando {name}");
        isHolding = true;
        holdTime = 0f;
    }

    public void OnMouseUp()
    {
        isHolding = false;
    }
}

    
