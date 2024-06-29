using Project._Scripts.GameCore.GridSystem.Generator;
using Project._Scripts.Library.UI.InputField.Core;
using UnityEngine;

namespace Project._Scripts.Library.UI.InputField.Fields.Base
{
  public class InputField : InputFieldBase
  {
    public static string InputMessage { get; set; }
    protected override void Change(string str) {}
    protected override void Submit(string str) {}
    protected override void End(string str){}
  }
}
