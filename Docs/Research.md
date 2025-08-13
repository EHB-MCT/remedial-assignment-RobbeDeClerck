# 📚 Research on Best Practices for Unity Projects and GitHub Repositories

This document summarizes key research findings and best practices applied to the **Unity Game: Data Aggregation & Visualisation** project, including GitHub repository management, folder structure, naming conventions, and Unity development standards.

---

## 1. GitHub Repository Best Practices

### 1.1 Repository Structure

- Keep the repository organized with clear separation between code, documentation, and assets.  
- Include essential files at root level:  
  - `README.md` for project overview and setup instructions  
  - `LICENSE` for licensing information  
  - `CONTRIBUTING.md` to guide contributors  
  - `CODE_OF_CONDUCT.md` to set community expectations  
  - `Docs/` folder to house detailed documentation and research notes  
- Use `.gitignore` specific to Unity projects to avoid committing unnecessary or large temporary files.  
- Branching strategy: Use feature branches, hotfixes, and main/development branches to keep history clean and collaborative workflow efficient.  
- Commit messages should follow [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) for clarity and automation compatibility.

### 1.2 Git History and Branching

- Make focused commits that reflect small, self-contained changes.  
- Use descriptive commit messages indicating the type and purpose of the change (`feat:`, `fix:`, `docs:` etc.).  
- Maintain a clean, readable history by rebasing or squashing commits before merging.  
- Delete branches after merging to reduce clutter.

### Sources  
- [GitHub Docs: Managing branches](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/about-branches)  
- [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/)  
- [Unity Git Best Practices](https://unity.com/how-to/version-control-systems)

---

## 2. Folder Structure

### 2.1 GitHub Repository Folder Structure

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

### 2.2 Unity Folder Structure

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

### 2.3 Explanation of Folder Structure

- The folder structure is content-based to improve discoverability and modularity.  
- Separating scripts by function and feature reduces merge conflicts and improves code maintainability.  
- Aligns with Unity community and official recommendations, aiding new developers onboarding.  
- Supports scalability as the project grows in complexity with multiple cognitive tasks and features.

### Sources  
- [Unity Manual: Project Folder Structure](https://unity.com/how-to/organizing-your-project)  
- [Unity Learn: Best Practices](https://unity.com/how-to/formatting-best-practices-c-scripting-unity)  
- [Unity Blog: Version Control](https://unity.com/how-to/version-control-systems)

---

## 3. Naming Conventions

### 3.1 Summary

- **PascalCase** for classes, structs, enums, interfaces, public methods, properties, events, and script filenames.  
- **camelCase** for private/internal fields, method parameters, local variables, and optionally private methods.  
- **ALL_CAPS_WITH_UNDERSCORES** for constants.

### 3.2 Avoid

- Hungarian notation, snake_case, kebab-case, and ambiguous abbreviations.  
- Use meaningful descriptive names to improve readability.

### Sources  
- [Microsoft C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)  
- [Unity C# Coding Standards](https://unity3d.com/learn/tutorials/topics/scripting/c-coding-standards)  
- [Style Guide - Google C# Style Guide](https://google.github.io/styleguide/csharp-style.html)

---

## 4. Unity Best Practices

- Keep scripts modular and single-responsibility following SOLID principles.  
- Use scriptable objects and prefabs for reusable and configurable assets.  
- Minimize scene complexity and manage scene loading effectively.  
- Use Unity’s built-in systems for input, UI, and events for consistency and performance.  
- Regularly profile and optimize assets and scripts to ensure smooth performance.  
- Document code and project structure clearly to facilitate collaboration and maintenance.

### Sources  
- [Unity Learn: Best Practices](https://unity.com/how-to/formatting-best-practices-c-scripting-unity)  

---

## 5. References

- [GitHub Docs](https://docs.github.com/en)  
- [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/)  
- [Unity Documentation](https://docs.unity3d.com/Manual/index.html)  
- [Microsoft C# Guidelines](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)  
- [Unity Learn](https://learn.unity.com/)  
- [Google C# Style Guide](https://google.github.io/styleguide/csharp-style.html)

---

*This research document will be updated as new best practices are adopted or learned throughout the project lifecycle.*