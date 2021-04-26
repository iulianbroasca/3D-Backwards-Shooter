# 3D-Backwards-Shooter
    To move the character press on the road.

1 b.

    2 days for research and diagram adjustments, if necessary.
    Created a diagram of project and class structure ./Diagrams/3D Backwards shooter.drawio

1 c.

    5 days for the project

1 day = 4 hours

![Diagram V2](https://user-images.githubusercontent.com/37576450/115917848-6c514780-a47f-11eb-84b7-f2dbe6d2566e.png)
# Adjustments in Project settings:
    Player -> Company name, Product name, Version
    Physics -> Layer collision matrix
    Script execution order
    Tags and layers
1 g. 
# Instructions for Game Designer:

    The configuration files are in Resources/Configurations folder. 
    Wherever there is an interval, a value will be randomly extracted each time. [minimum, maximum]. 
    Some configurations have been restricted by the Min, Range attributes.
    Instructions have also been added on variables. (TooltipAttribute)
![image](https://user-images.githubusercontent.com/37576450/115886994-25049000-a45a-11eb-93b0-271c39b83f7a.png)
![image](https://user-images.githubusercontent.com/37576450/115911948-68212c00-a477-11eb-94b6-2827ac73079e.png)

Bullet configuration 

![image](https://user-images.githubusercontent.com/37576450/115887868-06eb5f80-a45b-11eb-8095-9e1761971122.png)

    Bullet component - Assign the prefab that contains the BulletComponent.
    Bullet life duration - The life of the bullet after it was instantiated. (seconds)
    Bullet speed - The force to be applied to the bullet.
    Waiting time next bullet - The waiting time until the next bullet appears. (seconds)
Character configuration 

![image](https://user-images.githubusercontent.com/37576450/115887995-1f5b7a00-a45b-11eb-8a84-71fba3776f52.png)

    Lateral speed - Movement speed for the left and right.
Enemy configuration

![image](https://user-images.githubusercontent.com/37576450/115888053-2a160f00-a45b-11eb-825c-eb9ce95627ca.png)

    Enemy component - Assign the prefab that contains the EnemyComponent.
    Number enemies in game - The total number of enemies that will be in the game.
    Death duration - Duration until the enemy disappears. (seconds)
    Speed - The default speed of the enemy.
    Boost - Extra applied speed when the character touches a wall.
    Number enemies per line - The number of enemies that will be instantiated in line.
    Waiting time instantiating enemies - The waiting time until the next enemies will appear in scene. (seconds)
    
Game configuration

![image](https://user-images.githubusercontent.com/37576450/115888300-706b6e00-a45b-11eb-9b1d-b372ab766a55.png)

    Road width - Influences the width of the road. (meters)
    Game duration - Time until the end of the game. (seconds)
    Waiting time until game start - Counter before the game starts. (seconds)
    
Obstacle configuration

![image](https://user-images.githubusercontent.com/37576450/115888382-8842f200-a45b-11eb-95ed-cf71be455b55.png)

    Obstacle component - Assign the prefab that contains the ObstacleComponent.
    Speed - The speed of the obstacle.
    Obstacle life duration - The life of the bullet after it was instantiated. (seconds)
    Waiting time instantiating obstacle - The waiting time until the next obstacles will appear in scene. (seconds)
    Obstacle size - The size of the obstacle.

# Asset store:
    https://assetstore.unity.com/packages/3d/characters/humanoids/adventurer-blake-158728


# Features based on short description and questions:

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

First diagram
![Diagram](https://user-images.githubusercontent.com/37576450/115350810-3cbfe800-a1be-11eb-850e-db2fcf910eb2.png)

