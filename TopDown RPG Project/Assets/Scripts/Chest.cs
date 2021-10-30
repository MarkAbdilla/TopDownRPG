using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectible
{
    [SerializeField] Sprite emptyChest;
    [SerializeField] int coinAmount = 10;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Grant " + coinAmount + " coints." );
        }
        collected = true;
        Debug.Log("Grant coins");
    }
}
