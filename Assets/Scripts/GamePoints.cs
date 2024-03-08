using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePoints : MonoBehaviour
{
    public float time = 0;
    public bool freeze = false;
    public Text highScore;

    public bool highestScore;

    public Text points;
    // Start is called before the first frame update
    void Start()
    {
        highestScore = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!freeze) UpdatePoints();
    }

    
    private void UpdatePoints()
    {
        time += 1 * (Time.deltaTime * 8);
        if (time <= 9.5)
            points.text = ("000" + time.ToString("0"));
        else if (time <= 99.5)
            points.text = ("00" + time.ToString("0"));
        else if (time <= 999.5)
            points.text = ("0" + time.ToString("0"));
        else
            points.text = time.ToString("0");
    }
}
