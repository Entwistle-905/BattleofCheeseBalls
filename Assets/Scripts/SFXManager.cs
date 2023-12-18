using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance = null;
    private AudioSource AS_SFX;

    public AudioClip PunchSFX;
    public AudioClip DeadSFX;

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

        AS_SFX = GetComponent<AudioSource>();
    }


    private void Update()
    {

    }

    public void PlayPunchSFX()
    {
        AS_SFX.clip = PunchSFX;
        AS_SFX.Play();
    }

    public void PlayDeadSFX()
    {
        AS_SFX.clip = DeadSFX;
        AS_SFX.Play();
    }

}
