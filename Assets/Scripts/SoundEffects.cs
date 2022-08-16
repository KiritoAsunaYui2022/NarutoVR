using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class SoundEffects : MonoBehaviour
{
    public AudioSource soundEffect;

    public AudioClip handSealSound, jutsuSound, narutoRunningSound; 

    public void playHandSealSound()
    {
        soundEffect.clip = handSealSound;
        soundEffect.Play(); 
    }

    public void PlayJutsuSound()
    {
        soundEffect.clip = jutsuSound;
        soundEffect.Play(); 
    }

    public void PlayNarutoRunningSound()
    {
        soundEffect.clip = narutoRunningSound;
        soundEffect.Play(); 
    }

    //public void StopNarutoRunningSound()
    //{
    //    soundEffect.clip = narutoRunningSound;
    //    soundEffect.Stop(); 
    //}
}
