using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusicTrigger : MonoBehaviour {

    public AudioSource SoundSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            SoundSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundSource.Stop();
        }
    }
}