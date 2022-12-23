using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class AudioClipRandomizer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }
}
