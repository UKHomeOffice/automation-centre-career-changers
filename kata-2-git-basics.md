# Kata 2 – Git Basics

**Duration:** 1-2 hours


## Steps

### Objective

Learn the fundamentals of Git version control, including repository initialization, branching, committing, merging, conflict resolution, and connecting to a remote repository on GitHub.

### Prerequisites

Before starting:

* Visual Studio Code installed with the Git extension
* Git installed and configured (`git --version` to verify)
* A GitHub account (provided during the onboarding process)

---

### Exercise Steps

#### Step 1 – Initialise a Repository

1. Open the terminal in your workspace folder.

2. Run:

   ```bash
   git init
   ```

3. Create a `.gitignore` file using:

   ```bash
   dotnet new gitignore
   ```

   (If not available, add `bin/`, `obj/`, and `.vscode/` folders manually.)

4. Stage and commit the initial setup:

   ```bash
   git add .
   git commit -m "Initial commit – environment setup"
   ```

---

#### Step 2 – Branching and Committing

1. Create a new branch:

   ```bash
   git checkout -b feature/readme
   ```
2. Create a `README.md` describing your environment setup.
3. Stage and commit:

   ```bash
   git add README.md
   git commit -m "Added README with environment summary"
   ```
4. Merge it into `main`:

   ```bash
   git checkout main
   git merge feature/readme
   ```

---

#### Step 3 – Experiment with Conflict Resolution

1. Create two branches from `main`:

   ```bash
   git checkout -b feature/lineA
   git checkout main
   git checkout -b feature/lineB
   ```
2. Edit the same line in `README.md` on both branches.
3. Merge them sequentially into `main` to create a conflict:

   ```bash
   git checkout main
   git merge feature/lineA
   git merge feature/lineB
   ```
4. Resolve the conflict manually in VS Code using its built-in merge editor.
5. Commit the resolved file.

---

#### Step 4 – Connect to GitHub (Remote Repository)

1. Create a new **private** GitHub repository named `kata2-git-basics`.
2. Add the remote and push your main branch:

   ```bash
   git remote add origin https://github.com/<username>/kata2-git-basics.git
   git branch -M main
   git push -u origin main
   ```
3. Verify that your commits and branches appear online.

#### Step 5 – Create a Pull Request

1. Create a new branch `feature/pull-request`:

   ```bash
   git checkout -b feature/pull-request
   ```

2. Make a small change to `README.md` (e.g., add a new section).
3. Push the branch to GitHub:

   ```bash
   git push -u origin feature/pull-request
   ```   
4. Go to GitHub and create a Pull Request from `feature/pull-request` to `main` by clicking pull requests on your repository page and then "New pull request". The "base" should be `main` and the "compare" should be `feature/pull-request`.
5. Add a descriptive title and comment, then create the Pull Request.
6. Assign this PR to your mentor for review and approval and run through with them. (You will be doing this a lot in future katas!)

---

### Completion Criteria

To complete this kata successfully, you should:

* Have a local Git repository initialised and connected to GitHub
* Demonstrate clean commit history with clear messages
* Show successful branching, merging, and conflict resolution
* Push your work to GitHub and create a Pull Request to review with your mentor.


### Additional Learning 

#### When to use different branch types (Feature/Hotfix/BugFix)
| Branch Type | Purpose                                                                 | Naming Convention        | Example                |
|-------------|-------------------------------------------------------------------------|--------------------------|------------------------|   
| Feature     | Develop new features or enhancements.                                   | `feature/short-description` | `feature/add-login`    |
| Hotfix      | Quick fixes for critical issues in production.                         | `hotfix/short-description`  | `hotfix/fix-crash`     |
| BugFix      | Fixes for non-critical issues that need to be addressed in the next release.               | `bugfix/short-description` | `bugfix/fix-typo`      |

#### Tags (for releases)

| Tag Format | Purpose                          | Example    |
|------------|----------------------------------|------------|
| vX.Y.Z     | Semantic versioning for releases | `v1.0.0`   |
| vX.Y.Z-rcN | Release candidate pre-release    | `v1.0.0-rc1` |

### Resource Links

| Topic                     | Link                                                                                                                                                                                                         |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Git Basics                | [https://git-scm.com/docs/gittutorial](https://git-scm.com/docs/gittutorial)                                                                                                                                 |
| GitHub Flow               | [https://docs.github.com/en/get-started/using-github/github-flow](https://docs.github.com/en/get-started/using-github/github-flow)                                                                           |
| VS Code & Git Integration | [https://code.visualstudio.com/docs/sourcecontrol/overview](https://code.visualstudio.com/docs/sourcecontrol/overview)                                                                                       |
| Resolving Merge Conflicts | [https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/addressing-merge-conflicts](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/addressing-merge-conflicts) |
| Git Tagging              | [https://git-scm.com/book/en/v2/Git-Basics-Tagging](https://git-scm.com/book/en/v2/Git-Basics-Tagging)     