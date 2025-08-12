using UnityEngine;

/// <summary>
/// Plate that sets difficulty when the player steps on it.
/// </summary>
public class DifficultyPlate : MonoBehaviour
{
    public enum Difficulty { Regular, Hard }
    [SerializeField] private Difficulty plateDifficulty;
    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;
        triggered = true;

        GameFlowManager.Instance.SelectDifficulty(plateDifficulty);
    }
}
