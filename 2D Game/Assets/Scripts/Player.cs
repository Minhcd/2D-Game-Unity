using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float speed = 50f, maxspeed = 3, jumpPow = 220f;
    public bool grounded, doublejump = false, faceright = true;
    public int ourHealth, maxHealth = 5;
    private Rigidbody2D r2;
    private Animator anim;
    public gamemaster gm;
    public SoundManager sound;
    public float h = 0;
    public bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
        ourHealth = maxHealth;
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetButtonDown("Jump") || jump == true)
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);
                jump = false;
            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 1.2f);
                }
            }            
        }

    }

    public void Move(float inp)
    {
        h = inp;
    }

    public void Jumping(bool inp)
    {
        jump = inp; 
    }

    void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal");
        Move(h);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(-1);
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Move(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(1);
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Move(0);
            }
        }
        
        r2.AddForce(Vector2.right * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);     

        if (h > 0 && !faceright)
            Flip();
        if (h < 0 && faceright)
            Flip();

        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }

        if (ourHealth <= 0)
        {
            Death();
        }    
    }

    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (PlayerPrefs.GetInt("highscore") < gm.points)
            PlayerPrefs.SetInt("highscore", gm.points);
    }
    public void Damage(int damage)
    {
        ourHealth -= damage;
        gameObject.GetComponent<Animation>().Play("RedFlash");
    }
    public void Knockback(float Knockpow, Vector2 Knockdir)
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Knockdir.x * -300, Knockdir.y * Knockpow));
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coins"))
        {
            sound.Playsound("coins");
            Destroy(col.gameObject);
            gm.points += 1;
        }
    }
}
