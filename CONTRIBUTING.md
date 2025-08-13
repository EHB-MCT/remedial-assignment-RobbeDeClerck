# 🤝 Contributing to Unity Game: Data Aggregation & Visualisation

Thank you for considering contributing to this project! Your help improves the quality, stability, and scope of this work. Please follow these guidelines to ensure a smooth development process for everyone involved.

---

## 📌 Code of Conduct

This project follows a [Code of Conduct](./CODE_OF_CONDUCT.md).  
Please be respectful, inclusive, and constructive in your contributions and communication.

---

## 🌱 How to Contribute

### 1. Fork the Repository
Create your own fork of the project repository.

### 2. Create a Feature Branch
Always create a new branch based on what you're contributing:

```bash
git checkout -b feature/<short-description>
```

**Examples:**
- `feature/data-visualisation`
- `refactor/task-controller`
- `bugfix/firebase-write-failure`
- `docs/add-research-section`

---

### 3. Make Changes
Follow the established folder structure, naming conventions, and coding standards described in the [`Docs/Conventions.md`](./Docs/Conventions.md) file.

---

### 4. Use Conventional Commits
Write clear and semantic commit messages using [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/):

## 📄 Documentation (`docs:`)

| Action | Commit |
|--------|--------|
| Add new README section | `docs(readme): add <section name> section` |
| Update existing README content | `docs(readme): update <section name>` |
| Add usage instructions | `docs: add usage instructions` |
| Add contributing guidelines | `docs: add contributing guidelines` |
| Add license file | `docs: add license` |
| Update conventions or research docs | `docs: update docs/<filename>` |

---

## ✨ Features (`feature:`)

| Action | Commit |
|--------|--------|
| Add new cognitive task | `feature(task): add task` |
| Add Firebase integration | `feature(firebase): integrate Firebase write/read` |
| Add player metrics tracking | `feature(metrics): track reaction time` |
| Add UI component | `feature(ui): add results summary screen` |

---

## 🐛 Bug Fixes (`fix:`)

| Action | Commit |
|--------|--------|
| Fix wrong metric calculation | `fix(metrics): correct reaction time logic` |
| Fix task logic | `fix(task): resolve N-back indexing bug` |
| Fix Firebase read failure | `fix(firebase): patch data fetch issue` |

---

## 🧼 Refactoring (`refactor:`)

| Action | Commit |
|--------|--------|
| Extract metric logic from controller | `refactor(metrics): move logic to service class` |
| Rename files/classes for clarity | `refactor: rename files for consistency` |

---

## 🔧 Chores & Config (`chore:`)

| Action | Commit |
|--------|--------|
| Update .gitignore | `chore: update .gitignore` |
| Setup GitHub Actions | `chore(ci): add Unity build workflow` |
| Cleanup unused assets | `chore: remove unused sprites` |

---

## 🔁 Reverts (`revert:`)

| Action | Commit |
|--------|--------|
| Revert a previous commit | `revert: fix broken metrics logic` |

---

## 🎮 Example Real Commits

```bash
docs(readme): add data flow section
feat(task): implement Stroop task with timer and scoring
refactor(metrics): separate metrics recording into new service
fix(firebase): resolve null reference on data fetch
style: reformat MetricService.cs for clarity
```

--- 

## 🐛 Submitting Issues

If you discover a bug or would like to request a feature:

1. **Search first** — Avoid duplicates.
2. Open a new issue with:
   - A clear title
   - Description of the problem or request
   - Steps to reproduce or expected behavior
   - Environment details (Unity version, platform, etc.)

---

## 📥 Pull Request Guidelines

- Your PR must reference a related issue (if applicable).
- Keep pull requests small and focused.
- Add comments for complex logic if necessary.
- Include screenshots or logs for UI or Firebase-related changes.
- Make sure to update documentation if your change affects it.
