using UnityEngine;

public class SFX : MonoBehaviour
{
    public static SFX S;

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

    public void PlaySFX(int index)
    {
        au[auIdx].clip = clips[index];
        au[auIdx].Play();
        auIdx++;
        if (auIdx >= au.Length)
        {
            auIdx -= au.Length;
        }
    }
}