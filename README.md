# 🧠 Unity Game: Data Aggregation & Visualisation

This Unity project is developed to implement **data aggregation** and **visualize player data** in the context of three well-established **human cognitive tasks**. Its purpose is to **benchmark and analyze human decision-making** under both normal and challenging conditions by studying reaction, memory, attention, and perception. 

The collected data aims to help researchers and developers **understand how players make decisions**, identify patterns in cognitive performance, and inform improvements in design, training, or adaptive systems.

---

## 📚 Table of Contents

- [🛠️ Getting Started](#-getting-started)
- [🎮 Player Controls](#-player-controls)
- [🚀 Features](#-features)
- [🧠 Purpose & Key Metrics](#-purpose--key-metrics)
- [📊 Data Flow](#-data-flow)
- [🧰 Tech Stack](#-tech-stack)
- [🧠 Cognitive Tasks Overview](#-cognitive-tasks-overview)
- [📈 Visualization](#-visualization)
- [🤝 Contributing](#-contributing)
- [📄 License](#-license)
- [🙏 Attribution](#-attribution)

---

# 🛠️ Getting Started

Follow these steps to set up the project locally:

## 1. Clone the Repository

```bash
git clone https://github.com/EHB-MCT/remedial-assignment-RobbeDeClerck.git
```

## 2. Open the Project in Unity
- Open Unity Hub
- Add the cloned folder as a new project (Add project from disc)
- Recommended version: **Unity 2022.3 LTS**

## 3. Open the Project in Unity
- Open the scene located in ```/Scenes/```
- Click the **Play** button in the Unity Editor to begin testing

---

## 🎮 Player Controls

| Input Key | Action              |
|-----------|---------------------|
| `W` `A` `S` `D` | Move forward / left / back / right |
| `Space`   | Jump                |
| `Left Shift` | Sprint               |

---

# 🔊 Audio Requirement Disclaimer

This project **requires audio playback** for certain cognitive tasks, specifically the **Auditory Memory** challenge.  
Players must ensure that their device’s sound is **enabled and functional** in order to successfully complete all tasks.  
Using headphones is recommended for the best experience and to avoid missing important auditory cues.


---

# 🚀 Features

- 🎮 **Three Modular Cognitive Tasks**
  - Reaction Time
  - Auditory Memory
  - Visual Perception

- 📊 **Real-Time Data Aggregation**
  - Tracks metrics such as reaction time, memory accuracy, and perception

- ☁️ **Cloud-Based Data Storage**
  - Uses Firebase SDK for real-time storage and retrieval of user performance data

- 📈 **In-Game Visualization**
  - Summarized data is shown on-screen after all tasks are completed (reaction time, accuracy, etc.)

- 🧩 **Modular, Scalable Architecture**
  - Built with design patterns and SOLID principles for maintainability

- 🧠 **Designed for Research & Analysis**
  - Benchmark cognitive load and decision making under different task conditions

---

## 🧠 Purpose & Key Metrics

This project studies **player responses to cognitive challenges** using tasks that demand focus, memory, inhibition, and perception. The data collected is used to:

- Evaluate **cognitive performance** under time or complexity pressure
- Benchmark **normal vs. hard difficulty performance**
- Investigate **choice behavior** and task-switching strategies

### 🔍 Key Metrics Collected:

| Metric                       | Description                                                                 |
|-----------------------------|-----------------------------------------------------------------------------|
| ⏱️ **Reaction Time**         | Time taken to respond to stimuli (measured in ms)                          |
| 🎧 **Auditory Memory**       | Performance on sound-based sequences                |
| 👀 **Visual Attention**      | Accuracy and focus on visual elements (e.g., colors/locations)             |
| 📈 **Task Performance**      | Overall task completion accuracy, speed, and decision paths                |

---

## 📊 Data Flow

This project uses a **structured data flow** to capture, store, and visualize player performance in cognitive tasks:

```plaintext
[Player Input] 
    ↓
[Task Controller + Metrics Recorder]
    ↓
[Firebase SDK (Realtime Database)]
    ↓
[Cloud Storage]
    ↓
[Unity Data Fetcher]
    ↓
[In-Game Visualisation]
```

### 🔁 Description of Flow:

- **Player Input:** The player interacts with cognitive tasks via keyboard and mouse.
- **Task Controller:** Runs the logic and flow of each task (Reaction Time, Auditory Memory and Visual Perception)
- **Metric Recorder:** Captures timestamps, correctness, accuracy, reaction time, and other KPIs. 
- **Firebase SDK:** Sends data to a cloud database (Realtime Database) 
- **Cloud Storage:** Securely stores user performance data (see task controller) with timestamps and a unique user ID.
- **Unity Data Fetcher:** Pulls historical or session data from Firebase when needed.
- **Visualization:** Displays data in Unity (performance summary at the end of the tests), allowing players or researchers to view trends and compare sessions.

---

# 🧰 Tech Stack

| Tool/Framework      | Purpose                            |
|---------------------|------------------------------------|
| **Unity (2022.3 LTS)** | Game engine and runtime logic      |
| **C#**              | Scripting language                 |
| **Firebase SDK**    | Cloud data storage and sync        |
| **Git + GitHub**    | Version control and collaboration  |

---

## 🧠 Cognitive Tasks Overview

| Task      | Description                                                                 |
|-----------|-----------------------------------------------------------------------------|
| **Reaction Time** | Measures cognitive performance based on reaction time                    |
| **Auditory Memory** | Tests working memory by recalling audio spoken messages             |
| **Visual Perception**  | Evaluates response inhibition through color-position matching challenges   |

---

# 📈 Data Visualization (In-Game Summary)

Instead of using external graphing tools, this project displays **player performance data directly in the Unity UI** after each task.

### 📊 How It Works

- After completing all tasks, a **summary screen** appears
- Shows **aggregated stats**:
  - Reaction time (average, fastest, slowest)
  - Correct/incorrect responses
  - Task-specific metrics (e.g., accuracy)

> All data is also synced to Firebase for longitudinal analysis or external use if needed.

---

# 🤝 Contributing

Contributions are welcome!
Please read [CONTRIBUTING.MD](CONTRIBUTING.MD) for setup instructions, coding guidelines, and branch naming conventions.

---

# 📄 License

This project is licensed under the MIT License. 
See the [MIT License](LICENSE.MD) file for full details.

---

# 🙏 Attribution

See [ATTRIBUTION.MD](ATTRIBUTION.MD) for third-party libraries, datasets, and tools used.

---

# 🧠 AI Usage

See [AI Usage.MD](AI_USAGE.MD) for AI usage in this project.

---

# 📚 Sources

## Technical References

- **Firebase Unity SDK**  
  [Firebase Docs – Unity Setup](https://firebase.google.com/docs/unity/setup)

- **Unity Input System**  
  [Unity Manual – Input](https://docs.unity3d.com/Manual/ConventionalGameInput.html)

- **GitHub Flow & Branching**  
  [GitHub Docs – GitHub Flow](https://docs.github.com/en/get-started/quickstart/github-flow)

- **SOLID Principles**
  - [Unity SOLID Principles](https://medium.com/@mthndmr16/the-importance-and-application-of-solid-principles-in-unity-game-development-94be186ad51f) → minimal integration in `AnomalyTarget.cs`
  - [Unity SOLID Principles](https://youtu.be/QDldZWvNK_E) → `IChallenge.cs`
  - [Unity SOLID Principles](https://www.youtube.com/watch?v=2COJ7hYGkt8) → `PlayerMovementController.cs`

- **SOLID Principles** *(Applied in Project)*  
  - `GameFlowManager` (scene/challenge transitions), `DataTrackingManager` (metrics storage)  
  - `ChallengeBase` + derived challenge scripts (extensible without modifying base)  
  - Any challenge can replace another in `GameFlowManager` via `ChallengeBase`  
  - `IDataUploader` keeps upload logic separate from challenge logic  
  - `PlayerTeleportService` injected into `GameFlowManager`

- **Design Patterns**
  - [Unity Design Patterns](https://learn.unity.com/project/65de084fedbc2a0699d68bfb)
  - [Unity Design Patterns](https://medium.com/@sonusprocks/design-patterns-in-unity-c-in-simple-words-4e05d57f86aa)
  - [Unity Program Patterns](https://github.com/Habrador/Unity-Programming-Patterns)

- **Design Patterns** *(Applied in Project)*  
  - **Singleton** → `GameFlowManager.cs`, `DataTrackingManager.cs`  
  - **Template Method** → `ChallengeBase.StartChallenge()` defines the flow, subclasses implement specifics  
  - **Observer/Event** → Challenges notify `DataTrackingManager.cs` on completion without tight coupling  
  - **Service Locator** → `PlayerTeleportService.cs` accessed without direct dependency

## Documentation
- [Conventions](Docs/Conventions.md)
- [Granular Working](Docs/GranularWorking.md)
- [Progress](Docs/Progress.md)
- [Research](Docs/Research.md)