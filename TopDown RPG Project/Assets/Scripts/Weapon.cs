using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    [SerializeField] int damagePoints = 1;
    [SerializeField] float pushForce = 2.0f;
    [SerializeField] int weaponLevel = 0;

    private float coolDown = 0.5f;
    private float lastSwing;

    private SpriteRenderer sprinteRenderer;

    protected override void Start()
    {
        base.Start();
        sprinteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > coolDown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.tag == "Fighter")
        {
            if (collider.name == "Player")
            {
                return;
            }
            else
            {
                Debug.Log(collider.name);
            }
        }
    }

    private void Swing()
    {
        Debug.Log("Weapon swung");
    }
}
