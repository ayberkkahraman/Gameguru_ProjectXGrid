using Project._Scripts.GameCore.GridSystem.Generator;
using UnityEngine;

namespace Project._Scripts.Library.UI.InputField.Fields
{
  public class GridSizeField : Base.InputField
  {
    protected override void Change(string str) { GridGenerator.GridData.GridSize = (int)Mathf.Clamp(int.Parse(str), 3f, 24f);}
    protected override void Submit(string str) { GridGenerator.GridData.GridSize = (int)Mathf.Clamp(int.Parse(str), 3f, 24f);}
    protected override void End(string str){GridGenerator.GridData.GridSize = (int)Mathf.Clamp(int.Parse(str), 3f, 24f);}
  }
}
