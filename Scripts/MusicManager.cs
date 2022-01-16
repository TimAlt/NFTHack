using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource track1;
    public AudioSource track2;
    private bool track1IsPlaying;
    private bool track2IsPlaying;
    // Start is called before the first frame update
    void Start()
    {
        track2IsPlaying = false;
        track1IsPlaying = true;
        track1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (track1.time >= 25.822f && track1IsPlaying == true)
        {
            track1IsPlaying = false;
            track2IsPlaying = true;
            track2.Play();
        }
        else if (track2.time >= 25.822f && track2IsPlaying == true)
        {
            track1IsPlaying = true;
            track2IsPlaying = false;
            track1.Play();
        }
    }
}
