using System.Collections;
using System.Collections.Generic;
using Scriptables;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int currentCoins;
    public List<Item> ownedHoods = new List<Item>();
    public List<Item> ownedFaces = new List<Item>();
    public List<Item> ownedShoulders = new List<Item>();
    public List<Item> ownedElbows = new List<Item>();
    public List<Item> ownedWrists = new List<Item>();
    public List<Item> ownedTorso = new List<Item>();
    public List<Item> ownedPelvis = new List<Item>();
    public List<Item> ownedLeg = new List<Item>();
    public List<Item> ownedBoot = new List<Item>();
    public List<Item> ownedWeapon = new List<Item>();

    [Space]
    public Item currentHood;
    public Item currentFace;
    public Item currentShoulder;
    public Item currentElbow;
    public Item currentWrist;
    public Item currentTorso;
    public Item currentPelvis;
    public Item currentLeg;
    public Item currentBoot;
    public Item currentWeapon;
}
