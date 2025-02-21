using System;
using UnityEngine;

namespace Wallet
{
    public class WalletManager
    {
        public event Action<int> OnCoinsChanged;
        
        private int _currentCoins;
        
        public WalletManager(int startingCoins)
        {
            _currentCoins = PlayerPrefs.GetInt("Coins", startingCoins);
            Initialize();
        }
        
        public void Initialize() 
        {
            OnCoinsChanged?.Invoke(_currentCoins);
        }
        
        public void AddCoins(int amount)
        {
            if (amount <= 0) 
            {
                return;
            }
            
            _currentCoins += amount;
            UpdateCoins();
        }
        
        public bool SpendCoins(int amount)
        {
            if (amount <= 0 || _currentCoins < amount) 
            {
                return false;
            }
            
            _currentCoins -= amount;
            UpdateCoins();
            return true;
        }
        
        public bool SetCoins(int amount)
        {
            if (amount < 0) 
            {
                return false;
            }
            
            _currentCoins = amount;
            UpdateCoins();
            return true;
        }
        
        private void UpdateCoins()
        {
            PlayerPrefs.SetInt("Coins", _currentCoins);
            PlayerPrefs.Save();
            OnCoinsChanged?.Invoke(_currentCoins); 
        }
    }
}
