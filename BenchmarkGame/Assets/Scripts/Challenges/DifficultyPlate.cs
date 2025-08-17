using UnityEngine;
using TMPro;

/// <summary>
/// Plate that sets difficulty when the player steps on it.
/// Shows UI if Hard difficulty is still locked.
/// </summary>
public class DifficultyPlate : MonoBehaviour
{
    public enum Difficulty { Regular, Hard }
    public Difficulty plateDifficulty;

    public int unlockCost = 50;

    private bool triggered = false;

    [Header("UI References")]
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI statusText;

    private int lastPoints = -1;

    private void Update()
    {
        if (PointsManager.Instance == null) return;

        int currentPoints = PointsManager.Instance.data.points;

        if (currentPoints != lastPoints)
        {
            lastPoints = currentPoints;
            pointsText.text = "Points: " + currentPoints;

            if (plateDifficulty == Difficulty.Hard)
            {
                if (currentPoints < unlockCost)
                {
                    statusText.text = "Hard difficulty locked (need " + (unlockCost - currentPoints) + " more)";
                }
                else
                {
                    statusText.text = "Hard difficulty unlocked!";
                }
            }
            else
            {
                statusText.text = "Hard mode has already been unlocked";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;

        int currentPoints = PointsManager.Instance.data.points;

        if (plateDifficulty == Difficulty.Hard && currentPoints < unlockCost)
        {
            Debug.Log("Hard difficulty locked. Earn " + unlockCost + " points to unlock!");
            return;
        }

        triggered = true;
        GameFlowManager.Instance.SelectDifficulty(plateDifficulty);
    }
}
