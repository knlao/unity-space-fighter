using UnityEngine;

public class NukeSFX : MonoBehaviour
{
    public static NukeSFX S;

    private void Awake()
    {
        if (S == null)
            S = this;
        else if (S != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public AudioClip[] clips;
    AudioSource[] au;
    
    int auIdx = 0;

    void Start()
    {
        au = GetComponents<AudioSource>();
    }

    public void PlaySFX()
    {
        au[auIdx].clip = clips[0];
        au[auIdx].Play();
        auIdx++;
        if (auIdx >= au.Length)
        {
            auIdx -= au.Length;
        }
    }
}