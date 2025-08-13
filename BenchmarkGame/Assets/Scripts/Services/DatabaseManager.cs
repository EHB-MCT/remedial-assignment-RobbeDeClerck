using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance { get; private set; }

    private DatabaseReference dbReference;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeDatabase();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitializeDatabase()
    {
        FirebaseDatabase database = FirebaseDatabase.GetInstance("https://dev5-remedial-default-rtdb.europe-west1.firebasedatabase.app/");

        dbReference = database.RootReference;
    }
    public void SaveChallenge1(string userId, Challenge1Data data, Action onComplete = null)
    {
        string json = JsonUtility.ToJson(data);

        dbReference.Child("users").Child(userId).Child("challenges").Child("challenge1")
            .SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    UpdateChallenge1Leaderboard(userId, data);
                    onComplete?.Invoke();
                }
                else
                {
                    Debug.LogError($"SaveChallenge1 failed: {task.Exception}");
                }
            });
    }

    public void SaveChallenge2(string userId, Challenge2Data data, Action onComplete = null)
    {
        string json = JsonUtility.ToJson(data);

        dbReference.Child("users").Child(userId).Child("challenges").Child("challenge2")
            .SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    UpdateChallenge2Leaderboard(userId, data);
                    onComplete?.Invoke();
                }
                else
                {
                    Debug.LogError($"SaveChallenge2 failed: {task.Exception}");
                }
            });
    }

    public void SaveChallenge3(string userId, Challenge3Data data, Action onComplete = null)
    {
        string json = JsonUtility.ToJson(data);

        dbReference.Child("users").Child(userId).Child("challenges").Child("challenge3")
            .SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    UpdateChallenge3Leaderboard(userId, data);
                    onComplete?.Invoke();
                }
                else
                {
                    Debug.LogError($"SaveChallenge3 failed: {task.Exception}");
                }
            });
    }

    private void UpdateChallenge1Leaderboard(string userId, Challenge1Data newData)
    {
        var leaderboardRef = dbReference.Child("leaderboards/challenge1");

        leaderboardRef.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            List<(string userId, Challenge1Data data)> entries = new();

            if (task.Result != null && task.Result.Exists)
            {
                foreach (var child in task.Result.Children)
                {
                    var entry = JsonUtility.FromJson<Challenge1Data>(child.GetRawJsonValue());
                    entries.Add((child.Key, entry));
                }
            }

            entries.RemoveAll(e => e.userId == userId);
            entries.Add((userId, newData));

            // Sort ascending by reactionTime (smaller is better)
            entries.Sort((a, b) => a.data.reactionTime.CompareTo(b.data.reactionTime));

            if (entries.Count > 10)
                entries = entries.GetRange(0, 10);

            var updates = new Dictionary<string, object>();
            foreach (var entry in entries)
                updates[entry.userId] = entry.data;

            leaderboardRef.SetValueAsync(updates);
        });
    }

    private void UpdateChallenge2Leaderboard(string userId, Challenge2Data newData)
    {
        var leaderboardRef = dbReference.Child("leaderboards/challenge2");

        leaderboardRef.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            List<(string userId, Challenge2Data data)> entries = new();

            if (task.Result != null && task.Result.Exists)
            {
                foreach (var child in task.Result.Children)
                {
                    var entry = JsonUtility.FromJson<Challenge2Data>(child.GetRawJsonValue());
                    entries.Add((child.Key, entry));
                }
            }

            entries.RemoveAll(e => e.userId == userId);
            entries.Add((userId, newData));

            // Sort by attempts asc, then timeTaken asc
            entries.Sort((a, b) =>
            {
                int cmp = a.data.attempts.CompareTo(b.data.attempts);
                return cmp != 0 ? cmp : a.data.timeTaken.CompareTo(b.data.timeTaken);
            });

            if (entries.Count > 10)
                entries = entries.GetRange(0, 10);

            var updates = new Dictionary<string, object>();
            foreach (var entry in entries)
                updates[entry.userId] = entry.data;

            leaderboardRef.SetValueAsync(updates);
        });
    }

    private void UpdateChallenge3Leaderboard(string userId, Challenge3Data newData)
    {
        var leaderboardRef = dbReference.Child("leaderboards/challenge3");

        leaderboardRef.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            List<(string userId, Challenge3Data data)> entries = new();

            if (task.Result != null && task.Result.Exists)
            {
                foreach (var child in task.Result.Children)
                {
                    var entry = JsonUtility.FromJson<Challenge3Data>(child.GetRawJsonValue());
                    entries.Add((child.Key, entry));
                }
            }

            entries.RemoveAll(e => e.userId == userId);
            entries.Add((userId, newData));

            // Sort by falseReports asc, then timeTaken asc
            entries.Sort((a, b) =>
            {
                int cmp = a.data.falseReports.CompareTo(b.data.falseReports);
                return cmp != 0 ? cmp : a.data.timeTaken.CompareTo(b.data.timeTaken);
            });

            if (entries.Count > 10)
                entries = entries.GetRange(0, 10);

            var updates = new Dictionary<string, object>();
            foreach (var entry in entries)
                updates[entry.userId] = entry.data;

            leaderboardRef.SetValueAsync(updates);
        });
    }

    public void LoadLeaderboardFromUsers(int challengeNumber, Action<string> onTextReady)
    {
        dbReference.Child("users").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled || !task.Result.Exists)
            {
                onTextReady?.Invoke("No data.");
                return;
            }

            List<(string userId, string nickname, object data)> entries = new();

            foreach (var userNode in task.Result.Children)
            {
                var userId = userNode.Key;
                var challengesNode = userNode.Child("challenges");

                if (!challengesNode.Exists)
                    continue;

                switch (challengeNumber)
                {
                    case 1:
                        var c1Node = challengesNode.Child("challenge1");
                        if (!c1Node.Exists) continue;
                        var c1Data = JsonUtility.FromJson<Challenge1Data>(c1Node.GetRawJsonValue());
                        entries.Add((userId, c1Data.nickname, c1Data));
                        break;
                    case 2:
                        var c2Node = challengesNode.Child("challenge2");
                        if (!c2Node.Exists) continue;
                        var c2Data = JsonUtility.FromJson<Challenge2Data>(c2Node.GetRawJsonValue());
                        entries.Add((userId, c2Data.nickname, c2Data));
                        break;
                    case 3:
                        var c3Node = challengesNode.Child("challenge3");
                        if (!c3Node.Exists) continue;
                        var c3Data = JsonUtility.FromJson<Challenge3Data>(c3Node.GetRawJsonValue());
                        entries.Add((userId, c3Data.nickname, c3Data));
                        break;
                }
            }

            // Sort & format entries for display
            StringBuilder sb = new StringBuilder();
            int rank = 1;

            switch (challengeNumber)
            {
                case 1:
                    entries.Sort((a, b) => ((Challenge1Data)a.data).reactionTime.CompareTo(((Challenge1Data)b.data).reactionTime));
                    foreach (var entry in entries)
                    {
                        var c1 = (Challenge1Data)entry.data;
                        sb.AppendLine($"{rank++}. {c1.nickname} - {c1.reactionTime:F3}s");
                        if (rank > 10) break;
                    }
                    break;
                case 2:
                    entries.Sort((a, b) =>
                    {
                        var d1 = (Challenge2Data)a.data;
                        var d2 = (Challenge2Data)b.data;
                        int c = d1.attempts.CompareTo(d2.attempts);
                        return c != 0 ? c : d1.timeTaken.CompareTo(d2.timeTaken);
                    });
                    foreach (var entry in entries)
                    {
                        var c2 = (Challenge2Data)entry.data;
                        sb.AppendLine($"{rank++}. {c2.nickname} - {c2.attempts} tries / {c2.timeTaken:F1}s");
                        if (rank > 10) break;
                    }
                    break;
                case 3:
                    entries.Sort((a, b) =>
                    {
                        var d1 = (Challenge3Data)a.data;
                        var d2 = (Challenge3Data)b.data;
                        int c = d1.falseReports.CompareTo(d2.falseReports);
                        return c != 0 ? c : d1.timeTaken.CompareTo(d2.timeTaken);
                    });
                    foreach (var entry in entries)
                    {
                        var c3 = (Challenge3Data)entry.data;
                        sb.AppendLine($"{rank++}. {c3.nickname} - {c3.falseReports} errors / {c3.timeTaken:F1}s");
                        if (rank > 10) break;
                    }
                    break;
            }

            onTextReady?.Invoke(sb.ToString());
        });
    }



}
