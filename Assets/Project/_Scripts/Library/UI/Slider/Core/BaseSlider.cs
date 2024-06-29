using System;
using UnityEngine;

namespace Project._Scripts.Library.UI.Slider.Core
{
  [DefaultExecutionOrder(1600)]
  public abstract class BaseSlider : MonoBehaviour
  {
    protected UnityEngine.UI.Slider Slider;

    protected virtual void Awake() => Slider = GetComponentInChildren<UnityEngine.UI.Slider>();
    public abstract void UIF_OnValueChanged();

  }
}
