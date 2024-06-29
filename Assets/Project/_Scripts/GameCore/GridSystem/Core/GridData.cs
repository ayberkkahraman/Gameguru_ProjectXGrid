namespace Project._Scripts.GameCore.GridSystem.Core
{
  public class GridData
  {
    public int GridSize;
    public float GridOffset;
    public float BorderOffset;

    public int MinGridSize = 3;
    public int MaxGridSize = 24;

    public GridData(int gridSize, float gridOffset, float borderOffset)
    {
      GridSize = gridSize;
      GridOffset = gridOffset;
      BorderOffset = borderOffset;
    }
  }
}
