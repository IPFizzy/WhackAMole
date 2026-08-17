# Whack-A-Mole

A compact **C# Windows Forms game** that turns a simple reaction challenge into a complete desktop practice project with scoring, lives, increasing difficulty, decoys, persistent high scores, and a layered application structure.

<p>
  <img src="https://img.shields.io/badge/C%23-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 10" />
  <img src="https://img.shields.io/badge/Windows%20Forms-Desktop-0078D4?style=flat-square&logo=windows11&logoColor=white" alt="Windows Forms" />
  <img src="https://img.shields.io/badge/Status-Complete-238636?style=flat-square" alt="Project status: Complete" />
</p>

## Overview

Whack-A-Mole is a small reaction game built to practice event-driven desktop development in C#. The player tries to click a moving target while avoiding a decoy. Missing the target, clicking the decoy, or clicking the wrong area costs a life. As the score increases, the game becomes progressively faster and the buttons become smaller.

Although intentionally compact, the project includes a complete playable loop and separates score persistence from the presentation layer through dedicated model, business-logic, and data-access classes.

## Features

- Playable Windows Forms reaction game
- Moving target placed at randomized screen positions
- Red decoy button that penalizes incorrect clicks
- Three-life game system
- Score tracking
- Ten progressive difficulty levels
- Faster target movement as the level increases
- Smaller targets at higher levels
- Target and decoy overlap prevention
- Pause, resume, and reset controls
- Elapsed-time display
- Player-name entry
- Persistent high-score storage
- Top-five score display at the end of each game
- Layered model, business-logic, data-access, and presentation structure

## Gameplay

The player begins with **3 lives** and starts at **Level 1**.

- Click the moving target to earn a point.
- Avoid the red decoy.
- Missing a target before it moves costs one life.
- Clicking the decoy costs one life.
- Clicking the form instead of the target also costs one life.
- Every five points increases the level.
- Higher levels reduce the amount of time available to hit the target and shrink the clickable buttons.
- The game ends when all lives are lost.

When the game ends, the player's score and level are saved and the five highest recorded scores are displayed.

## Technology

| Area | Technology |
| --- | --- |
| Language | C# |
| Runtime | .NET 10 |
| Desktop UI | Windows Forms |
| Persistence | Local text-file storage |
| Architecture | Presentation, model, business-logic, and data-access layers |

## Project Structure

```text
WhackAMole/
├── WhackAMole/
│   ├── Models/
│   │   └── GameScoreModel.cs
│   ├── PresentationLayer/
│   │   ├── FrmStopwatch.cs
│   │   ├── FrmStopwatch.Designer.cs
│   │   └── FrmStopwatch.resx
│   ├── Services/
│   │   ├── BusinessLogicLayer/
│   │   │   └── GameScoreLogic.cs
│   │   └── DataAccessLayer/
│   │       └── GameScoreDAO.cs
│   ├── Program.cs
│   └── WhackAMole.csproj
└── WhackAMole.slnx
```

## Design Notes

The game uses a Windows Forms timer to manage elapsed time, target movement, missed-target penalties, and difficulty progression. The target and decoy are assigned randomized positions within safe form boundaries, with collision checks used to prevent the two buttons from overlapping.

Difficulty is tied to score. Each new level reduces the movement delay and gradually decreases the size of the interactive buttons while maintaining minimum dimensions so the game remains playable.

High-score handling is separated from the form itself. `GameScoreLogic` selects the highest saved scores, while `GameScoreDAO` handles reading and writing score records to `highscores.txt`.

## Running the Project

### Requirements

- Windows 10 or Windows 11
- Visual Studio with .NET desktop development support, or the .NET 10 SDK

Clone the repository:

```bash
git clone https://github.com/IPFizzy/WhackAMole.git
cd WhackAMole
```

Open `WhackAMole.slnx` in Visual Studio and run the `WhackAMole` project.

From the command line, the project can also be built with:

```bash
dotnet build WhackAMole.slnx
```

Run the application with:

```bash
dotnet run --project WhackAMole/WhackAMole.csproj
```

## Practice Project Context

This repository began as a focused desktop-development exercise and is preserved as a completed practice project. It demonstrates event-driven programming, timers, randomized UI behavior, progressive game-state changes, basic persistence, and separation of application responsibilities in a small codebase.

## Author

**Keon Bushman**  
Software Development Student & IT Professional  
[GitHub Profile](https://github.com/IPFizzy)
