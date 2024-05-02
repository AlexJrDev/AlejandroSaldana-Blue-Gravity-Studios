using UnityEngine;

namespace InteractObj
{
    public class InteractStore : Interact
    {
        public override void InteractAction()
        {
            MainManager.Instance.StoreManager.isInStore = true;
            MainManager.Instance.StoreManager.gameObject.SetActive(true);
            MainManager.Instance.StoreManager.SetUpStore();
        }
    }
}
