using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioSource audioSource;
    bool canPlayAudio = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAudio(WeaponSO weaponSO)
    {
        if (canPlayAudio)
        {
            audioSource.PlayOneShot(weaponSO.audioClip);
            canPlayAudio = false;
            Invoke("ToggleCanPlayAudio", weaponSO.audioClip.length);
            return;
        }

    }
    void ToggleCanPlayAudio()
    {
        canPlayAudio = true;
    }

    private void OnDestroy()
    {

    }
}
