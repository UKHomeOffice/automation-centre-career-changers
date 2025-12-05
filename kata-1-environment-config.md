# Kata 1 — Environment Setup

## Objectives

By completing this kata, you will:

- Install core tooling using Homebrew.
- Verify that each tool is accessible.
- Be ready to start building applications in later katas.

## Steps

### Install Homebrew

```bash
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
```

Then confirm it’s available. You may need to open a new terminal tab to get this to work:

```bash
brew --version
```

---

### Install .NET SDK

```bash
brew install --cask dotnet-sdk
dotnet --version
```

If you see a version number (e.g. `9.0.100`), your installation was successful.

Add .NET tools to your path if prompted:

```bash
export PATH=$PATH:/usr/local/share/dotnet
```

---

### Install Node.js

```bash
brew install node
node -v
npm -v
```

Node will be used later for JavaScript tools and Power Platform integration.

---

### Install Git

```bash
brew install git
git --version
```

Then configure your identity (this doesn’t create a repo yet):

```bash
git config --global user.name "Your Name"
git config --global user.email "your.email@example.com"
```

---

### Install Visual Studio Code

```bash
brew install --cask visual-studio-code
```

Open VS Code from Applications and verify it launches.

### Install extensions into Visual Studio Code (4 cubes on the left sidebar or `Cmd+Shift+X`):

- C# (by Microsoft)
- C# Dev Kit (by OmniSharp)
- GitHub Copilot (by GitHub)
- GitHub Copilot Chats (by GitHub)
- Prettier - Code formatter (by Prettier)
- SQL Server (by Microsoft)

### Add VS Code to your PATH

- Open VS Code, press `Cmd+Shift+P`, type `shell command`, and select `Install 'code' command in PATH`.

---

### Install Bruno (API Testing)

```bash
brew install --cask bruno
```

Open Bruno and verify it launches from Applications.
Later katas will use Bruno to test REST APIs and endpoints.

---

### Install Docker

```bash
brew install --cask docker
```

Open Docker from Applications and verify it launches.

## Completion Criteria

- All tools installed and verified.
- Recommended extensions installed.
- Git configured with global user identity.

## Resources (for future reference)

| Topic                    | Link                                                                                                                           |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------ |
| Homebrew Documentation   | [https://docs.brew.sh/Installation](https://docs.brew.sh/Installation)                                                         |
| .NET SDK Installation    | [https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download)                                     |
| Node.js LTS Downloads    | [https://nodejs.org/en/download/](https://nodejs.org/en/download/)                                                             |
| Git Basics Guide         | [https://git-scm.com/book/en/v2/Getting-Started-Installing-Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git) |
| Visual Studio Code Setup | [https://code.visualstudio.com/docs/setup/mac](https://code.visualstudio.com/docs/setup/mac)                                   |
| Bruno Documentation      | [https://docs.usebruno.com/](https://docs.usebruno.com/)                                                                       |
