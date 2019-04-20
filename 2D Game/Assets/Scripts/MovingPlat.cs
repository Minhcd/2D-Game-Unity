using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public float speed = 0.05f, changeDirection = -1;
    public PausedMenu pause_tmp;
    Vector3 Move;
    // Start is called before the first frame update
    void Start()
    {
        Move = this.transform.position; 

        pause_tmp = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PausedMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pause_tmp.pause)
        {
            this.transform.position = this.transform.position;
        }
        if (pause_tmp.pause == false)
        {
            Move.x += speed;
            this.transform.position = Move;
        } 
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            speed *= changeDirection;
        }
    }
}
