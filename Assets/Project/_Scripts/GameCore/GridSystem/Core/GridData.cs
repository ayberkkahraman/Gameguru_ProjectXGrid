namespace Project._Scripts.GameCore.GridSystem.Core
{
  public class GridData
  {
    public int GridSize;
    public float GridOffset;
    public float BorderOffset;

    public GridData(int gridSize, float gridOffset, float borderOffset)
    {
      GridSize = gridSize;
      GridOffset = gridOffset;
      BorderOffset = borderOffset;
    }
  }
}
