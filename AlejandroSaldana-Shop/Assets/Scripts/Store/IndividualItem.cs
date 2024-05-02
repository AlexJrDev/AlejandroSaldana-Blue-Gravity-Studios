using System;
using Scriptables;
using UnityEngine;
using UnityEngine.UI;

namespace Store
{
    public class IndividualItem : MonoBehaviour
    {
        public Item myItem;
        
        [SerializeField] private Image myItemImage;

        private StoreManager _storeManager;

        private void Awake()
        {
            _storeManager = GetComponentInParent<StoreManager>();
        }


        public void SetUpItem()
        {
            myItemImage.sprite = myItem.itemSprite;
        }

        public void BtnSelectItem()
        {
            _storeManager.EquipItem(myItem);

            if (_storeManager.isInStore)
            {
                _storeManager.SetBtnBuy(gameObject, myItem);
                return;
            }

            _storeManager.EquipVisibleItems();
            
            if(myItem.sellPrice == 0) return;
            _storeManager.SetBtnBuy(gameObject, myItem);
            
        }
    }
}
