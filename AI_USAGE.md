# AI_USAGE.md

## Overview
This document outlines all uses of Artificial Intelligence (AI) assistance in the development of this project.  
The goal is to provide transparency about which parts of the project were generated, modified, or influenced by AI, and to clarify that all AI-assisted work was reviewed and tested by a human developer before inclusion.

---

## AI Provider & Model
- **Provider:** OpenAI  
- **Model:** GPT-5 (code & design assistance)  
- **Interaction Mode:** Conversational prompt-response

---

## Scope of AI Assistance

### 1. **Code Implementation**
AI was used to assist in writing, refactoring, and optimizing several scripts in this Unity project.  
The following scripts were directly impacted by AI suggestions:

#### **Challenge System**
- **`DatabaseTrackingManager.cs`**
  - Implemented `SaveChallenge1`, `SaveChallenge2`, and `SaveChallenge3` methods.
  - Added immediate leaderboard updates after challenge completion.
- **`UI_LeaderboardDisplay.cs`**
  - Integrated leaderboard refresh after challenge data submission.

#### **Challenge Scripts**
- **`ReactionTimeChallenge.cs`**
  - Adjusted UI behavior for displaying reaction time results.
- **`ReactionTimeTrigger.cs`**
  - Created trigger-based challenge activation for Challenge 1.
- **`FindAnomalyManager.cs`**
  - Refined success/failure detection and result text output.
- **`SequenceRecallManager.cs`**
  - Adjusted to support leaderboard update logic after completion (if applicable).

#### **Game Flow**
- **`GameFlowManager.cs`**
  - Modified to handle special case for Challenge 1 (manual trigger instead of auto-start).
  - Adjusted challenge transitions with fade effects and announcer integration.

---

### 2. **Debugging & Problem Solving**
AI was used to:
- Diagnose and fix issues where certain challenges auto-started unintentionally (`GameFlowManager.cs`).
- Resolve UI behavior issues where canvases displayed prematurely (`ReactionTimeChallenge.cs`).
- Identify and correct missing audio cues after refactors (`ReactionTimeChallenge.cs`, `FindAnomalyManager.cs`).
- Recommend Unity-specific best practices for event timing, `Coroutine` usage, and fade transitions (`GameFlowManager.cs`, `ScreenFadeManager.cs`).

---

### 3. **Code Organization & Naming Conventions**
AI provided recommendations for:
- Improving script and folder organization (`Challenges/`, `Managers/`, `Services/`, `UI/`, etc.).
- Reducing overuse of the "Manager" suffix where unnecessary.
- Applying consistent naming styles for MonoBehaviours, services, and interfaces.
- Suggesting namespace usage for scalability and avoiding naming conflicts.

---

### 4. **Best Practices Guidance**
AI provided input on:
- Writing maintainable, modular Unity scripts.
- Structuring challenge code to allow easy addition/removal of gameplay modules.
- Using Unity lifecycle events correctly in game flow systems.
- Designing service-based architecture for database interaction (`DatabaseManager.cs`, `DatabaseTrackingManager.cs`).

---

## Human Oversight
All AI-generated or AI-assisted code was:
1. **Reviewed** by the developer.
2. **Tested** in Unity to confirm correct functionality.
3. **Modified** where necessary to fit project style, architecture, and gameplay requirements.

---

## License & Compliance
The developer retains full authorship and copyright over this codebase.  
AI-generated content is considered **tool-assisted** creation and does not transfer copyright to any third party.  
Any open-source dependencies remain under their respective licenses.

---

## Contact
For any questions regarding AI usage in this project, please contact:  
**Robbe De Clerck** — *Lead Developer*
