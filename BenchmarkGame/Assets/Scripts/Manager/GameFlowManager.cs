using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance { get; private set; }
    public DifficultyPlate.Difficulty CurrentDifficulty { get; private set; }

    [Header("Spawns")]
    [Tooltip("Every challenge has a spawn point where the player teleports to. Add this into the list!")]

    [SerializeField] private Transform[] challengeSpawnPoints;

    [Header("Managers")]
    [SerializeField] private ScreenFadeManager fadeManager;
    [SerializeField] private AnnouncerManager announcer;

    [Header("Challenges")]
    [Tooltip("To add a challenge, add it into the inspector list of current challenges!")]
    [SerializeField] private ChallengeBase[] challenges;

    private PlayerTeleportService teleportService;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        teleportService = new PlayerTeleportService();
    }

    private void Start()
    {
        fadeManager.FadeIn(() => announcer.PlayClipByIndex(0)); // “Choose difficulty”
    }

    public void SelectDifficulty(DifficultyPlate.Difficulty difficulty)
    {
        CurrentDifficulty = difficulty;
        StartCoroutine(TransitionToChallenge(0)); // Teleport only
    }

    /// <summary>
    /// Teleports the player and starts the challenge (for challenges after the first).
    /// </summary>
    public IEnumerator TransitionToChallenge(int challengeIndex)
    {
        fadeManager.FadeOut();
        yield return new WaitForSeconds(fadeManager.fadeDuration + 0.2f);

        teleportService.TeleportPlayer(challengeSpawnPoints[challengeIndex]);

        fadeManager.FadeIn(() =>
        {
            StartCoroutine(challenges[challengeIndex].StartChallenge());
        });
    }

    /// <summary>
    /// Teleports the player without starting the challenge (used for Challenge 1).
    /// </summary>
    public IEnumerator TransitionToChallengeSpawnOnly(int challengeIndex)
    {
        fadeManager.FadeOut();
        yield return new WaitForSeconds(fadeManager.fadeDuration + 0.2f);

        teleportService.TeleportPlayer(challengeSpawnPoints[challengeIndex]);

        fadeManager.FadeIn(); // Challenge 1 will be triggered by the plate
    }
}
