using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Store;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set;}

    public Inventory Inventory { get; private set; }
    public PlayerController Player { get; private set; }
    public PlayerBodyParts PlayerBodyParts { get; private set; }
    public StoreManager StoreManager { get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        Inventory = GetComponentInChildren<Inventory>();
        Player = FindObjectOfType<PlayerController>();
        PlayerBodyParts = Player.GetComponent<PlayerBodyParts>();
        StoreManager = GetComponentInChildren<StoreManager>(true);

    }
}
