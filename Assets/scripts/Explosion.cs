using UnityEngine;

class Explosion : MonoBehaviour
{
    public bool isBig = false;

    public AudioClip[] audioClips = new AudioClip[2];

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        audioSource.clip = (isBig) ? audioClips[1] : audioClips[0];
        audioSource.Play();
    }
}