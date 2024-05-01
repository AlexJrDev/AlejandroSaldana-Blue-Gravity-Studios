using Scriptables;
using UnityEngine;

namespace Player
{
    public class PlayerBodyParts : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer face;
        [SerializeField] private SpriteRenderer hood;
        [SerializeField] private SpriteRenderer torso;
        [SerializeField] private SpriteRenderer pelvis;
        
        [Space]
        [SerializeField] private SpriteRenderer wristLeft;
        [SerializeField] private SpriteRenderer elbowLeft;
        [SerializeField] private SpriteRenderer shoulderLeft;
        [SerializeField] private SpriteRenderer weaponLeft;
        
        [Space]
        [SerializeField] private SpriteRenderer wristRight;
        [SerializeField] private SpriteRenderer elbowRight;
        [SerializeField] private SpriteRenderer shoulderRight;
        [SerializeField] private SpriteRenderer weaponRight;
        
        [Space]
        [SerializeField] private SpriteRenderer bootLeft;
        [SerializeField] private SpriteRenderer legLeft;
        
        [Space]
        [SerializeField] private SpriteRenderer bootRight;
        [SerializeField] private SpriteRenderer legRight;


        public void SwapFace(Item newFace)
        {
            face.sprite = newFace.itemSprite;
        }
        public void SwapHood(Item newHood)
        {
            hood.sprite = newHood.itemSprite;
        }

        public void SwapTorso(Item newTorso)
        {
            torso.sprite = newTorso.itemSprite;
        }
    }
}
