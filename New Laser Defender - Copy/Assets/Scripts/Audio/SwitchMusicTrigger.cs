using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{

    public AudioClip newTrack;

    private AudioPlayer newAM;

    void Start()
    {
        newAM = FindObjectOfType<AudioPlayer>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (newTrack != null)
                newAM.ChangeBGM(newTrack);
        }
    }
}
