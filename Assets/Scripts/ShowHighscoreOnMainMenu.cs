using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighscoreOnMainMenu : MonoBehaviour
{
    public Text scormare;

    // Start is called before the first frame update
    void Start()
    {
        float scor = PlayerPrefs.GetFloat("highscore", 0);
        scormare.text = ("HIGHSCORE " + scor.ToString("0") + "!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
