using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Player player;
    public MovingPlat mov;
    public Vector3 movp;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
        mov = GameObject.FindGameObjectWithTag("MovingP").GetComponent<MovingPlat>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger == false || col.CompareTag("water"))
            player.grounded = true;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.isTrigger == false || col.CompareTag("water"))
            player.grounded = true;
        if (col.isTrigger == false && col.CompareTag("MovingP"))
        {
            movp = player.transform.position;
            movp.x += mov.speed * 1.3f;
            player.transform.position = movp;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.isTrigger == false || col.CompareTag("water"))
            player.grounded = false;
    }
}
