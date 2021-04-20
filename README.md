# 3D-Backwards-Shooter
1 day = 4 hours
1 b.

    2 days for research and diagram adjustments, if necessary.
    Created a diagram of project and class structure ./Diagrams/3D Backwards shooter.drawio

1 c.

    5 days for the project

# Features based on short descrition and questions:

Enemy module

    Object pool for enemies
    Configurable enemies - reuse from pool
    Movement behaviour
    Attach behaviour

Character module

    Object pool for bullets
    Configurable bullets - reuse from pool
    Movement behaviour
    Shoot behaviour
    Assailed behaviour

Obstacle module

    Object pool for obstacles
    Configurable obstacles - reuse from pool
    Collision behaviour

Game configuration module

    Game configuration
        Game duration
    Enemy configuration
        Number of enemies per game
        Enemy prefab
        Enemy speed, random between [x-y]
        Number of enemies per line, random between [x-y]
        Interval for instantiating enemies, random between [x-y]
    Character configuration
        Speed backward
        Waiting range to shoot
    Bullet configuration
        Bullet prefab
        Bullet destroy - seconds
        Speed - velocity
    ObstacleConfiguration
        Speed, random between [x-y]
        Waiting range to instantiate, random between [x-y]
        Obstacle size, , random between [x-y]Vector3

Input module - Command design pattern

GameManager - It handles game states

ScreenManager - StartScreen, GameScreen, EndScreen

![Diagram](https://user-images.githubusercontent.com/37576450/115350810-3cbfe800-a1be-11eb-850e-db2fcf910eb2.png)

