using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudio : MonoBehaviour
{
    public AudioClip[] clipsToPlay;
    public float minRandomTime;
    public float maxRandomTime;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(WaitToPlayAudio());
    }

    IEnumerator WaitToPlayAudio()
    {
        while (true) {
            audioSource.clip = clipsToPlay[Random.Range(0, clipsToPlay.Length)];
            audioSource.Play();
            while (audioSource.isPlaying) {
                yield return null;
            }
            yield return new WaitForSeconds(Random.Range(minRandomTime, maxRandomTime));
        }
    }
}
