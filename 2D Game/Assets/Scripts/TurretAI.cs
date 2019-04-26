using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public int curHealth = 100;
    public float distance, wakerange, shootinterval, bulletspeed = 5, bullettimer;
    public bool awake = false, lookingRight = true;
    public GameObject bullet;
    public Transform target, shootpointL, shootpointR;
    public Animator anim;
    public gamemaster gm;
    public SoundManager sound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookRight", lookingRight);

        RangeCheck();

        if (target.transform.position.x > this.transform.position.x)
        {
            lookingRight = true;
        }
        if (target.transform.position.x < this.transform.position.x)
        {
            lookingRight = false;
        }
        if (curHealth <= 0)
        {
            sound.Playsound("destroy");
            Destroy(gameObject);
            gm.points += 3;
        }
    }

    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < wakerange)
        {
            awake = true;
        }
        if (distance > wakerange)
        {
            awake = false;
        }
    }

    public void Attack(bool attackright)
    {
        bullettimer += Time.deltaTime;
        if (bullettimer > shootinterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            if (attackright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootpointR.transform.position, shootpointR.transform.rotation);
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                bullettimer = 0;    
            }

            if (!attackright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootpointL.transform.position, shootpointL.transform.rotation);
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                bullettimer = 0;
            }
        }
    }
    public void Damage(int dmg)
    {
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("RedFlash");
    }
}
