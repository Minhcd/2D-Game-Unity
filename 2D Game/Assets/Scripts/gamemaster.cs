using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemaster : MonoBehaviour
{
    public int points = 0, highscore = 0;
    public Text pointtext, Hightext, Inputtext;
 
    // Start is called before the first frame update
    void Start()
    {
        Hightext.text = ("High score: " + PlayerPrefs.GetInt("highscore"));
        highscore = PlayerPrefs.GetInt("highscore", 0);

        if (PlayerPrefs.HasKey("points"))
        {
            Scene ActiveScreen = SceneManager.GetActiveScene();
            if (ActiveScreen.buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("points");
                points = 0;
            }
            else
                points = PlayerPrefs.GetInt("points");
        }
    }

    // Update is called once per frame
    void Update()
    {
        pointtext.text = ("Points: " + points);
    }
}
