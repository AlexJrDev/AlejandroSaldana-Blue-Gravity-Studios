using System;
using UnityEngine;

namespace InteractObj
{
    public class Interact : MonoBehaviour
    {
        [SerializeField] private Color colorInArea;

        [SerializeField] private SpriteRenderer mySpriteRenderer;

        public virtual void InteractAction(){}
        

        public virtual void InArea()
        {
            mySpriteRenderer.color = colorInArea;
        }

        public virtual void ExitArea()
        {
            mySpriteRenderer.color = Color.white;
        }
    }
}
