using DataObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Systems.WalletSystem
{
    public class WalletService: MonoBehaviour
    {
        public static WalletService Instance { get; private set; }
        [SerializeField]private WalletSO _walletFibers;
        [SerializeField]private WalletSO _walletTears;

        public event Action<int> OnFibersChanged;
        public event Action<int> OnTearsChanged;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                Debug.Log("Wallet Service Instance is assigned");
            }else
            {
                Destroy(gameObject);
            }
        }
        public void AddFibers(int amount)
        {
            if (amount <= 0) return;

            _walletFibers.AmountCoin += Mathf.Max(0, amount);
            _walletFibers.NotifyValueChanged();
            OnFibersChanged?.Invoke(_walletFibers.AmountCoin);
        }

        public void AddTears(int amount)
        {
            if (amount <= 0) return;

            _walletTears.AmountCoin += Mathf.Max(0, amount);
            _walletTears.NotifyValueChanged();
            OnTearsChanged?.Invoke(_walletTears.AmountCoin);
        }

        public bool SpendFibers(int amount)
        {
            if (amount > 0 || _walletFibers.AmountCoin >= amount)
            {
                _walletFibers.AmountCoin -= amount;
                _walletFibers.NotifyValueChanged();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SpendTears(int amount)
        {
            if (amount > 0 || _walletTears.AmountCoin >= amount)
            {
                _walletTears.AmountCoin -= amount;
                _walletTears.NotifyValueChanged();
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetFibersAmount()
        {
            return _walletFibers.AmountCoin;
        }


        public int GetTearsAmount()
        {
            return _walletTears.AmountCoin;
        }
    }
}





