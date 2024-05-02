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

            
            //resize the icon (hardcode :c)
            switch (myItem.bodyPartType)
            {
                case Item.BodyPart.Face:
                    myItemImage.SetNativeSize();
                    myItemImage.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
                    myItemImage.transform.localPosition = new Vector3(100f, 80f, 0f);
                    break;
                case Item.BodyPart.Hood:
                    myItemImage.SetNativeSize();
                    myItemImage.transform.localScale = new Vector3(0.3f, 0.3f, 1f);
                    myItemImage.transform.localPosition = new Vector3(100f, 50f, 0f);
                    break;
                case Item.BodyPart.Torso:
                    myItemImage.SetNativeSize();
                    myItemImage.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
                    myItemImage.transform.localPosition = new Vector3(100f, 180f, 0f);
                    break;
                case Item.BodyPart.Pelvis:
                    myItemImage.SetNativeSize();
                    myItemImage.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
                    myItemImage.transform.localPosition = new Vector3(100f, 230f, 0f);
                    break;
                case Item.BodyPart.Wrist:
                    myItemImage.SetNativeSize();
                    myItemImage.transform.localPosition = new Vector3(350f, 450f, 0f);
                    break;
                case Item.BodyPart.Weapon:
                    myItemImage.SetNativeSize();
                    myItemImage.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                    myItemImage.transform.localPosition = new Vector3(25, 280, 0f);
                    break;
                case Item.BodyPart.Elbow:
                    myItemImage.SetNativeSize();
                    myItemImage.transform.localPosition = new Vector3(320f, 350f, 0f);
                    break;
                case Item.BodyPart.Shoulder:
                    myItemImage.SetNativeSize();
                    myItemImage.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
                    myItemImage.transform.localPosition = new Vector3(225f, 200f, 0f);
                    break;
                case Item.BodyPart.Boot:
                    myItemImage.SetNativeSize();
                    myItemImage.transform.localPosition = new Vector3(270, 550, 0f);
                    break;
                case Item.BodyPart.Leg:
                    myItemImage.SetNativeSize();
                    myItemImage.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
                    myItemImage.transform.localPosition = new Vector3(220, 400, 0f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void BtnSelectItem()
        {
            _storeManager.EquipItem(myItem);

            _storeManager.SetBtnBuy(gameObject, myItem);

            if(_storeManager.isInStore) return;
            _storeManager.ShowBtnEquip();

        }
    }
}
