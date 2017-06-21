# SmoothPortals

## TODO:
- Need to be able to handle all portal roations (e.g. floor portals, ceiling portals)
- Design a more modular system e.g.
  - Portal pairs (very simple, two-way always active, front and back)
  - Create sender/receiver on channel X
- Add different shapes e.g. oval portal..
- Let user select/create their own frame (or use no frame)
- Remove awkward Render Plane/Collidor plane solution. A proper implementation would require just one simple plane; any shape, size and rotation.
  Note: do this by allowing the current frame to 'morph' it's shape when the user is colliding with it, i.e. swap plane mesh out with an inverted cube (5-sides)
