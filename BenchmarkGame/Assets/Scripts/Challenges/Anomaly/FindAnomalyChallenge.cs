using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Challenge 3: Player must find and report the anomaly.
/// </summary>
public class FindAnomalyChallenge : ChallengeBase
{
    [Header("Settings")]
    [SerializeField] private float interactionRange = 3f;
    [SerializeField] private KeyCode interactionKey = KeyCode.F;

    [Header("References")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private AnnouncerManager announcer;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private Transform challengeFinishedPoint;
    [SerializeField] private UI_ScreenFadeManager fadeManager;

    private bool challengeActive = false;
    private bool inputLocked = false;

    // Tracking
    private float startTime;
    private int incorrectReports = 0;

    public override IEnumerator StartChallenge()
    {
        challengeActive = true;
        announcer.PlayClipByIndex(7); // “An anomaly has appeared. Find it and report it.”
        startTime = Time.time;
        yield break;
    }

    private void Update()
    {
        if (!challengeActive || inputLocked) return;

        if (Input.GetKeyDown(interactionKey))
        {
            TryDetectAnomaly();
        }
    }

    private void TryDetectAnomaly()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange))
        {
            if (hit.collider.GetComponent<AnomalyTarget>())
            {
                StartCoroutine(HandleSuccess());
            }
            else
            {
                incorrectReports++;
                Debug.Log("Incorrect object reported.");
            }
        }
    }

    private IEnumerator HandleSuccess()
    {
        inputLocked = true;
        challengeActive = false;

        announcer.PlayClipByIndex(8); // “Correct. The anomaly has been identified.”
        float duration = Time.time - startTime;

        resultText.text = $"Incorrect Reports: {incorrectReports}\nTime: {duration:F1}s";
        DataTrackingManager.Instance.TrackChallenge3(incorrectReports, duration);
        PointsManager.Instance.AddPoints(30);

        yield return new WaitUntil(() => !announcer.IsPlaying());

        yield return TransitionToFinishPoint();
    }

    private IEnumerator TransitionToFinishPoint()
    {
        fadeManager.FadeOut();
        yield return new WaitForSeconds(fadeManager.fadeDuration + 0.5f);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        player.transform.position = challengeFinishedPoint.position;

        if (cc != null) cc.enabled = true;

        fadeManager.FadeIn();
    }
}
