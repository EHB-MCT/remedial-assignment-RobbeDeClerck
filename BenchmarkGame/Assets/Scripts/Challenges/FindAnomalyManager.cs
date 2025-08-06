using System.Collections;
using TMPro;
using UnityEngine;

public class FindAnomalyManager : MonoBehaviour
{
    [Header("Settings")]
    public float interactionRange = 3f;
    public KeyCode interactionKey = KeyCode.F;

    [Header("References")]
    public Camera playerCamera;
    public AnnouncerManager announcer;
    public GameFlowManager gameFlowManager;
    public ScreenFadeManager fadeManager;
    public Transform challengeFinishedPoint;
    private bool challengeActive = false;
    private bool inputLocked = false;


    [Header("Data Tracking")]
    private float startTime;
    private int incorrectReports = 0;
    [SerializeField] private TMP_Text resultText;

    public void StartChallenge()
    {
        challengeActive = true;
        announcer.PlayClipByIndex(7); // "An anomaly has appeared. Find it and report it."
        startTime = Time.time;
    }

    void Update()
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
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            if (hit.collider.GetComponent<AnomalyTarget>())
            {
                StartCoroutine(HandleSuccess());
            }
            else
            {
                // Optional: feedback for incorrect object
                incorrectReports++;
                Debug.Log("That’s not the anomaly.");
            }
        }
    }

    private IEnumerator HandleSuccess()
    {
        inputLocked = true;
        announcer.PlayClipByIndex(8); // “Correct. The anomaly has been identified.”

        float duration = Time.time - startTime;
        resultText.text = $"Incorrect Reports: {incorrectReports}\nTime: {duration:F1}s";

        yield return new WaitUntil(() => !announcer.IsPlaying());

        // Finish the game or trigger next phase
        fadeManager.FadeOut();
        yield return new WaitForSeconds(fadeManager.fadeDuration + 0.5f);

        // Could show credits, restart, load main menu etc.
        Debug.Log("Challenge complete. Game ending or transitioning...");
        // TODO: Trigger your final event or scene here

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null)
            cc.enabled = false;

        player.transform.position = challengeFinishedPoint.position;

        if (cc != null)
        {
            cc.enabled = true;
        }

        fadeManager.FadeIn();
    }
}
