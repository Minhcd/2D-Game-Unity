using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking;
    public Animator anim;
    public Collider2D trigger;
    public SoundManager sound;
    public bool attack = false; 

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Z) || attack == true )&& !attacking)
        {
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
            sound.Playsound("swords");
            attack = false;
        }
        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("Attacking", attacking);
    }

    public void Attack(bool inp)
    {
        attack = inp;
    }
}
