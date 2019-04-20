using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int Health = 100;
    void Update()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
    void Damage(int dmg)
    {
        Health -= dmg;
    }
}
