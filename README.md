# SmoothPortals

## Setup
1. Import the project
2. Look at the demo scene to get an idea of what the project can do

## Usage
1. Drag the Portal prefab into your scene
2. Move, rotate and scale the portals to your desire
3. Attach the Portable script to any object that you want to be able to teleport through portals

## TODO (these are features which are currently missing and which I hope to implement in the future):
- Need to be able to handle all portal rotations (e.g. floor portals, ceiling portals)
- Design a more modular system to allow for more than two portals in a scene e.g.
  - Portal pairs (very simple, two-way always active, front and back)
  - Create sender/receiver on channel X
- Remove awkward Render Plane/Collidor plane solution and allow any portal shape or size
- Allow portal to be placed up against a wall and not have collidors behind the portal interfere with movement through the portal
- Objects that move through the portal should be teleported convincingly
  - a duplicate of the object needs to be created at other portal
  - moving objects will also need their motion to be rotated
