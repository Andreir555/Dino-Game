using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public  AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playSound()
    {
        jumpSound.Play();
    }
}
