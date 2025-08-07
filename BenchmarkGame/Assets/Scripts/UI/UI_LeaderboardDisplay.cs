using UnityEngine;
using TMPro;

public class UI_LeaderboardDisplay : MonoBehaviour
{
    public TextMeshProUGUI challenge1Text;
    public TextMeshProUGUI challenge2Text;
    public TextMeshProUGUI challenge3Text;

    private void Start()
    {
        LoadAllLeaderboards();
    }

    public void RefreshLeaderboards()
    {
        DatabaseManager.Instance.LoadLeaderboardFromUsers(1, text => challenge1Text.text = text);
        DatabaseManager.Instance.LoadLeaderboardFromUsers(2, text => challenge2Text.text = text);
        DatabaseManager.Instance.LoadLeaderboardFromUsers(3, text => challenge3Text.text = text);
    }

    public void LoadAllLeaderboards()
    {
        DatabaseManager.Instance.LoadLeaderboardFromUsers(1, (text) =>
        {
            challenge1Text.text = text;
        });

        DatabaseManager.Instance.LoadLeaderboardFromUsers(2, (text) =>
        {
            challenge2Text.text = text;
        });

        DatabaseManager.Instance.LoadLeaderboardFromUsers(3, (text) =>
        {
            challenge3Text.text = text;
        });
    }

}
