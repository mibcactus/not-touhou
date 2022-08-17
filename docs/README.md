# Not Touhou!

## GraphicsManager
Manages graphics for all entities and tiles


## entity
Base class for all moving entities
### SetTexture
Self explanatory
### CheckPosition
Ensures the entity doesn't move past the walls

## Player
Inherits from entity
### Attack
Launches an attack!
For now, it only prints to the console :)

## Bullet
Inherits from entity
### CheckPosition
Boundary changed to just outside the visual area.

