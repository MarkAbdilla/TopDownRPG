using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    [SerializeField] int xpValue = 1;
    [SerializeField] float triggerLength = 1.0f;
    [SerializeField] float chaseLength = 5.0f;

    bool isChasing;
    bool isCollidingWithPlayer;

    Transform playerTransform;
    Vector3 startingPosiiton;

    public ContactFilter2D filter;
    BoxCollider2D hitbox;
    Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosiiton = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        IsPlayerInRange();

        isCollidingWithPlayer = false;
        hitbox.OverlapCollider(filter, hits);
        for(int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            if(hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                isCollidingWithPlayer = true;
            }
            hits[i] = null;
        }

        UpdateMotor(Vector3.zero);
    }

    private void IsPlayerInRange()
    {
        if (Vector3.Distance(playerTransform.position, startingPosiiton) < chaseLength)
        {
            if(Vector3.Distance(playerTransform.position, startingPosiiton) < triggerLength)
            {
                isChasing = true;
            }

            if (isChasing)
            {
                if (!isCollidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
                else
                {
                    UpdateMotor(startingPosiiton - transform.position);
                }
            }
        }
        else
        {
            UpdateMotor(startingPosiiton - transform.position);
            isChasing = false;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.experiencePoints += xpValue;
        GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}
