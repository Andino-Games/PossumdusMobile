using _scripts.Wallet;
using UnityEngine;

namespace _scripts.UI.Wallet
{
    public class WalletController : MonoBehaviour
    {
        [SerializeField] private WalletView walletView;
        [SerializeField] private int startingCoins;
        
        private WalletManager _walletManager;
        
        private void Awake()
        {
            _walletManager = new WalletManager(startingCoins);
            _walletManager.OnCoinsChanged += walletView.UpdateCoinView;
            _walletManager.Initialize();
        }
        
        private void OnDestroy()
        {
            _walletManager.OnCoinsChanged -= walletView.UpdateCoinView;
        }
        
        public void AddCoins(int amount)
        {
            _walletManager.AddCoins(amount);
        }
         
        public void SpendCoins(int amount)
        {
            _walletManager.SpendCoins(amount);
        }
    }
}