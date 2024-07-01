using System.Collections.Generic;
using UnityEngine;

namespace Project._Scripts.Global.Manager.Core
{
  [DefaultExecutionOrder(560)]
  public sealed class ManagerCore : MonoBehaviour{
  #region Fields
    public bool DestroyOnLoad = true;
    public static ManagerCore Instance;

    public List<MonoBehaviour> Managers;
  #endregion

  #region Singleton
    private void Awake()
    {
      if(!DestroyOnLoad) DontDestroyOnLoad(gameObject);
      
      if (Instance == null) Instance = this;
      else { Destroy(Instance); }
    }
  #endregion
    
    /// Get Instance for singleton access
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetInstance<T>() where T : MonoBehaviour
    {
      //CHECKS IF THE MANAGERS LIST CONTAINS THE "T" INSTANCE
      if (Managers.Exists(x => x as T != null))
      {
        //FINDS THE INSTANCE FOR ASSIGNING TO ACCESS
        return Managers.Find(x => x as T != null) as T;
      }
      Debug.LogError($"Managers list not contains the **{typeof(T)}**");

      return null;
    }
  }
}
