# 📐 Project Conventions

This document defines the conventions used throughout the **Unity Game: Data Aggregation & Visualisation** project, ensuring clarity, consistency, and maintainability across the codebase and repository.

---

## 📁 GitHub Repository Structure

```
/ (root)
│
├── UnityGame/              # Unity project assets
│   ├── Assets
│   ├── ProjectSettings
│   ├── Packages
│   ├── ...
│
├── Docs/                   # Project documentation
│   ├── Conventions.md
│   ├── Research.md
│   ├── Progress.md
│   ├── Granular Working.md
│
├── README.md               # Project overview
├── LICENSE                 # MIT License
├── CONTRIBUTING.md         # Guidelines for contributions
├── CODE_OF_CONDUCT.md      # Code of Conduct
├── ATTRIBUTION.md          # Tools, libraries, engines used
├── .gitignore              # Unity gitignore for files
```

---

## 🔤 Naming Conventions

### ✅ General Rules

- **PascalCase** (UpperCamelCase) is used for:
  - **Class names:**  
    Examples: `PlayerMetricsManager`, `TaskController`, `DataAggregator`
  - **Structs and Enums:**  
    Examples: `GameState`, `CognitiveTaskType`
  - **Interfaces:**  
    Prefixed with `I`, e.g., `IDataService`, `ITaskProcessor`
  - **Public methods:**  
    Examples: `SavePlayerData()`, `CalculateAverageReaction()`
  - **Properties:**  
    Examples: `PlayerScore`, `IsTaskComplete`
  - **Events:**  
    Examples: `OnTaskStarted`, `OnDataSaved`
  - **Script filenames:**  
    Match the class name, e.g., `GameController.cs`

- **camelCase** (lowerCamelCase) is used for:
  - **Private and internal fields:**  
    Examples: `reactionTime`, `_playerId`, `_isRunning` (underscore optional but common)
  - **Method parameters:**  
    Examples: `playerId`, `taskDuration`, `dataPoint`
  - **Local variables inside methods:**  
    Examples: `index`, `tempResult`, `counter`
  - **Private methods (optional):**  
    Some teams prefer PascalCase for all methods, but camelCase is acceptable for private ones.
  - **Delegates, lambda parameters, anonymous functions:**  
    Example: `(item) => item.IsComplete`

- **ALL_CAPS_WITH_UNDERSCORES** is used for:
  - **Constants:**  
    Examples: `MAX_REACTION_TIME`, `DEFAULT_TASK_DURATION`, `API_KEY`

---

### ❌ Avoid:

- Hungarian notation:  
  e.g., `strName`, `iCount`, `bIsActive`
- snake_case or kebab-case for code elements:  
  e.g., `player_score`, `reaction-time`
- Unclear abbreviations:  
  e.g., `tmp`, `val`, `obj`, `data1`  
  Prefer descriptive names like `temporaryScore`, `playerData`, `reactionValue`.

---

## 📦 Unity Folder Structure

```
Assets/
│
├── Art/                            # Art assets (sprites, models)
│   ├── Materials/                  # Contains all materials to apply to models
│   ├── Meshes/                     # Contains all meshes to apply in scene
│   ├── Textures/                   # Contains all textures to apply to materials
│
├── Audio/                          # Audio files (music, SFX)
│   ├── Character/                  # Contains all sounds made by characters in the game
│   ├── SFX/                        # Contains all sounds for sound effects
│   ├── Music/                      # Contains all sounds for music used
│
├── Scripts/                        # All C# scripts
│   ├── Tasks/                      # Each cognitive task (Reaction Time, Auditory Memory, etc.)
│   ├── Metrics/                    # Logic for capturing and processing metrics
│   ├── Services/                   # Firebase or other backend services
│   ├── Managers/                   # Game, Input, and Task managers
│
├── Prefabs/                        # Reusable game objects
├── Scenes/                         # Unity scenes
├── Lighting/                       # Baked light files
```

---

## 📂 Reasoning Behind Folder Structure

The chosen folder structure follows a **content-based and future-proof approach**:

- **Content-based grouping:**  
  Files and assets are organized by their purpose or content type (e.g., Scripts divided by feature like Tasks, Metrics, Services). This makes it easier to locate and manage related components.

- **Scalability and maintainability:**  
  As the project grows, new features or cognitive tasks can be added into dedicated folders without cluttering the structure. This minimizes confusion and reduces merge conflicts when multiple developers work concurrently.

- **Clear separation of concerns:**  
  Keeping Scripts, Art, Audio, Prefabs, and Scenes separated helps maintain a clean workflow in Unity and supports better project collaboration.

- **Unity best practices alignment:**  
  The structure aligns with Unity’s recommendations and common community conventions, aiding newcomers and team members to quickly understand and navigate the project.

This approach ensures the project remains organized, understandable, and easy to extend over time.