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
        public bool isInStore;
        
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
        [SerializeField] private GameObject btnRefHoods;
        [SerializeField] private GameObject btnRefFaces;
        [SerializeField] private GameObject btnRefShoulders;
        [SerializeField] private GameObject btnRefElbows;
        [SerializeField] private GameObject btnRefWrist;
        [SerializeField] private GameObject btnRefTorso;
        [SerializeField] private GameObject btnRefPelvis;
        [SerializeField] private GameObject btnRefLegs;
        [SerializeField] private GameObject btnRefBoots;
        [SerializeField] private GameObject btnRefWeapons;
        
        [Space] 
        [SerializeField] private GameObject btnBuySellRef;
        [SerializeField] private GameObject btnEquip;
        [SerializeField] private TextMeshProUGUI buySellText;

        private Item _itemToInteract;
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
            _itemToInteract = itemSelected;
            
            if (isInStore)
            {
                buySellText.text = "Buy with : " + itemSelected.buyCost.ToString();
                btnBuySellRef.SetActive(true);
            }
            else
            {
                if(itemSelected.sellPrice == 0) return;
                buySellText.text = "Sell for : " + itemSelected.sellPrice.ToString();
                btnBuySellRef.SetActive(true);
            }
        }

        public void BtnBuy()
        {
            if (isInStore)
            {
                if(_itemToInteract.buyCost > MainManager.Instance.Inventory.currentCoins) return;

                MainManager.Instance.Inventory.currentCoins -= _itemToInteract.buyCost;
                coinsText.text = MainManager.Instance.Inventory.currentCoins.ToString();
            
                Destroy(_lastItemSelected);
                btnBuySellRef.SetActive(false);
                
                MainManager.Instance.PlayerBodyParts.SwapFullBody(playerBodyParts);
            
                switch (_itemToInteract.bodyPartType) {
                case Item.BodyPart.Face:
                    MainManager.Instance.Inventory.ownedFaces.Add(_itemToInteract);
                    MainManager.Instance.Inventory.currentFace = _itemToInteract;
                    break;
                case Item.BodyPart.Hood:
                    MainManager.Instance.Inventory.ownedHoods.Add(_itemToInteract);
                    MainManager.Instance.Inventory.currentHood = _itemToInteract;
                    break;
                case Item.BodyPart.Torso:
                    MainManager.Instance.Inventory.ownedTorso.Add(_itemToInteract);
                    MainManager.Instance.Inventory.currentTorso = _itemToInteract;
                    break;
                case Item.BodyPart.Pelvis:
                    MainManager.Instance.Inventory.ownedPelvis.Add(_itemToInteract);
                    MainManager.Instance.Inventory.currentPelvis = _itemToInteract;
                    break;
                case Item.BodyPart.Wrist:
                    MainManager.Instance.Inventory.ownedWrists.Add(_itemToInteract);
                    MainManager.Instance.Inventory.currentWrist = _itemToInteract;
                    break;
                case Item.BodyPart.Weapon:
                    MainManager.Instance.Inventory.ownedWeapon.Add(_itemToInteract);
                    MainManager.Instance.Inventory.currentWeapon = _itemToInteract;
                    break;
                case Item.BodyPart.Elbow:
                    MainManager.Instance.Inventory.ownedElbows.Add(_itemToInteract);
                    MainManager.Instance.Inventory.currentElbow = _itemToInteract;
                    break;
                case Item.BodyPart.Shoulder:
                    MainManager.Instance.Inventory.ownedShoulders.Add(_itemToInteract);
                    MainManager.Instance.Inventory.currentShoulder = _itemToInteract;
                    break;
                case Item.BodyPart.Boot:
                    MainManager.Instance.Inventory.ownedBoot.Add(_itemToInteract);
                    MainManager.Instance.Inventory.currentBoot = _itemToInteract;
                    break;
                case Item.BodyPart.Leg:
                    MainManager.Instance.Inventory.ownedLeg.Add(_itemToInteract);
                    MainManager.Instance.Inventory.currentLeg = _itemToInteract;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            }
            else
            {
                MainManager.Instance.Inventory.currentCoins += _itemToInteract.sellPrice;
                
                coinsText.text = MainManager.Instance.Inventory.currentCoins.ToString();
                Destroy(_lastItemSelected);
                
                switch (_itemToInteract.bodyPartType)
                {
                    case Item.BodyPart.Face:
                        MainManager.Instance.Inventory.ownedFaces.Remove(_itemToInteract);
                        break;
                    case Item.BodyPart.Hood:
                        MainManager.Instance.Inventory.ownedHoods.Remove(_itemToInteract);
                        break;
                    case Item.BodyPart.Torso:
                        MainManager.Instance.Inventory.ownedTorso.Remove(_itemToInteract);
                        break;
                    case Item.BodyPart.Pelvis:
                        MainManager.Instance.Inventory.ownedPelvis.Remove(_itemToInteract);
                        break;
                    case Item.BodyPart.Wrist:
                        MainManager.Instance.Inventory.ownedWrists.Remove(_itemToInteract);
                        break;
                    case Item.BodyPart.Weapon:
                        MainManager.Instance.Inventory.ownedWeapon.Remove(_itemToInteract);
                        break;
                    case Item.BodyPart.Elbow:
                        MainManager.Instance.Inventory.ownedElbows.Remove(_itemToInteract);
                        break;
                    case Item.BodyPart.Shoulder:
                        MainManager.Instance.Inventory.ownedShoulders.Remove(_itemToInteract);
                        break;
                    case Item.BodyPart.Boot:
                        MainManager.Instance.Inventory.ownedBoot.Remove(_itemToInteract);
                        break;
                    case Item.BodyPart.Leg:
                        MainManager.Instance.Inventory.ownedLeg.Remove(_itemToInteract);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                btnBuySellRef.SetActive(false);
                btnEquip.SetActive(false);
            }
            
            
        }

        public void ShowBtnEquip()
        {
            btnEquip.SetActive(true);
        }

        public void SetUpStore()
        {
            playerBodyParts.SwapFullBody(MainManager.Instance.PlayerBodyParts);
            coinsText.text = MainManager.Instance.Inventory.currentCoins.ToString();
            MainManager.Instance.Player.playerInput.SwitchCurrentActionMap("Wait");
            
            ShowHideMenuBtns();
        }

        private void ShowHideMenuBtns()
        {
            if (isInStore)
            {
                btnRefHoods.SetActive(availableHoods.Count != MainManager.Instance.Inventory.ownedHoods.Count);
                btnRefFaces.SetActive(availableFaces.Count != MainManager.Instance.Inventory.ownedFaces.Count);
                btnRefShoulders.SetActive(availableShoulders.Count != MainManager.Instance.Inventory.ownedShoulders.Count);
                btnRefElbows.SetActive(availableElbows.Count != MainManager.Instance.Inventory.ownedElbows.Count);
                btnRefWrist.SetActive(availableWrist.Count != MainManager.Instance.Inventory.ownedWrists.Count);
                btnRefTorso.SetActive(availableTorso.Count != MainManager.Instance.Inventory.ownedTorso.Count);
                btnRefPelvis.SetActive(availablePelvis.Count != MainManager.Instance.Inventory.ownedPelvis.Count);
                btnRefLegs.SetActive(availableLegs.Count != MainManager.Instance.Inventory.ownedLeg.Count);
                btnRefBoots.SetActive(availableBoots.Count != MainManager.Instance.Inventory.ownedBoot.Count);
                btnRefWeapons.SetActive(availableWeapons.Count != MainManager.Instance.Inventory.ownedWeapon.Count);
            }
            else
            {
                btnRefHoods.SetActive(MainManager.Instance.Inventory.ownedHoods.Count != 1);
                btnRefFaces.SetActive(MainManager.Instance.Inventory.ownedFaces.Count != 1);
                btnRefShoulders.SetActive(MainManager.Instance.Inventory.ownedShoulders.Count != 1);
                btnRefElbows.SetActive(MainManager.Instance.Inventory.ownedElbows.Count != 1);
                btnRefWrist.SetActive(MainManager.Instance.Inventory.ownedWrists.Count != 1);
                btnRefTorso.SetActive(MainManager.Instance.Inventory.ownedTorso.Count != 1);
                btnRefPelvis.SetActive(MainManager.Instance.Inventory.ownedPelvis.Count != 1);
                btnRefLegs.SetActive(MainManager.Instance.Inventory.ownedLeg.Count != 1);
                btnRefBoots.SetActive(MainManager.Instance.Inventory.ownedBoot.Count != 1);
                btnRefWeapons.SetActive(MainManager.Instance.Inventory.ownedWeapon.Count != 1);
            }
        }

        public void BtnCloseStore()
        {
            EquipVisibleItems();
            MainManager.Instance.Player.playerInput.SwitchCurrentActionMap("Player");
            gameObject.SetActive(false);
            BtnBack();
        }

        public void EquipVisibleItems()
        {
            MainManager.Instance.PlayerBodyParts.SwapFullBody(playerBodyParts);
            
            if(isInStore) return;
            
            if (_itemToInteract == null) return;
            
            switch (_itemToInteract.bodyPartType) {
                case Item.BodyPart.Face:
                    MainManager.Instance.Inventory.currentFace = _itemToInteract;
                    break;
                case Item.BodyPart.Hood:
                    MainManager.Instance.Inventory.currentHood = _itemToInteract;
                    break;
                case Item.BodyPart.Torso:
                    MainManager.Instance.Inventory.currentTorso = _itemToInteract;
                    break;
                case Item.BodyPart.Pelvis:
                    MainManager.Instance.Inventory.currentPelvis = _itemToInteract;
                    break;
                case Item.BodyPart.Wrist:
                    MainManager.Instance.Inventory.currentWrist = _itemToInteract;
                    break;
                case Item.BodyPart.Weapon:
                    MainManager.Instance.Inventory.currentWeapon = _itemToInteract;
                    break;
                case Item.BodyPart.Elbow:
                    MainManager.Instance.Inventory.currentElbow = _itemToInteract;
                    break;
                case Item.BodyPart.Shoulder:
                    MainManager.Instance.Inventory.currentShoulder = _itemToInteract;
                    break;
                case Item.BodyPart.Boot:
                    MainManager.Instance.Inventory.currentBoot = _itemToInteract;
                    break;
                case Item.BodyPart.Leg:
                    MainManager.Instance.Inventory.currentLeg = _itemToInteract;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void BtnBack()
        {
            ShowHideMenuBtns();
            
            itemStoreMenu.SetActive(false);
            btnBuySellRef.SetActive(false);
            itemTypeMenu.SetActive(true);
            playerBodyParts.SwapFullBody(MainManager.Instance.PlayerBodyParts);
            
            foreach(Transform child in itemsParent.transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void BtnHoodStore()
        {
            if (isInStore)
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
            }
            else
            {
                foreach (var hood in MainManager.Instance.Inventory.ownedHoods)
                {
                    if (hood == MainManager.Instance.Inventory.currentHood) continue;
                    if(hood.bodyPartType != Item.BodyPart.Hood) continue;
                
                    GameObject newItem = Instantiate(itemPrefab, itemsParent);
                    var itemRef = newItem.GetComponent<IndividualItem>();
                    itemRef.myItem = hood;
                    itemRef.SetUpItem();
                }
            }
            
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnFaceStore()
        {

            if (isInStore)
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
            }
            else
            {
                foreach (var face in MainManager.Instance.Inventory.ownedFaces)
                {
                    if (face == MainManager.Instance.Inventory.currentFace) continue;
                    if(face.bodyPartType != Item.BodyPart.Face) continue;
                
                    GameObject newItem = Instantiate(itemPrefab, itemsParent);
                    var itemRef = newItem.GetComponent<IndividualItem>();
                    itemRef.myItem = face;
                    itemRef.SetUpItem();
                }
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnShoulderStore()
        {
            if (isInStore)
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
            }
            else
            {
                foreach (var shoulder in MainManager.Instance.Inventory.ownedShoulders)
                {
                    if (shoulder == MainManager.Instance.Inventory.currentShoulder) continue;
                    if(shoulder.bodyPartType != Item.BodyPart.Shoulder) continue;
                
                    GameObject newItem = Instantiate(itemPrefab, itemsParent);
                    var itemRef = newItem.GetComponent<IndividualItem>();
                    itemRef.myItem = shoulder;
                    itemRef.SetUpItem();
                }
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnElbowStore()
        {

            if (isInStore)
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
            }
            else
            {
                foreach (var elbow in MainManager.Instance.Inventory.ownedElbows)
                {
                    if (elbow == MainManager.Instance.Inventory.currentElbow) continue;
                    if(elbow.bodyPartType != Item.BodyPart.Elbow) continue;
                
                    GameObject newItem = Instantiate(itemPrefab, itemsParent);
                    var itemRef = newItem.GetComponent<IndividualItem>();
                    itemRef.myItem = elbow;
                    itemRef.SetUpItem();
                }
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnWristStore()
        {
            if (isInStore)
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
            }
            else
            {
                foreach (var wrist in MainManager.Instance.Inventory.ownedWrists)
                {
                    if (wrist == MainManager.Instance.Inventory.currentWrist) continue;
                    if(wrist.bodyPartType != Item.BodyPart.Wrist) continue;
                
                    GameObject newItem = Instantiate(itemPrefab, itemsParent);
                    var itemRef = newItem.GetComponent<IndividualItem>();
                    itemRef.myItem = wrist;
                    itemRef.SetUpItem();
                }
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnTorsoStore()
        {
            if (isInStore)
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
            }
            else
            {
                foreach (var torso in MainManager.Instance.Inventory.ownedTorso)
                {
                    if (torso == MainManager.Instance.Inventory.currentTorso) continue;
                    if(torso.bodyPartType != Item.BodyPart.Torso) continue;
                
                    GameObject newItem = Instantiate(itemPrefab, itemsParent);
                    var itemRef = newItem.GetComponent<IndividualItem>();
                    itemRef.myItem = torso;
                    itemRef.SetUpItem();
                }
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnPelvisStore()
        {
            if (isInStore)
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
            }
            else
            {
                foreach (var pelvis in MainManager.Instance.Inventory.ownedPelvis)
                {
                    if (pelvis == MainManager.Instance.Inventory.currentPelvis) continue;
                    if(pelvis.bodyPartType != Item.BodyPart.Pelvis) continue;
                
                    GameObject newItem = Instantiate(itemPrefab, itemsParent);
                    var itemRef = newItem.GetComponent<IndividualItem>();
                    itemRef.myItem = pelvis;
                    itemRef.SetUpItem();
                }
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnLegsStore()
        {

            if (isInStore)
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
            }
            else
            {
                foreach (var legs in MainManager.Instance.Inventory.ownedLeg)
                {
                    if (legs == MainManager.Instance.Inventory.currentLeg) continue;
                    if(legs.bodyPartType != Item.BodyPart.Leg) continue;
                
                    GameObject newItem = Instantiate(itemPrefab, itemsParent);
                    var itemRef = newItem.GetComponent<IndividualItem>();
                    itemRef.myItem = legs;
                    itemRef.SetUpItem();
                }
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnBootsStore()
        {

            if (isInStore)
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
            }
            else
            {
                foreach (var boots in MainManager.Instance.Inventory.ownedBoot)
                {
                    if (boots == MainManager.Instance.Inventory.currentBoot) continue;
                    if(boots.bodyPartType != Item.BodyPart.Boot) continue;
                
                    GameObject newItem = Instantiate(itemPrefab, itemsParent);
                    var itemRef = newItem.GetComponent<IndividualItem>();
                    itemRef.myItem = boots;
                    itemRef.SetUpItem();
                }
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        public void BtnWeaponsStore()
        {

            if (isInStore)
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
            }
            else
            {
                foreach (var weapon in MainManager.Instance.Inventory.ownedWeapon)
                {
                    if (weapon == MainManager.Instance.Inventory.currentWeapon) continue;
                    if(weapon.bodyPartType != Item.BodyPart.Weapon) continue;
                
                    GameObject newItem = Instantiate(itemPrefab, itemsParent);
                    var itemRef = newItem.GetComponent<IndividualItem>();
                    itemRef.myItem = weapon;
                    itemRef.SetUpItem();
                }
            }
            
            itemTypeMenu.SetActive(false);
            itemStoreMenu.SetActive(true);
        }
        
        
    }
}
