using UnityEngine;
using UnityEngine.Events;

namespace Project._Scripts.Library.UI.InputField.Core
{
  public class SubmitButton : MonoBehaviour
  {
    private Fields.Base.InputField _inputField;
    
    public UnityEvent OnSuccess;
    public UnityEvent OnFail;
    
    private void Awake() => _inputField = GetComponentInParent<Fields.Base.InputField>();
    
    public void UIF_BUTTON_Submit()
    {
      
    }
  }
}
