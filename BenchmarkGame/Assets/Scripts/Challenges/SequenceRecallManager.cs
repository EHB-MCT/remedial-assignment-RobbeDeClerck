using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SequenceRecallManager : MonoBehaviour
{
    [Header("Settings")]
    public int sequenceLength = 4;
    public float timeBetweenNumbers = 1.2f;

    [Header("References")]
    public AnnouncerManager announcer;
    public ScreenFadeManager fadeManager;
    public GameFlowManager gameFlowManager;
    public TMP_Text feedbackText;

    private List<int> numberSequence = new List<int>();
    private string playerInput = "";
    private bool inputAllowed = false;

    [Header("Data Tracking")]
    private float challengeStartTime;
    private int failedAttempts = 0;
    [SerializeField] private TMP_Text resultText;

    public void StartChallenge()
    {
        ApplyDifficultySettings();
        StartCoroutine(RunChallenge());
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
        // Announcer intro
        announcer.PlayClipByIndex(4); // "Listen carefully..."
        yield return new WaitForSeconds(announcer.GetClipLength(3) + 0.5f);

        GenerateSequence();

        // Play each number via announcer
        for (int i = 0; i < numberSequence.Count; i++)
        {
            int number = numberSequence[i];
            announcer.PlayClipByNumber(number); // e.g., clip for "4"
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
            numberSequence.Add(Random.Range(0, 10)); // Digits 0–9
            Debug.Log(numberSequence);
        }
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

            if (c == '\b' && playerInput.Length > 0) // backspace
            {
                playerInput = playerInput.Substring(0, playerInput.Length - 1);
                feedbackText.text = playerInput;
            }

            if (c == '\n' || c == '\r') // enter
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

            announcer.PlayClipByIndex(5); // “Correct. Proceeding to final test.”
            StartCoroutine(gameFlowManager.TransitionToChallenge3());
        }
        else
        {
            // announcer.PlayClipByIndex(6); // “Incorrect. Try again.”
            ResetChallenge();
        }
    }

    private void ResetChallenge()
    {
        playerInput = "";
        inputAllowed = false;
        failedAttempts++;
        StartCoroutine(RunChallenge());
    }


}
