using System;
using TMPro;
using UnityEngine;

namespace Project._Scripts.Library.UI.InputField.Core
{
  public abstract class InputFieldBase : MonoBehaviour
  {
    protected TMP_InputField InputField;

    protected Action<string> OnValueChanged;
    protected Action<string> OnSubmit;
    protected Action<string> OnEndEdit;

    protected virtual void Awake() => GetComponent();
    protected virtual void OnEnable() => SubscribeEvents();
    protected void OnDisable() => UnSubscribeEvents();

    protected abstract void Change(string st);
    protected abstract void Submit(string str);
    protected abstract void End(string str);

    private void GetComponent()
    {
      TryGetComponent(out TMP_InputField inputField);

      InputField = inputField == null ? GetComponentInChildren<TMP_InputField>() : inputField;
    }
    private void SubscribeEvents()
    {
      OnValueChanged += Change;
      OnSubmit += Submit;
      OnEndEdit += End;
      
      InputField.onValueChanged?.AddListener((param) => OnValueChanged(param));
      InputField.onEndEdit?.AddListener((param) => OnEndEdit(param));
      InputField.onSubmit?.AddListener((param) => OnSubmit(param));
    }
    
    private void UnSubscribeEvents()
    {
      OnValueChanged -= Change;
      OnSubmit -= Submit;
      OnEndEdit -= End;
    }
  }
}
