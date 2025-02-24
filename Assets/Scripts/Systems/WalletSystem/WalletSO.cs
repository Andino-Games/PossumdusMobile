using System;
using UnityEngine;

namespace DataObjects
{
    [CreateAssetMenu(fileName = "Coin", menuName = "Coin", order = 0)]
    public class WalletSO : ScriptableObject
    {
        [Header("Coin Settings")]
        public string nameCoin; 
        public int amountCoin;
        public event Action<int> OnValueChanged;
        
        public void NotifyValueChanged()
        {
            OnValueChanged?.Invoke(amountCoin);
        }
        
    }
}