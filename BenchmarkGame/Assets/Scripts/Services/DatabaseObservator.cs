/// <summary>
/// This file is responsible for collecting specific data types recorded in cognitive tasks or challenges.
/// </summary>

using System;

[System.Serializable]
public class UserData
{
    public string userId;
    public string creationTimestamp;
    public string nickname;

    public UserData(string nickname)
    {
        userId = System.Guid.NewGuid().ToString();
        creationTimestamp = System.DateTime.UtcNow.ToString("o");
        this.nickname = nickname;
    }
}

[System.Serializable]
public class Challenge1Data
{
    public float reactionTime;
    public string timestamp;
    public string nickname;

    public Challenge1Data(float reactionTime, string nickname)
    {
        this.reactionTime = reactionTime;
        this.nickname = nickname;
        this.timestamp = System.DateTime.UtcNow.ToString("o");
    }
}

[System.Serializable]
public class Challenge2Data
{
    public int attempts;
    public float timeTaken;
    public string timestamp;
    public string nickname;

    public Challenge2Data(int attempts, float timeTaken, string nickname)
    {
        this.attempts = attempts;
        this.timeTaken = timeTaken;
        this.nickname = nickname;
        this.timestamp = System.DateTime.UtcNow.ToString("o");
    }
}

[System.Serializable]
public class Challenge3Data
{
    public int falseReports;
    public float timeTaken;
    public string timestamp;
    public string nickname;

    public Challenge3Data(int falseReports, float timeTaken, string nickname)
    {
        this.falseReports = falseReports;
        this.timeTaken = timeTaken;
        this.nickname = nickname;
        this.timestamp = System.DateTime.UtcNow.ToString("o");
    }
}
