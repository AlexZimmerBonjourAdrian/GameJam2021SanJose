using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip MusicMenu;

    [SerializeField]
    private AudioSource SoundSource;
    [SerializeField]
    private AudioClip PlayMusicGame;
    [SerializeField]
    private AudioSource[] ListSoundWeapon;
    [SerializeField]
    private AudioSource[] InsectAudio;


    private void Awake()
    {
        SoundSource = GetComponent<AudioSource>();


    }




    private void PlayMusic()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneAt(0))
        {
            SoundSource.Stop();
            SoundSource.clip = MusicMenu;
            SoundSource.Play();

        }

        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneAt(1))
        {
            SoundSource.Stop();
            SoundSource.clip = PlayMusicGame;
            SoundSource.Play();
        }
    }

    public void PlaySoundShootRandom()
    {

        
        
    }


}

