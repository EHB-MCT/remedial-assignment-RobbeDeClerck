using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Challenge 2: Sequence Recall memory test.
/// Plays a sequence of numbers via announcer, then waits for player input.
/// </summary>
public class SequenceRecallChallenge : ChallengeBase
{
    [Header("Settings")]
    [SerializeField] private int sequenceLength = 4;
    [SerializeField] private float timeBetweenNumbers = 1.2f;

    [Header("References")]
    [SerializeField] private AnnouncerManager announcer;
    [SerializeField] private TMP_Text feedbackText;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private GameFlowManager gameFlowManager;

    private List<int> numberSequence = new List<int>();
    private string playerInput = "";
    private bool inputAllowed = false;

    // Tracking
    private float challengeStartTime;
    private int failedAttempts = 0;

    public override IEnumerator StartChallenge()
    {
        // Play intro explanation voiceline
        announcer.PlayClipByIndex(3);

        // Wait until the voiceline finishes playing
        yield return new WaitUntil(() => !announcer.IsPlaying());

        ApplyDifficultySettings();
        yield return RunChallenge();
    }

    private void ApplyDifficultySettings()
    {
        var diff = GameFlowManager.Instance.CurrentDifficulty;

        if (diff == DifficultyPlate.Difficulty.Hard)
        {
            sequenceLength = 6;
            timeBetweenNumbers = 1.0f;
        }
        else
        {
            sequenceLength = 4;
            timeBetweenNumbers = 1.2f;
        }
    }

    private IEnumerator RunChallenge()
    {
        announcer.PlayClipByIndex(4); // “Listen carefully…”
        yield return new WaitForSeconds(announcer.GetClipLength(4) + 0.5f);

        GenerateSequence();

        // Play each number via announcer
        foreach (int number in numberSequence)
        {
            announcer.PlayClipByNumber(number);
            yield return new WaitForSeconds(timeBetweenNumbers);
        }

        inputAllowed = true;
        feedbackText.text = "Type the sequence and press Enter.";
        challengeStartTime = Time.time;
    }

    private void GenerateSequence()
    {
        numberSequence.Clear();
        for (int i = 0; i < sequenceLength; i++)
        {
            numberSequence.Add(Random.Range(0, 10)); // 0–9
        }
        Debug.Log($"Generated sequence: {string.Join("", numberSequence)}");
    }

    private void Update()
    {
        if (!inputAllowed) return;

        foreach (char c in Input.inputString)
        {
            if (char.IsDigit(c))
            {
                playerInput += c;
                feedbackText.text = playerInput;
            }
            else if (c == '\b' && playerInput.Length > 0) // backspace
            {
                playerInput = playerInput.Substring(0, playerInput.Length - 1);
                feedbackText.text = playerInput;
            }
            else if (c == '\n' || c == '\r') // enter
            {
                inputAllowed = false;
                CheckAnswer();
            }
        }
    }

    private void CheckAnswer()
    {
        string correct = string.Join("", numberSequence);
        if (playerInput == correct)
        {
            float duration = Time.time - challengeStartTime;
            resultText.text = $"Attempts: {failedAttempts + 1}\nTime: {duration:F1}s";

            DataTrackingManager.Instance.TrackChallenge2(failedAttempts, duration);
            PointsManager.Instance.AddPoints(15);

            announcer.PlayClipByIndex(5); // “Correct. Proceeding to final test.”
            StartCoroutine(gameFlowManager.TransitionToChallenge(2)); // Move to challenge 3
        }
        else
        {
            failedAttempts++;
            ResetChallenge();
        }
    }

    private void ResetChallenge()
    {
        playerInput = "";
        inputAllowed = false;
        StartCoroutine(RunChallenge());
    }
}
