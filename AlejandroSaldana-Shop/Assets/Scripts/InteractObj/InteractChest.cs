using UnityEngine;

namespace InteractObj
{
    public class InteractChest : Interact
    {
        public override void InteractAction()
        {
            MainManager.Instance.StoreManager.isInStore = false;
            MainManager.Instance.StoreManager.gameObject.SetActive(true);
            MainManager.Instance.StoreManager.SetUpStore();
        }
    }
}
