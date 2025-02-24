using System;
using UnityEngine;

namespace DataObjects
{
    [CreateAssetMenu(fileName = "Coin", menuName = "Coin", order = 0)]
    public class WalletSO : ScriptableObject
    {
        public event Action<int> OnValueChanged;
        
        [Header("Coin Settings")]
        public string nameCoin; 
        public int amountCoin;

        public void AddCoins(int amount)
        {
            amountCoin += Mathf.Max(0, amount);
            OnValueChanged?.Invoke(amountCoin);
        }

        public bool SpendCoins(int amount)
        {
            if (amount <= 0 || amountCoin < amount)
            {
                return false;
            }

            amountCoin = Mathf.Max(amountCoin - amount, 0);
            OnValueChanged?.Invoke(amountCoin);
            return true;
        }

        public void SetCoins(int amount)
        {
            amountCoin = Mathf.Max(0, amount);
            OnValueChanged?.Invoke(amountCoin);
        }
    }
}