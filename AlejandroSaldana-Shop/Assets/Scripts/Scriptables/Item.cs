using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Item")]
    public class Item : ScriptableObject
    {
        public enum BodyPart
        {
            Face, Hood, Torso, Pelvis, Wrist, Weapon, Elbow, Shoulder, Boot, Leg
        }
        
        public string itemName;
        public Sprite itemSprite; // main or left part
        public Sprite itemSprite2; //right part if it has one
        public BodyPart bodyPartType;

    }
}
