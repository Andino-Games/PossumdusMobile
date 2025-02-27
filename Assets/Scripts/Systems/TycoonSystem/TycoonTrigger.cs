using UnityEngine;

public class TycoonTrigger : MonoBehaviour
{
    private bool isPressed;

    private void Update()
    {
        if (!isPressed)
        {
            TycoonPanel.instance.OpenPanel(GetComponent<TycoonMethods>());
            isPressed = false;
        }
    }

    public void OnMouseDown()
    {
        isPressed = true;
        Debug.Log($"presionando {name}");
      
    }
}
