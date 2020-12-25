using UnityEngine;

class Explosion : MonoBehaviour
{
    public bool m_isBig = false;

    public AudioClip[] audioClips = new AudioClip[2];

    AudioSource audioSource;
    Animator animator;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {


    }

    public void StartExplosion(bool isBig)
    {
        m_isBig = isBig;

        audioSource.clip = (m_isBig) ? audioClips[1] : audioClips[0];

        animator.SetBool("isBig", m_isBig);

        audioSource.Play();
    }
}