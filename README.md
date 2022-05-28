# Hyper-Casual Game Framework
This framework is particularly designed for the mobile hyper-casual games. One should be able to download this package and only focus on the gameplay part.
  

## Framework scripts
```
[Admin]
  ├─ Admin.cs
  ├─ Prefs.cs
  ├─ StateTransitionBase.cs
  └─ HapticManager.cs
  
[Level]
  ├─ LevelManager.cs
  └─ LevelLoaderBase.cs

[UI]
  ├─ UIPositions.cs
  └─ UIUtils.cs
```  

## Requirements (scripts/game objects)
One needs to implement some required scripts and create game objects in the scene.

### Required scripts
```
[GamePlay]
  ├─ (by case)

[Admin]
  ├─ Initializer.cs
  └─ StateTransition.cs

[Level]
  ├─ LevelConfigJson.cs
  ├─ LevelInventory.cs
  └─ LevelLoader.cs
  
[UI]
  └─ UIManager.cs
```

### In-scene game objects
* Admin (`Admin.cs`)
* UIManager (`UIManager.cs`)
* LevelInventory (`LevelInventory.cs`)
* HapticManager (`HapticManager.cs`)
* Initializer (`Initializer.cs`)

##  How to use
Usages of some components of framework.

### UI