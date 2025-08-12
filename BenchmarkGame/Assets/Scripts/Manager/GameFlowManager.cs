using System.Collections;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance;
    public DifficultyPlate.Difficulty CurrentDifficulty { get; private set; }

    public Transform challenge1SpawnPoint;
    public Transform challenge2SpawnPoint;
    public Transform challenge3SpawnPoint;
    public ScreenFadeManager fadeManager;
    public AnnouncerManager announcer;
    [SerializeField] private SequenceRecallManager sequenceRecallManager;
    [SerializeField] private FindAnomalyManager anomalyManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        fadeManager.FadeIn(() =>
        {
            announcer.PlayClipByIndex(0); // “Please choose your difficulty...”
        });
    }

    public void SelectDifficulty(DifficultyPlate.Difficulty difficulty)
    {
        Debug.Log("Selected difficulty: " + difficulty);
        CurrentDifficulty = difficulty;

        StartCoroutine(TransitionToChallenge1());
    }

    private IEnumerator TransitionToChallenge1()
    {
        fadeManager.FadeOut();

        yield return new WaitForSeconds(fadeManager.fadeDuration + 0.2f);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
        }

        player.transform.position = challenge1SpawnPoint.position;

        if (cc != null)
        {
            cc.enabled = true;
        }
        fadeManager.FadeIn(() =>
        {
            announcer.PlayClipByIndex(1); // “Challenge one: Reaction Time Test...”
        });
    }

    public IEnumerator TransitionToChallenge2()
    {
        fadeManager.FadeOut();

        yield return new WaitForSeconds(fadeManager.fadeDuration + 0.2f);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
        }

        player.transform.position = challenge2SpawnPoint.position;

        if (cc != null)
        {
            cc.enabled = true;
        }

        fadeManager.FadeIn(() =>
        {
            announcer.PlayClipByIndex(3); // “Challenge 2: Audio Memory...”
            StartCoroutine(StartSequenceRecallAfterIntro());
        });

        yield return null;
    }

    private IEnumerator StartSequenceRecallAfterIntro()
    {
        yield return new WaitUntil(() => !announcer.IsPlaying());
        yield return new WaitForSeconds(0.2f); // Optional small buffer
        sequenceRecallManager.StartChallenge();
    }


    public IEnumerator TransitionToChallenge3()
    {
        fadeManager.FadeOut();

        yield return new WaitForSeconds(fadeManager.fadeDuration + 0.2f);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null)
            cc.enabled = false;

        player.transform.position = challenge3SpawnPoint.position;

        if (cc != null)
            cc.enabled = true;

        fadeManager.FadeIn(() =>
        {
            anomalyManager.StartChallenge();
        });

        yield return null;
    }
}
