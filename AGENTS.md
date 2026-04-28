# AGENTS.md — No Name

## Project Overview

**No Name** is a 2D cooperative platformer built with **Unity 2019.4.9f1**. Two players, connected by a rope, navigate six levels filled with saws, spikes, falling platforms, ice floors, and movable spike traps.

## How to Open and Build

1. Install **Unity 2019.4.9f1** (LTS) via Unity Hub.
2. Clone the repository and open the project folder in Unity Hub.
3. Open `Assets/Scenes/Menu.unity` to start from the main menu.
4. Press **Play** in the Unity Editor to test.
5. To build: **File → Build Settings**, add all scenes from `Assets/Scenes/`, and click **Build**.

### Scene Load Order (Build Settings)

1. `Menu` — Main menu (index 0, must be first)
2. `Level-1` through `Level-6` — Game levels
3. `Pause` — Loaded additively during gameplay
4. `YouLost` — Loaded additively during gameplay
5. `YouWin` — Loaded additively during gameplay

> `SampleScene` is unused and can be excluded from builds.

## Scripts Directory

```
Assets/Scripts/
├── Camera/
│   └── ThirdPersonCamera.cs    # Follows midpoint between both players
├── Character/
│   ├── PlayerData.cs            # Per-player config: player number, sprites, audio
│   ├── Abilities/
│   │   └── PickUpObjects.cs     # Pick up and drop objects with Fire1
│   ├── Health/
│   │   ├── HandleDeath.cs       # Triggers the "You Lost" menu on death
│   │   └── HealthAndDamage.cs   # HP, damage, invincibility frames, red flash
│   └── Movement/
│       ├── MovementManager.cs   # Aggregates all movement sources each frame
│       ├── InputMover.cs        # Horizontal input (keyboard/gamepad)
│       ├── JumpMover.cs         # Jump force on button press
│       ├── GravityMover.cs      # Constant downward gravity
│       ├── IceMover.cs          # Momentum-based sliding on ice floors
│       ├── RopeMover.cs         # Constrains movement when rope is taut
│       ├── PullRopeMover.cs     # Pull the other player toward you
│       ├── MoveWithFloor.cs     # Move with moving platforms
│       └── ColliderController.cs# Trigger handling: checkpoints, doors, ice
├── HealthBar/
│   ├── HealthBar.cs             # UI slider for player health
│   └── Billboard.cs             # Keeps health bar facing the camera
├── Level/
│   ├── LevelSystem.cs           # Detects current level, checks for next level
│   ├── LevelTimeScale.cs        # Pauses/resumes via Time.timeScale
│   ├── SpawnSystem.cs           # Checkpoint tracking and player respawn
│   └── WinSystem.cs             # Detects both players on exit door
├── LevelSpecific/
│   └── Level1/
│       └── RopeRenderer.cs      # Visual rope line between players
├── Menus/
│   ├── MainMenu.cs              # Main menu: level select, volume, quit
│   ├── PauseMenu.cs             # Pause overlay with resume/retry/options
│   ├── LostMenu.cs              # Death screen: continue or retry
│   ├── WinMenu.cs               # Level complete: next level or menu
│   ├── ToMainMenu.cs            # Button handler to return to main menu
│   └── ToPauseMenu.cs           # Listens for Escape/P to open pause
├── Objects/
│   ├── SawDamage.cs             # Damage on saw contact
│   ├── SpikeDamage.cs           # Damage on spike contact
│   ├── DamageSpace.cs           # Area that deals damage over time
│   ├── HealthSpace.cs           # Area that heals over time
│   ├── FallEffect.cs            # Falling platform: shake, fall, optional respawn
│   ├── PathFollower.cs          # Moves object along a node path
│   ├── Node.cs                  # Waypoint for PathFollower
│   ├── PickableObject.cs        # Object that can be picked up by players
│   ├── SoundEffect.cs           # Plays a one-shot sound effect
│   ├── LevelMusic.cs            # Sets background music volume
│   └── ChangingSigns.cs         # Toggleable skull/heart sign sprites
└── Platforms/
    ├── FallEffect.cs            # (see Objects/FallEffect.cs above)
    ├── DamageSpace.cs           # Area damage zone on platforms
    └── HealthSpace.cs           # Area heal zone on platforms
```

## Architecture

### Movement System

Movement uses a **component-based aggregation** pattern. `MovementManager` maintains a dictionary (`Vector3Stack`) where each mover script registers a 3-element `Vector3[]`:
- `[0]` — Static movement (applied directly)
- `[1]` — Dynamic movement (accumulated over time, e.g. gravity)
- `[2]` — Force movement (impulses like jumps)

Each frame, `MovementManager` sums all contributions and applies rope constraints via `RopeMover` before calling `CharacterController.Move()`.

### Scene Management

Levels load additively with `Pause`, `YouLost`, and `YouWin` overlay scenes. Menu scripts find their overlay GameObjects by searching scene root objects by name.

### Checkpoint System

`SpawnSystem` tracks each player's last checkpoint independently. When both players reach checkpoints in the same group (same parent), the checkpoint is "confirmed" (turns red) and becomes the respawn point.

## Coding Conventions

- **Language**: C# targeting .NET 4.x (Unity 2019.4 default)
- **Naming**: PascalCase for public fields, methods, and classes. camelCase for private fields. Prefix private fields with underscore where practical.
- **MonoBehaviour lifecycle**: Use `Start()` for initialization, `Update()` for per-frame logic, coroutines for timed sequences.
- **Tags**: `Player`, `SpawnPoint`, `ExitDoor`, `IceFloor`, `LevelExtras`, `PlayerInteractionZone`
- **Input**: Uses Unity's legacy Input Manager with named axes (`P1_Horizontal`, `P2_Horizontal`, `P1_Jump`, `P2_Jump`, `P1_Pull`, `P2_Pull`, `Fire1`).
- **XML doc comments**: All public classes and public methods should have `<summary>` comments.
- **No namespaces**: Scripts do not use namespaces (standard for small Unity projects).
- **Serialized fields**: Use `[SerializeField]` for private fields exposed to the Inspector. Use `public` fields only when other scripts need access.
