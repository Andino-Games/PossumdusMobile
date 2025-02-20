using DataObjects;
using UnityEngine;

namespace UI.Wallet
{
    public class WalletController : MonoBehaviour
    {
        [SerializeField] private WalletSo walletSo;

        public void AddCoins(int amount)
        {
            walletSo.AddCoins(amount);
        }

        public void SpendCoins(int amount)
        {
            walletSo.SpendCoins(amount);
        }

        public void SetCoins(int amount)
        {
            walletSo.SetCoins(amount);
        }
    }
}