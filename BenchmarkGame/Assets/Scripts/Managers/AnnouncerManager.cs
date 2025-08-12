using UnityEngine;

public class AnnouncerManager : MonoBehaviour
{
    [Header("Audio Setup")]
    public AudioSource audioSource;

    [Header("General Announcer Clips")]
    public AudioClip[] announcerClips; // General voicelines like instructions, etc.

    [Header("Digit Clips (0-9)")]
    public AudioClip[] numberClips; // Must be exactly 10 clips for digits 0–9

    public void PlayClipByIndex(int index)
    {
        if (index >= 0 && index < announcerClips.Length)
        {
            audioSource.clip = announcerClips[index];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning($"AnnouncerManager: Invalid announcer clip index {index}.");
        }
    }

    public void PlayClip(AudioClip clip)
    {
        if (clip == null) return;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayClipByNumber(int number)
    {
        if (number < 0 || number > 9)
        {
            Debug.LogWarning($"AnnouncerManager: Invalid digit {number}. Must be between 0 and 9.");
            return;
        }

        if (numberClips.Length != 10)
        {
            Debug.LogError("AnnouncerManager: numberClips must contain exactly 10 clips (0-9).");
            return;
        }

        audioSource.clip = numberClips[number];
        audioSource.Play();
    }

    public float GetClipLength(int index)
    {
        if (index >= 0 && index < announcerClips.Length && announcerClips[index] != null)
        {
            return announcerClips[index].length;
        }

        Debug.LogWarning($"AnnouncerManager: Invalid or null clip at index {index}.");
        return 0f;
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }
}
