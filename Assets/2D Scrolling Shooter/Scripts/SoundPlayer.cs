using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip explosionClip;
    
    [SerializeField] private AudioSource audioPlayer;
    
    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }
    
    public void PlayShootSound()
    {
        audioPlayer.clip = shootClip;
        audioPlayer.Play();
    }

    public void PlayExplosionSound()
    {
        audioPlayer.clip = explosionClip;
        audioPlayer.Play();
    }
}
