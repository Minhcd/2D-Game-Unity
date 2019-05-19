using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int Levelload = 1;
    public gamemaster gm;
    public string text = "Press E to enter";
    public bool enter = false;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            savescore();
            gm.Inputtext.text = (text);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player")) 
        {
            if (Input.GetKeyDown(KeyCode.E) || enter == true)
            {
                enter = false;
                savescore();
                SceneManager.LoadScene(Levelload);
            }
        }
    }

    public void DoorCheck(bool inp)
    {
        enter = inp;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            gm.Inputtext.text = "";
    }

    void savescore()
    {
        PlayerPrefs.SetInt("points", gm.points);
    }
}
