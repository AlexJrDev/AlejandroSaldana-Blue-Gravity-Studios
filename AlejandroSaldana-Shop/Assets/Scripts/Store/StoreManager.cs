using System;
using System.Collections.Generic;
using Player;
using Scriptables;
using TMPro;
using UnityEngine;

namespace Store
{
    public class StoreManager : MonoBehaviour
    {
        [SerializeField] private PlayerBodyParts playerBodyParts;

        [Space] 
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private GameObject itemTypeMenu;
        [SerializeField] private GameObject itemStoreMenu;
        [SerializeField] private RectTransform itemsParent;
        [SerializeField] private GameObject itemPrefab;
        
        [Space]
        [SerializeField] private List<Item> availableHoods = new List<Item>();
        [SerializeField] private List<Item> availableFaces = new List<Item>();
        [SerializeField] private List<Item> availableShoulders = new List<Item>();
        [SerializeField] private List<Item> availableElbows = new List<Item>();
        [SerializeField] private List<Item> availableWrist = new List<Item>();
        [SerializeField] private List<Item> availableTorso = new List<Item>();
        [SerializeField] private List<Item> availablePelvis = new List<Item>();
        [SerializeField] private List<Item> availableLegs = new List<Item>();
        [SerializeField] private List<Item> availableBoots = new List<Item>();
        [SerializeField] private List<Item> availableWeapons = new List<Item>();

        [Space] 
        [SerializeField] private GameObject btnBuyRef;
        [SerializeField] private TextMeshProUGUI buyText;

        private Item _itemToBuy;
        private GameObject _lastItemSelected;


