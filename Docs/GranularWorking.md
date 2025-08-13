# 📄 Granular Working – Database & Data Tracking

This document explains in **granular detail** the functionality of the three main scripts responsible for **data storage, retrieval, and visualization** in the Unity cognitive task project.

---

## 1. `DatabaseManager.cs`

### **Purpose**
Acts as the **central point** for all Firebase Realtime Database interactions.  
Responsible for **writing player performance data** and **retrieving leaderboard entries** for each challenge.

### **Key Responsibilities**
- Maintain connection to Firebase.
- Write structured data to `/userid/challenges`.
- Retrieve and format leaderboard results for UI display.

### **Public Methods**

#### `void SaveChallengeData(int challengeId, object data)`
- **Inputs:**
  - `challengeId` – Index of the challenge (1, 2, 3).
  - `data` – Serializable object holding performance metrics.
- **Process:**
  - Builds a Firebase path:  
    ```
    /<UserID>/challenges/challenge<challengeId>
    ```
  - Saves the `data` object to Firebase under that path.
- **Usage Example:**
  ```csharp
  DatabaseManager.Instance.SaveChallengeData(1, new Challenge1Data { reactionTime = 0.321f });
  ```

#### `void LoadLeaderboardText(int challengeId, Action<string> onComplete)`
- **Inputs:**
  - `challengeId` – Index of the challenge (1, 2, 3).
  - `onComplete` – Serializable object holding performance metrics.
- **Process:**
  - Queries Firebase for all users’ data for the given challenge.
  - Sorts entries based on performance metric (fastest reaction, highest score, etc.).
  - Formats into a string list for display.
- **Usage:**
Called by `LeaderboardUIManager` when the leaderboard needs updating.

---

## Data Structure in Firebase

### Nodes Overview

- **`/users/{userId}/challenges`** — canonical source of each player’s best (or latest) results.
- **`/leaderboards/challenge{1|2|3}`** — denormalized top-10 snapshots, updated on each save (used for quick display).

```json
{
  "user123": {
    "challenges": {
      "challenge1": {
        "reactionTime": 0.321
      },
      "challenge2": {
        "attempts": 1,
        "timeTaken": 2.011102
      },
      "challenge3": {
        "falseReports": 1,
        "timeTaken": 2.20314
      }
    }
  }
}
```
---

## Data Saving Process

### Relevant Scripts:
- **`DataTrackingManager.cs`**
- **`DatabaseManager.cs`**

### Flow:
1. **End of Challenge Event** (Example: `ReactionTimeChallenge.cs`)
   - The challenge script calls:
     ```csharp
     DataTrackingManager.Instance.TrackChallenge1(reactionTime);
     ```
2. **DataTrackingManager**:
   - Prepares data object with metric(s) and a timestamp.
   - Passes it to `DatabaseManager.SaveChallengeResult()`.
3. **DatabaseManager**:
   - Writes result to `/users/{userId}/challenges/{challengeId}`.
   - Reads all users' scores for that challenge, sorts, and updates `/leaderboards/challenge{n}`.

---

## Data Retrieval Process

### Relevant Scripts:
- **`LeaderboardUIManager.cs`**
- **`DatabaseManager.cs`**

### Flow:
1. **On Scene Load or Manual Refresh**:
   - `LeaderboardUIManager.LoadAllLeaderboards()` calls:
     ```csharp
     DatabaseManager.Instance.LoadLeaderboardText(1, (text) => { challenge1Text.text = text; });
     ```
     ... and similarly for challenges 2 & 3.
2. **DatabaseManager.LoadLeaderboardText**:
   - Reads `/leaderboards/challenge{n}`.
   - Formats into a string like:
     ```
     1. PlayerA - 0.347s
     2. PlayerB - 0.401s
     ```
   - Sends formatted string back via callback.

---

## Real-Time Leaderboard Update After Submission

The leaderboard refresh is triggered after a challenge submission so the player can see their new rank.

