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
            GameManager.instance.ShowText("+" + coinAmount + " gold coins", 30, Color.red, transform.position, Vector3.up * 50, 1.5f);
        }
        collected = true;
        Debug.Log("Grant coins");
    }
}
