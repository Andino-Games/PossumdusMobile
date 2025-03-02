using UnityEngine;

public class TycoonTrigger : MonoBehaviour
{
    public TycoonMethods machineTarget;
    private bool isPressed;

    private void Start()
    {
        if (machineTarget == null)
        {
            Debug.Log($"El boton {name} no encuentra ninguna maquina vinculada");
        }
    }

    public void OnMouseDown()
    {
        if (!isPressed && machineTarget != null)
        {
            isPressed = true;
            TycoonPanel.instance.OpenPanel(machineTarget);
            Debug.Log($"presionando {name}, abriendo panel de compras para {machineTarget.name}");
        }
    }

    private void OnMouseUp()
    {
        isPressed = false;
    }

    public void DissapearAfterPurchase()
    {
        gameObject.SetActive(false);
    }
}
          
    

