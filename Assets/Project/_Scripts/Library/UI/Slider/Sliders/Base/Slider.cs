using Project._Scripts.Library.UI.Slider.Core;
using TMPro;
using UnityEngine;

namespace Project._Scripts.Library.UI.Slider.Sliders.Base
{
  public class Slider : BaseSlider
  {
    public Vector2 Limits;
    public TMP_Text ValueText;

    private void OnEnable()
    {
      Slider.minValue = Limits.x;
      Slider.maxValue = Limits.y;
      
      Slider.value = Slider.minValue;
      ValueText.text = $"{Slider.value:0.00}";
    }
    public override void UIF_OnValueChanged(){ValueText.text = $"{Slider.value:0.00}";}
  }
}
