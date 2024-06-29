using System;
using System.Globalization;
using Project._Scripts.GameCore.GridSystem.Generator;
using UnityEngine;

namespace Project._Scripts.Library.UI.Slider.Sliders
{
  public class GridOffsetSlider : Base.Slider
  {
    public override void UIF_OnValueChanged()
    {
      base.UIF_OnValueChanged();
      GridGenerator.GridData.GridOffset = Slider.value;
    }
  }
}
