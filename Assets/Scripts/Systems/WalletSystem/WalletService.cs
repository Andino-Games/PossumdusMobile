using DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Systems.WalletSystem
{
    public class WalletService: MonoBehaviour
    {
        [Header("Wallets")]
        public static WalletService Instance { get; private set; }
        [SerializeField]private WalletSO _walletFibers;
        [SerializeField]private WalletSO _walletTears;

        [Header("Ingreso Pasivo")]
        public int passiveFibersPerSecond = 1;
        [SerializeField] private bool isPassiveIncomeActive = true;

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

        private void Start()
        {
            StartCoroutine(PasiveIncomeRoutine());
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

        private IEnumerator PasiveIncomeRoutine()
        {
            while(isPassiveIncomeActive)
            {
                yield return new WaitForSeconds(1);
                if(passiveFibersPerSecond > 0)
                {
                    AddFibers(passiveFibersPerSecond);
                }
            }
        }

        public void IncreasePasiveIncome(int extraFibers)
        {
            passiveFibersPerSecond += extraFibers;
            Debug.Log($"Ingreso pasivo aumentado a {passiveFibersPerSecond}");
        }
    }
}





