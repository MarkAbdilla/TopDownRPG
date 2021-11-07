using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private  void Awake()
    {
        instance = this;
    }

    [SerializeField] List<Sprite> playerSprites;
    [SerializeField] List<Sprite> weaponSprites;
    [SerializeField] List<int> weaponPrices;
    [SerializeField] List <int> xpTable;

    [SerializeField] Player player;

    [SerializeField] int goldCoins;
    [SerializeField] int experiencePoints;

    public void SaveState()
    {

    }

    public void LoadState()
    {
        
    }
}
