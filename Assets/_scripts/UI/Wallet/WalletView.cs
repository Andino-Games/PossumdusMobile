using TMPro;
using UnityEngine;

namespace _scripts.UI.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        
        public void UpdateCoinView(int amount)
        {
            coinText.text = $"Coins: {amount}";
        }
    }
}