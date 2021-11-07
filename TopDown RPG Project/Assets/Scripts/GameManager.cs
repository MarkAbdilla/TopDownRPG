using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private  void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
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
        Debug.Log("Saving");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        Debug.Log("Loading");
    }
}
