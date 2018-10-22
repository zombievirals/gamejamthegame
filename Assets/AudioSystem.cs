using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSystem : MonoBehaviour
{
    public static AudioSystem Main;
    public AudioClip[] BlockDistEnemyDeath;
    public AudioClip[] BlockDistBulletShoot;

    public AudioClip[] CodeTraceTypeLetter;
    public AudioClip[] CodeTraceMissLetter;
    public AudioClip[] CodeTraceFinishWord;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        Main = this;
    }

    public void PlayBlockDistEnemyDeath()
    {
        _audioSource.PlayOneShot(BlockDistEnemyDeath[Random.Range(0, BlockDistEnemyDeath.Length - 1)]);
    }
    
    public void PlayBlockDistBulletShoot()
    {
        _audioSource.PlayOneShot(BlockDistBulletShoot[Random.Range(0, BlockDistBulletShoot.Length - 1)]);
    }
    
    public void PlayCodeTraceTypeLetter()
    {
        _audioSource.PlayOneShot(CodeTraceTypeLetter[Random.Range(0, CodeTraceTypeLetter.Length - 1)]);
    }
    
    public void PlayCodeTraceMissLetter()
    {
        _audioSource.PlayOneShot(CodeTraceMissLetter[Random.Range(0, CodeTraceMissLetter.Length - 1)]);
    }
    
    public void PlayCodeTraceFinishWord()
    {
        _audioSource.PlayOneShot(CodeTraceFinishWord[Random.Range(0, CodeTraceFinishWord.Length - 1)]);
    }
}