### Example:
In `ReactionTimeChallenge.cs` after saving data:
```csharp
DatabaseManager.Instance.LoadLeaderboardText(1, (text) =>
{
    challenge1Text.text = text;
});
```

---

## Advantages of This Structure

1. **Separation of Concerns**  
   - `DataTrackingManager` handles gameplay-to-data pipeline.
   - `DatabaseManager` handles cloud operations.

2. **Fast UI Loading**  
   - Leaderboards are pre-sorted in Firebase so the client only formats them.

3. **Scalability**  
   - Adding new challenges only requires creating new Firebase nodes and updating minimal code.

---

## 2. `DataTrackingManager.cs`

### Overview
`DataTrackingManager` is a central service responsible for collecting, processing, and storing player performance data during gameplay. It ensures that all relevant metrics from cognitive challenges are properly captured and stored in Firebase.

---

## Core Responsibilities
1. **Centralized Data Collection**  
   Captures metrics from all challenges (reaction time, auditory memory accuracy, visual perception accuracy).
2. **Data Processing**  
   Formats and validates data before storing in Firebase.
3. **Firebase Data Sync**  
   Sends metrics to the correct user node in the database with proper challenge indexing.

---

## Key Methods

### `TrackChallenge1(float reactionTime)`
- Called at the end of the Reaction Time challenge.
- Saves:
  - Reaction time in seconds.
  - Timestamp.
- Pushes data to:
  ```plaintext
  users/{userId}/challenges/challenge1
  ```

### `TrackChallenge2(int correctAnswers, int totalQuestions)`
- Called after the Auditory Memory challenge.
- Saves:
  - Number of correct answers.
  - Total number of questions.
  - Timestamp.
- Pushes data to:
  ```plaintext
  users/{userId}/challenges/challenge2
  ```

### `TrackChallenge3(int correct, int total)`
- Called after the Visual Perception challenge.
- Saves:
  - Correct and incorrect response counts.
  - Timestamp.
- Pushes data to:
  ```plaintext
  users/{userId}/challenges/challenge3
  ```
---

## Integration Points
- **Challenge Scripts** → Call relevant `TrackChallengeX()` method after completion.
- **FirebaseManager** → Handles actual database write operation.
- **LeaderboardUIManager** → Later reads aggregated data for display.

## 3. `LeaderboardUIManager.cs`

## Overview
`LeaderboardUIManager` is responsible for retrieving player performance data from Firebase and displaying it in the in-game leaderboard UI.

---

## Core Responsibilities
1. **Data Retrieval**  
   Calls `DatabaseManager` to fetch leaderboard text for each challenge.
2. **UI Binding**  
   Displays fetched data in `TextMeshProUGUI` elements.
3. **Real-time Updates**  
   Supports refreshing the leaderboard after a challenge is completed.

---

## Key Methods

### `LoadAllLeaderboards()`
- Calls:
  ```csharp
  DatabaseManager.Instance.LoadLeaderboardText(1, (text) => { challenge1Text.text = text; });
  DatabaseManager.Instance.LoadLeaderboardText(2, (text) => { challenge2Text.text = text; });
  DatabaseManager.Instance.LoadLeaderboardText(3, (text) => { challenge3Text.text = text; });
  ```
- Loads leaderboard entries for:
  - Challenge 1 (Reaction Time)
  - Challenge 2 (Auditory Memory)
  - Challenge 3 (Visual Perception)

---

## Integration Points
- **DatabaseManager** → Retrieves ordered leaderboard data from Firebase.
- **Challenge Scripts** → Trigger leaderboard refresh after submission.
- **UI Components** → Displays scores in corresponding challenge panels.

---

## Data Flow Summary

```plaintext
[Player Completes Challenge]
        ↓
[DataTrackingManager sends data to Firebase]
        ↓
[LeaderboardUIManager requests leaderboard update]
        ↓
[DatabaseManager retrieves latest sorted results]
        ↓
[LeaderboardUIManager updates Unity UI]
```