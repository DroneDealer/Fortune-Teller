using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundEffect;

    void Start()
    {
        audioSource.Play();
        if (audioSource == null)
        {
            audioSource.GetComponent<AudioSource>();
        }
    }

    public void playSound()
    {
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
    }
}
