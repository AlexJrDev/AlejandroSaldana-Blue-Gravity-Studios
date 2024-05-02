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
        
        public void SwapPelvis(Item newPelvis)
        {
            pelvis.sprite = newPelvis.itemSprite;
        }
        
        public void SwapShoulder(Item newShoulder)
        {
            shoulderLeft.sprite = newShoulder.itemSprite;
            shoulderRight.sprite = newShoulder.itemSprite2;
        }
        
        public void SwapElbow(Item newElbow)
        {
            elbowLeft.sprite = newElbow.itemSprite;
            elbowRight.sprite = newElbow.itemSprite2;
        }
        
        public void SwapWrist(Item newWrist)
        {
            wristLeft.sprite = newWrist.itemSprite;
            wristRight.sprite = newWrist.itemSprite2;
        }
        
        public void SwapLegs(Item newLegs)
        {
            legLeft.sprite = newLegs.itemSprite;
            legRight.sprite = newLegs.itemSprite2;
        }
        
        public void SwapBoots(Item newBoots)
        {
            bootLeft.sprite = newBoots.itemSprite;
            bootRight.sprite = newBoots.itemSprite2;
        }
        
        public void SwapWeapon(Item newWeapon)
        {
            weaponLeft.sprite = newWeapon.itemSprite;
            weaponRight.sprite = newWeapon.itemSprite2;
        }

        public void SwapFullBody(PlayerBodyParts newBody)
        {
            face.sprite = newBody.face.sprite;
            hood.sprite = newBody.hood.sprite;
            torso.sprite = newBody.torso.sprite;
            pelvis.sprite = newBody.pelvis.sprite;
            wristLeft.sprite = newBody.wristLeft.sprite;
            wristRight.sprite = newBody.wristRight.sprite;
            elbowLeft.sprite = newBody.elbowLeft.sprite;
            elbowRight.sprite = newBody.elbowRight.sprite;
            shoulderLeft.sprite = newBody.shoulderLeft.sprite;
            shoulderRight.sprite = newBody.shoulderRight.sprite;
            weaponLeft.sprite = newBody.weaponLeft.sprite;
            weaponRight.sprite = newBody.weaponRight.sprite;
            bootLeft.sprite = newBody.bootLeft.sprite;
            bootRight.sprite = newBody.bootRight.sprite;
            legLeft.sprite = newBody.legLeft.sprite;
            legRight.sprite = newBody.legRight.sprite;
        }
    }
}
