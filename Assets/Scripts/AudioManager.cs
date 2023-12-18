using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;
    private AudioSource BackGroundMusic;

    public AudioClip Lobby;
    public AudioClip BattleScene;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        BackGroundMusic = GetComponent<AudioSource>();
        PlayLobbyMusic();
    }


    public void PlayLobbyMusic()
    {
        if (BackGroundMusic.isPlaying)
        {
            BackGroundMusic.Stop();
        }
        BackGroundMusic.clip = Lobby;
        BackGroundMusic.Play();
    }

    public void PlayBattleMusic()
    {
        if (BackGroundMusic.isPlaying)
        {
            BackGroundMusic.Stop();
        }
        BackGroundMusic.clip = BattleScene;
        BackGroundMusic.Play();
    }
}
