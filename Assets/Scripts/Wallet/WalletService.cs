using DataObjects;
using UnityEngine;

namespace Wallet
{
    public class WalletService
    {
        private readonly WalletSO _wallet;

        public WalletService(WalletSO walletSo)
        {
            _wallet = walletSo;
        }
        
        public void AddCoins(int amount)
        {
            if (amount <= 0)return;
            
            _wallet.amountCoin += Mathf.Max(0, amount);
            _wallet.NotifyValueChanged();
        }

        public bool SpendCoins(int amount)
        {
            if (amount <= 0 || _wallet.amountCoin < amount)
            {
                return false;
            }

            _wallet.amountCoin = Mathf.Max(_wallet.amountCoin - amount, 0); 
            _wallet.NotifyValueChanged();
            return true;
        }

        public void SetCoins(int amount)
        {
            _wallet.amountCoin = Mathf.Max(0, amount);
            _wallet.NotifyValueChanged();
        }
    }
}