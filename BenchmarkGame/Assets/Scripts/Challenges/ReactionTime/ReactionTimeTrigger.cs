using UnityEngine;

public class ReactionTimeTrigger : MonoBehaviour
{
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;

            ReactionTimeChallenge manager = FindObjectOfType<ReactionTimeChallenge>();
            if (manager != null)
            {
                StartCoroutine(manager.RunReactionTest());
            }
        }
    }
}
