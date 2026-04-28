# No Name

A 2D cooperative platformer built with Unity where two players, connected by a rope, must navigate through six increasingly challenging levels filled with hazards, puzzles, and obstacles.

## Gameplay

- **Two-player co-op**: Both players share the screen and are physically connected by a rope that constrains their movement.
- **Six levels**: Each level introduces new mechanics and hazards — saws, spikes, falling platforms, ice floors, and movable spike traps.
- **Checkpoint system**: Color-coded checkpoints (blue → green → red) track each player's progress independently and sync when both players reach the same checkpoint group.
- **Health system**: Each player has a health bar. Taking damage triggers invincibility frames and a red flash effect. Losing all health opens the "You Lost" menu.
- **Win condition**: Both players must stand on the exit door simultaneously to complete a level.

## Controls

| Action       | Player 1         | Player 2         |
|--------------|------------------|------------------|
| Move         | `P1_Horizontal`  | `P2_Horizontal`  |
| Jump         | `P1_Jump`        | `P2_Jump`        |
| Pull rope    | `P1_Pull`        | `P2_Pull`        |
| Pick up      | `Fire1`          | `Fire1`          |
| Pause        | `Escape` / `P`   | `Escape` / `P`   |

> Input bindings are configured in Unity's Input Manager (`ProjectSettings/InputManager.asset`).

## Project Structure

```
Assets/
├── Animations/       # Animator controllers and animation clips
│   ├── Checkpoints/  # Checkpoint light animations
│   ├── Player 1/     # Player 1 walk, jump, idle, air animations
│   ├── Player 2/     # Player 2 walk, jump, idle, air animations
│   ├── Saw/          # Saw rotation animation
│   └── Spikes/       # Movable spike animations (Small, Medium, Large, Inverted)
├── Audio/            # Sound effects and background music
├── Images/           # Background images
├── Materials/        # Materials for level tiles, spikes, ice, and doors
├── Prefabs/          # Reusable game objects
│   ├── GlobalLevels/ # Shared level building blocks (platforms, spike holders, doors)
│   ├── MovableSpikes/# Animated spike trap prefabs
│   └── Torch/        # Decorative torch prefab with animation
├── Scenes/           # Unity scenes
│   ├── Menu.unity    # Main menu
│   ├── Level-1..6    # Game levels
│   ├── Pause.unity   # Pause overlay (loaded additively)
│   ├── YouLost.unity # Death/retry overlay
│   └── YouWin.unity  # Level complete overlay
├── Scripts/          # C# game scripts (see AGENTS.md for details)
├── Sprites/          # 2D sprite assets for players, UI, and objects
└── Textures/         # Tile textures for rocks, ice, spikes, and checkpoints
```

## Requirements

- **Unity 2019.4.9f1** (LTS) or compatible version
- No additional packages beyond the defaults and TextMesh Pro

## Getting Started

1. Clone the repository
2. Open the project folder in Unity Hub
3. Open `Assets/Scenes/Menu.unity` to start from the main menu
4. Press **Play** in the Unity Editor

## Screenshots

> _Add screenshots of gameplay here._

## License

This project does not currently specify a license.
