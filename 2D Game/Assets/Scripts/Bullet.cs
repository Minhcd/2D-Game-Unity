﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player player;
    public float lifetime = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger == false)
        {
            if (col.CompareTag("Player"))
            {
                col.SendMessageUpwards("Damage", 1);
            }
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
