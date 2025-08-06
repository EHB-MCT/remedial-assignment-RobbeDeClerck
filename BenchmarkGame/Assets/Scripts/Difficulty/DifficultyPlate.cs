using UnityEngine;

public class DifficultyPlate : MonoBehaviour
{
    public enum Difficulty { Regular, Hard }
    public Difficulty plateDifficulty;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;
        triggered = true;

        GameFlowManager.Instance.SelectDifficulty(plateDifficulty);
    }
}
