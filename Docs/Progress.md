# 🚧 Project Progress Log

This document tracks the development progress of the **Unity Game: Data Aggregation & Visualisation** project. It outlines major decisions, implementation stages, and methodology used to guide development.

---

## 📐 Unity Project Conventions

**Status:** ✅ Finalized  
**Date Started:** 2025-08-07
**Date Ended:** 2025-08-07

- Chose a **content-based** folder structure for maintainability and scalability.
- Established naming conventions based on PascalCase and camelCase.
- Defined Unity-specific best practices (e.g., modular scripts, use of managers, ScriptableObjects).
- Adopted GitHub best practices for project management and documentation.
- Version control follows Git Flow with Conventional Commits for clarity.

---

## ♻️ Refactoring Existing Scripts

**Status:** ✅ Completed  
**Date Started:** 2025-08-07
**Date Ended:** 2025-08-12

- Refactored monolithic task logic into modular scripts under `Scripts/Challenges/`.
- Separated metric tracking into a dedicated `DatabaseManager` class.
- Created reusable prefabs and managers to reduce duplication.

---

## Cognitive Task Design

**Status:** ✅ Finalized (for first iteration)  
**Date Started:** 2025-08-07
**Date Ended:** 2025-08-12

- Selected tasks designed to evaluate human cognition:
  - Reaction Time Test
  - Auditory Memory Challenge
  - Visual Attention/Perception Task
- Each task is implemented with dedicated scripts and UI feedback.

---

## 📊 Deciding Which Data to Track

**Status:** ✅ Completed  
**Date Started:** 2025-08-07
**Date Ended:** 2025-08-12

The following metrics are tracked per player per session:
- Player Reaction Time (milliseconds)
- Auditory Memory Accuracy (percentage)
- Visual Perception Accuracy (targets detected / missed)
- Timestamp of each event
- Task Completion Time
- Number of retries (if applicable)

---

## ☁️ Firebase Integration for Data Tracking

**Status:** ✅ Completed  
**Date Started:** 2025-08-07
**Date Ended:** 2025-08-12

- Integrated Firebase Realtime Database SDK into Unity project.
- Data is stored securely under anonymized player identifiers.
- Each metric is written to Firebase after task completion or update.

---

## In-Game Data Visualisation

**Status:** ✅ Completed (Initial Implementation)  
**Date Started:** 2025-08-07
**Date Ended:** 2025-08-12

- Added an in-game UI summary screen.
- Metrics displayed include:
  - Reaction Time average
  - Visual/Auditory accuracy
  - Total session duration
- Data is refreshed and shown at the end of each task session.

---

## Firebase Implementation

**Status:** ✅ Completed
**Date Started:** 2025-08-07
**Date Ended:** 2025-08-12

- Added Realtime Database integration into the project.
- All statistics achieved by the player is saved and stored into the Firebase Database, fetched and displayed back into Unity scene.
- Players must relaunch the game to see the achieved scores on the global leaderboard (personal statistics are showcased immediately after finishing).

---

## Difficulty Implementation

**Status:** ✅ Completed
**Date Started:** 2025-08-07
**Date Ended:** 2025-08-12

- Added integration of normal and hard difficulty changes in the sequence challenge
- Players have to remember more numbers and are given less time inbetween each number.

---

*This file will continue to be updated throughout the project lifecycle to reflect ongoing decisions and progress.*
