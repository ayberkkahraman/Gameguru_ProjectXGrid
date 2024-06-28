using System.Collections.Generic;
using Project._Scripts.Global.Interfaces;
using UnityEngine;

namespace Project._Scripts.Global.Manager.ManagerClasses
{
  [DefaultExecutionOrder(580)]
  public class DisposerManager : MonoBehaviour
  {
    public List<IDisposer> Disposers;
    private void Awake() => Disposers = new List<IDisposer>();
    private void OnDisable() => Disposers.ForEach(x => x.Dispose());
  }
}
