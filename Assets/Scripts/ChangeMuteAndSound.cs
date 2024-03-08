using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChangeMuteAndSound : MonoBehaviour
{
    public Sprite newButtonImage, oldButtonImage;
    public Button button;
    private int currentSceneIndex;
    // Start is called before the first frame update
    public bool isMuted = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MutePressed()
    {
        if (isMuted)
        {
            button.image.sprite = newButtonImage;
            AudioListener.pause = true;
            isMuted = false;
        }
        else if (!isMuted)
        {
            button.image.sprite = oldButtonImage;
            AudioListener.pause = false;
            isMuted = true;

        }
        //PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
    }
}
