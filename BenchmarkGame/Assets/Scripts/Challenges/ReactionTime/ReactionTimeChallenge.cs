using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Challenge 1: Reaction Time test.
/// After a certain delay, the player's screen will turn from red to green and it is required to react in time.
/// </summary>
public class ReactionTimeChallenge : ChallengeBase
{
    [Header("UI")]
    [SerializeField] private Image screenColorOverlay;
    [SerializeField] private TextMeshProUGUI resultText;

    [Header("Timing")]
    [SerializeField] private float minWaitTime = 2f;
    [SerializeField] private float maxWaitTime = 5f;

    [Header("Managers")]
    [SerializeField] private AnnouncerManager announcer;
    [SerializeField] private GameFlowManager gameFlowManager;

    private bool canPress;
    private float startTime;
    private float reactionTime;

    void Start()
    {
        screenColorOverlay.gameObject.SetActive(false);
    }

    public override IEnumerator StartChallenge()
    {
        // Play intro explanation voiceline
        announcer.PlayClipByIndex(1);

        // Wait until the voiceline finishes playing
        yield return new WaitUntil(() => !announcer.IsPlaying());

        // Under normal circumstances, we run the challenge through here, but since this challenge is specificially triggered through stepping on a plate, it is defined in ReactionTimeTrigger.
        // yield return RunReactionTest();
    }

    public IEnumerator RunReactionTest()
    {
        screenColorOverlay.color = Color.red;
        screenColorOverlay.gameObject.SetActive(true);

        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

        screenColorOverlay.color = Color.green;
        startTime = Time.time;
        canPress = true;
    }

    private void Update()
    {
        if (!canPress) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            canPress = false;
            reactionTime = Time.time - startTime;
            screenColorOverlay.gameObject.SetActive(false);
            resultText.text = $"Reaction Time: {reactionTime:F3} seconds";

            DataTrackingManager.Instance.TrackChallenge1(reactionTime);
            PointsManager.Instance.AddPoints(10);
            announcer.PlayClipByIndex(2); // “Challenge complete...”

            StartCoroutine(gameFlowManager.TransitionToChallenge(1));
        }
    }
}
