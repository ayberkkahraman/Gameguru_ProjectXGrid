using Project._Scripts.GameCore.GridSystem.Generator;
using UnityEngine;

namespace Project._Scripts.Library.UI.InputField.Fields
{
  public class GridSizeField : Base.InputField
  {
    private void Set(string str)
    {
      int gridSize = Mathf.Clamp(int.Parse(str), GridGenerator.GridData.MinGridSize, GridGenerator.GridData.MaxGridSize);
      InputField.text = gridSize.ToString();
      GridGenerator.GridData.GridSize = gridSize;
    }
    protected override void Submit(string str) => Set(str);
    protected override void End(string str) => Set(str);
  }
}
