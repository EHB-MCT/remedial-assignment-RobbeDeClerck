using System.Collections;
using UnityEngine;

public interface IChallenge
{
    IEnumerator StartChallenge();
}

public abstract class ChallengeBase : MonoBehaviour, IChallenge
{
    public abstract IEnumerator StartChallenge();
}
