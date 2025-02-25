using Assets.Scripts.Systems.WalletSystem;
using TMPro;
using UnityEngine;

namespace UI.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI fibersText;
        [SerializeField] private TextMeshProUGUI tearsText;

        private void Start()
        {
            WalletService.Instance.OnFibersChanged += UpdateFibersView;
            WalletService.Instance.OnTearsChanged += UpdateTearsView;
            UpdateFibersView(WalletService.Instance.GetFibersAmount());
            UpdateTearsView(WalletService.Instance.GetTearsAmount());
        }

        private void OnDisable()
        {
            WalletService.Instance.OnFibersChanged -= UpdateFibersView;
            WalletService.Instance.OnTearsChanged -= UpdateTearsView;
        }

        private void UpdateFibersView(int amount)
        {
            if (fibersText != null)
            {
                fibersText.text = $"{amount}";
            }
        }

        private void UpdateTearsView(int amount)
        {
            if (tearsText != null)
            {
                tearsText.text = $"{amount}";
            }
        }
    }
}