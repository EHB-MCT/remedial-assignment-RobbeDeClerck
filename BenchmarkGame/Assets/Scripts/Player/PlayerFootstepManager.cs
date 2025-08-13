using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepManager : MonoBehaviour
{
    [Header("Footstep Settings")]
    public AudioSource audioSource;
    public AudioClip[] footstepClips;
    public float baseStepRate = 0.5f;
    public float runStepMultiplier = 0.6f; // smaller = faster steps

    private float stepTimer;
    private float currentStepRate;
    private int lastClipIndex = -1;


    public void HandleFootsteps(bool isMoving, bool isRunning)
    {
        if (!isMoving || footstepClips.Length == 0 || !audioSource) return;

        currentStepRate = isRunning ? baseStepRate * runStepMultiplier : baseStepRate;

        stepTimer -= Time.deltaTime;
        if (stepTimer <= 0f)
        {
            PlayFootstep();
            stepTimer = currentStepRate;
        }
    }

    private void PlayFootstep()
    {
        int newIndex;

        // Prevent playing the same clip twice
        if (footstepClips.Length == 1)
        {
            newIndex = 0;
        }
        else
        {
            do
            {
                newIndex = Random.Range(0, footstepClips.Length);
            } while (newIndex == lastClipIndex);
        }

        lastClipIndex = newIndex;
        audioSource.PlayOneShot(footstepClips[newIndex]);
    }

    public void ResetStepCycle()
    {
        stepTimer = 0f;
    }
}
