using System.Collections.Generic;
using System.Linq;

namespace Project._Scripts.GameCore.GridSystem.GridContainer
{
  public static class GridContainer
  {
    public static LinkedList<Grid> CheckForGrids(List<Grid> grids)
    {
      LinkedList<Grid> activeNeighbours = new LinkedList<Grid>();
      
      grids.ForEach(x => activeNeighbours.AddFirst(x));
      
      grids.ForEach(x =>
      {
        foreach (var neighbourGrid in x.NeighbourGrids
                   .Select(neighbourCollider => neighbourCollider.GetComponent<Grid>())
                   .Where(neighbourGrid => neighbourGrid != null && neighbourGrid.IsActive))
        {
          activeNeighbours.AddLast(neighbourGrid);
        }
      });

      return activeNeighbours;
    }
  }
}
