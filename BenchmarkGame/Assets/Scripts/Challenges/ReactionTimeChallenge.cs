using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class ReactionTimeChallenge : MonoBehaviour
{
    [Header("UI")]
    public Image screenColorOverlay;
    public TextMeshProUGUI resultText;

    [Header("Timing")]
    public float minWaitTime = 2f;
    public float maxWaitTime = 5f;

    private bool testRunning = false;
    private bool canPress = false;
    private float startTime;
    private float reactionTime;

    [Header("Next Challenge")]
    public AnnouncerManager announcer;
    public ScreenFadeManager fadeManager;
    public GameFlowManager gameFlowManager;
    public float delayBeforeNextChallenge = 2f;

    private void Start()
    {
        screenColorOverlay.gameObject.SetActive(false);
    }

    public void StartReactionTest()
    {
        if (testRunning) return;

        StartCoroutine(RunReactionTest());
    }

    private IEnumerator RunReactionTest()
    {
        testRunning = true;

        screenColorOverlay.color = Color.red;
        screenColorOverlay.gameObject.SetActive(true);

        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        screenColorOverlay.color = Color.green;
        startTime = Time.time;
        canPress = true;
    }

    private void Update()
    {
        if (!canPress) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            reactionTime = Time.time - startTime;
            canPress = false;
            screenColorOverlay.gameObject.SetActive(false);
            resultText.text = $"Reaction Time: {reactionTime:F3} seconds";
            Invoke(nameof(ResetTest), 2f);
        }
    }

    private void ResetTest()
    {
        testRunning = false;

        DataTrackingManager.Instance.TrackChallenge1(reactionTime);

        // Play announcer clip (adjust index as needed)
        announcer.PlayClipByIndex(2); // “Challenge complete. Proceeding to next test.”

        // Start transition after delay
        StartCoroutine(gameFlowManager.TransitionToChallenge2());
    }
}
