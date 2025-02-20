using DataObjects;
using TMPro;
using UnityEngine;

namespace UI.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private WalletSo walletSo;
        [SerializeField] private TextMeshProUGUI coinText;

        private void OnEnable()
        {
            walletSo.OnValueChanged += UpdateCoinView;
            UpdateCoinView(walletSo.amountCoin);
        }
        
        private void UpdateCoinView(int amount)
        {
            if (coinText != null)
            {
                coinText.text = $"{walletSo.nameCoin}: {walletSo.amountCoin}";
            }
        }
    }
}