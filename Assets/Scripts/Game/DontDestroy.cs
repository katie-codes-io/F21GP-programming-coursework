using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    //=========================================================//
    // Declare private variables
    private AudioSource audioSource;
    static bool firstTime = true;

    //=========================================================//
    // Declare lifecycle methods
    void Awake()
    {
        // Get the audio source
        audioSource = GetComponent<AudioSource>();

        // Only play the music on the first scene load
        if (firstTime) {
            audioSource.Play();
            DontDestroyOnLoad(audioSource);
            firstTime = false;

        } else {
            // Make sure we don't start playing the music again
            Destroy(audioSource);
        }
    }
}
