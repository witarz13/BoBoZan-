using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffect : MonoBehaviour
{
    public AudioSource zanSound;
    public AudioSource attackSound;
    public AudioSource huSound;
    public AudioSource paSound;
    public void zanAudio()
    {

        zanSound.Play();
        
    }
    public void PaAudio()
    {

        paSound.Play();

    }
    public void HuAudio()
    {

        huSound.Play();

    }
    public void DoAudio()
    {

        attackSound.Play();

    }
}
