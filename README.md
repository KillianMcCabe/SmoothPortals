# SmoothPortals

## TODO:
- Need to be able to handle all portal rotations (e.g. floor portals, ceiling portals)
- Design a more modular system to allow for more than two portals in a scene e.g.
  - Portal pairs (very simple, two-way always active, front and back)
  - Create sender/receiver on channel X
- Add different shapes e.g. oval portal..
- Let user select/create their own frame (or use no frame)
- Remove awkward Render Plane/Collidor plane solution. A proper implementation would require just one simple plane; any shape, size and rotation.
  Note: do this by allowing the current frame to 'morph' it's shape when the user is colliding with it, i.e. swap plane mesh out with an inverted cube (5-sides)
- Need some portal camera script to adjust nearclip plane onto portal render plane
- Objects that move through the portal should be teleported
  - needs to look convincing from all angles
