using System;
using UnityEngine;

namespace DataObjects
{
    [CreateAssetMenu(fileName = "Coin", menuName = "Coin", order = 0)]
    public class WalletSO : ScriptableObject
    {
        [Header("Wallet Settings")]
        public string nameCoin;
        [SerializeField] private int _amountCoin;
        public int AmountCoin
        {
            get => _amountCoin;
            set
            {
                _amountCoin = value;
            }
        }

        public event Action<int> OnValueChanged;

        private void OnEnable()
        {
            _amountCoin = 0;
        }
        public void NotifyValueChanged()
        {
            OnValueChanged?.Invoke(AmountCoin);
        }
    }
}