        public void EquipItem(Item newItem)
        {
            switch (newItem.bodyPartType)
            {
                case Item.BodyPart.Face:
                    playerBodyParts.SwapFace(newItem);
                    break;
                case Item.BodyPart.Hood:
                    playerBodyParts.SwapHood(newItem);
                    break;
                case Item.BodyPart.Torso:
                    playerBodyParts.SwapTorso(newItem);
                    break;
                case Item.BodyPart.Pelvis:
                    playerBodyParts.SwapPelvis(newItem);
                    break;
                case Item.BodyPart.Wrist:
                    playerBodyParts.SwapWrist(newItem);
                    break;
                case Item.BodyPart.Weapon:
                    playerBodyParts.SwapWeapon(newItem);
                    break;
                case Item.BodyPart.Elbow:
                    playerBodyParts.SwapElbow(newItem);
                    break;
                case Item.BodyPart.Shoulder:
                    playerBodyParts.SwapShoulder(newItem);
                    break;
                case Item.BodyPart.Boot:
                    playerBodyParts.SwapBoots(newItem);
                    break;
                case Item.BodyPart.Leg:
                    playerBodyParts.SwapLegs(newItem);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }

        public void SetBtnBuy(GameObject lastSelected, Item itemSelected)
        {
            _lastItemSelected = lastSelected;
            _itemToBuy = itemSelected;
            btnBuyRef.SetActive(true);
            buyText.text = "Buy with : " + itemSelected.buyCost.ToString();
        }

        public void BtnBuy()
        {
            if(_itemToBuy.buyCost > MainManager.Instance.Inventory.currentCoins) return;

            MainManager.Instance.Inventory.currentCoins -= _itemToBuy.buyCost;
            coinsText.text = MainManager.Instance.Inventory.currentCoins.ToString();
            
            Destroy(_lastItemSelected);
            btnBuyRef.SetActive(false);

            MainManager.Instance.PlayerBodyParts.SwapFullBody(playerBodyParts);
            
            switch (_itemToBuy.bodyPartType)
            {
                case Item.BodyPart.Face:
                    MainManager.Instance.Inventory.ownedFaces.Add(_itemToBuy);
                    break;
                case Item.BodyPart.Hood:
                    MainManager.Instance.Inventory.ownedHoods.Add(_itemToBuy);
                    break;
                case Item.BodyPart.Torso:
                    MainManager.Instance.Inventory.ownedTorso.Add(_itemToBuy);
                    break;
                case Item.BodyPart.Pelvis:
                    MainManager.Instance.Inventory.ownedPelvis.Add(_itemToBuy);
                    break;
                case Item.BodyPart.Wrist:
                    MainManager.Instance.Inventory.ownedWrists.Add(_itemToBuy);
                    break;
                case Item.BodyPart.Weapon:
                    MainManager.Instance.Inventory.ownedWeapon.Add(_itemToBuy);
                    break;
                case Item.BodyPart.Elbow:
                    MainManager.Instance.Inventory.ownedElbows.Add(_itemToBuy);
                    break;
                case Item.BodyPart.Shoulder:
                    MainManager.Instance.Inventory.ownedShoulders.Add(_itemToBuy);
                    break;
                case Item.BodyPart.Boot:
                    MainManager.Instance.Inventory.ownedBoot.Add(_itemToBuy);
                    break;
                case Item.BodyPart.Leg:
                    MainManager.Instance.Inventory.ownedLeg.Add(_itemToBuy);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }

        public void SetUpStore()
        {
            playerBodyParts.SwapFullBody(MainManager.Instance.PlayerBodyParts);
            coinsText.text = MainManager.Instance.Inventory.currentCoins.ToString();
            MainManager.Instance.Player.playerInput.SwitchCurrentActionMap("Wait");
        }

        public void BtnCloseStore()
        {
            MainManager.Instance.PlayerBodyParts.SwapFullBody(playerBodyParts);
            MainManager.Instance.Player.playerInput.SwitchCurrentActionMap("Player");
            gameObject.SetActive(false);
        }

        public void BtnBack()
        {
            itemStoreMenu.SetActive(false);
            btnBuyRef.SetActive(false);
            itemTypeMenu.SetActive(true);
            playerBodyParts.SwapFullBody(MainManager.Instance.PlayerBodyParts);
            
            foreach(Transform child in itemsParent.transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void BtnHoodStore()
        {
            foreach (var hood in availableHoods)
            {
                if (MainManager.Instance.Inventory.ownedHoods.Contains(hood)) continue;
                if(hood.bodyPartType != Item.BodyPart.Hood) continue;
                
                GameObject newItem = Instantiate(itemPrefab, itemsParent);
                var itemRef = newItem.GetComponent<IndividualItem>();
                itemRef.myItem = hood;
                itemRef.SetUpItem();
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnFaceStore()
        {

            foreach (var face in availableFaces)
            {
                if (MainManager.Instance.Inventory.ownedFaces.Contains(face)) continue;
                if(face.bodyPartType != Item.BodyPart.Face) continue;
                
                GameObject newItem = Instantiate(itemPrefab, itemsParent);
                var itemRef = newItem.GetComponent<IndividualItem>();
                itemRef.myItem = face;
                itemRef.SetUpItem();
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnShoulderStore()
        {
            foreach (var shoulder in availableShoulders)
            {
                if (MainManager.Instance.Inventory.ownedShoulders.Contains(shoulder)) continue;
                if(shoulder.bodyPartType != Item.BodyPart.Shoulder) continue;
                
                GameObject newItem = Instantiate(itemPrefab, itemsParent);
                var itemRef = newItem.GetComponent<IndividualItem>();
                itemRef.myItem = shoulder;
                itemRef.SetUpItem();
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnElbowStore()
        {

            foreach (var elbow in availableElbows)
            {
                if (MainManager.Instance.Inventory.ownedElbows.Contains(elbow)) continue;
                if(elbow.bodyPartType != Item.BodyPart.Elbow) continue;
                
                GameObject newItem = Instantiate(itemPrefab, itemsParent);
                var itemRef = newItem.GetComponent<IndividualItem>();
                itemRef.myItem = elbow;
                itemRef.SetUpItem();
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnWristStore()
        {
            foreach (var wrist in availableWrist)
            {
                if (MainManager.Instance.Inventory.ownedWrists.Contains(wrist)) continue;
                if(wrist.bodyPartType != Item.BodyPart.Wrist) continue;
                
                GameObject newItem = Instantiate(itemPrefab, itemsParent);
                var itemRef = newItem.GetComponent<IndividualItem>();
                itemRef.myItem = wrist;
                itemRef.SetUpItem();
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnTorsoStore()
        {
            foreach (var torso in availableTorso)
            {
                if (MainManager.Instance.Inventory.ownedTorso.Contains(torso)) continue;
                if(torso.bodyPartType != Item.BodyPart.Torso) continue;
                
                GameObject newItem = Instantiate(itemPrefab, itemsParent);
                var itemRef = newItem.GetComponent<IndividualItem>();
                itemRef.myItem = torso;
                itemRef.SetUpItem();
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnPelvisStore()
        {
            foreach (var pelvis in availablePelvis)
            {
                if (MainManager.Instance.Inventory.ownedPelvis.Contains(pelvis)) continue;
                if(pelvis.bodyPartType != Item.BodyPart.Pelvis) continue;
                
                GameObject newItem = Instantiate(itemPrefab, itemsParent);
                var itemRef = newItem.GetComponent<IndividualItem>();
                itemRef.myItem = pelvis;
                itemRef.SetUpItem();
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnLegsStore()
        {

            foreach (var legs in availableLegs)
            {
                if (MainManager.Instance.Inventory.ownedLeg.Contains(legs)) continue;
                if(legs.bodyPartType != Item.BodyPart.Leg) continue;
                
                GameObject newItem = Instantiate(itemPrefab, itemsParent);
                var itemRef = newItem.GetComponent<IndividualItem>();
                itemRef.myItem = legs;
                itemRef.SetUpItem();
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnBootsStore()
        {

            foreach (var boots in availableBoots)
            {
                if (MainManager.Instance.Inventory.ownedBoot.Contains(boots)) continue;
                if(boots.bodyPartType != Item.BodyPart.Boot) continue;
                
                GameObject newItem = Instantiate(itemPrefab, itemsParent);
                var itemRef = newItem.GetComponent<IndividualItem>();
                itemRef.myItem = boots;
                itemRef.SetUpItem();
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnWeaponsStore()
        {

            foreach (var weapon in availableWeapons)
            {
                if (MainManager.Instance.Inventory.ownedWeapon.Contains(weapon)) continue;
                if(weapon.bodyPartType != Item.BodyPart.Weapon) continue;
                
                GameObject newItem = Instantiate(itemPrefab, itemsParent);
                var itemRef = newItem.GetComponent<IndividualItem>();
                itemRef.myItem = weapon;
                itemRef.SetUpItem();
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        
    }
}
