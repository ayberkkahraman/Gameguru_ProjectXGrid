using Project._Scripts.GameCore.GridSystem.Generator;

namespace Project._Scripts.Library.UI.Slider.Sliders
{
  public class BorderOffsetSlider : Base.Slider
  {
    public override void UIF_OnValueChanged()
    {
      base.UIF_OnValueChanged();
      GridGenerator.GridData.BorderOffset = Slider.value;
    }
  }
}
