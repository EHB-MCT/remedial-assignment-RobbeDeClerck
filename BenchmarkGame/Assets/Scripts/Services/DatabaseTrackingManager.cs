using UnityEngine;

public class DataTrackingManager : MonoBehaviour
{
    public static DataTrackingManager Instance { get; private set; }

    [Header("User Info")]
    public UserData currentUser;

    private const string USER_KEY = "user_data";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadOrCreateUser();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadOrCreateUser()
    {
        if (PlayerPrefs.HasKey(USER_KEY))
        {
            string json = PlayerPrefs.GetString(USER_KEY);
            currentUser = JsonUtility.FromJson<UserData>(json);
        }
        else
        {
            Debug.Log("No user profile found. Prompting for nickname...");
        }
    }

    public void SetNickname(string nickname)
    {
        if (string.IsNullOrEmpty(nickname))
        {
            nickname = "Anonymous";
        }

        currentUser = new UserData(nickname);
        string json = JsonUtility.ToJson(currentUser);
        PlayerPrefs.SetString(USER_KEY, json);
        PlayerPrefs.Save();

        Debug.Log($"New User Created: {nickname} ({currentUser.userId})");
    }

    public void TrackChallenge1(float reactionTime)
    {
        Challenge1Data data = new Challenge1Data(reactionTime, currentUser.nickname);
        DatabaseManager.Instance.SaveChallenge1(currentUser.userId, data);
    }

    public void TrackChallenge2(int attempts, float timeTaken)
    {
        Challenge2Data data = new Challenge2Data(attempts, timeTaken, currentUser.nickname);
        DatabaseManager.Instance.SaveChallenge2(currentUser.userId, data);
    }

    public void TrackChallenge3(int falseReports, float timeTaken)
    {
        Challenge3Data data = new Challenge3Data(falseReports, timeTaken, currentUser.nickname);
        DatabaseManager.Instance.SaveChallenge3(currentUser.userId, data);
    }
}
