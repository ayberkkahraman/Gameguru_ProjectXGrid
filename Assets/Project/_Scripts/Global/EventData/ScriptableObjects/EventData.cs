using Project._Scripts.Global.Interfaces;
using UnityEngine;

namespace Project._Scripts.Global.EventData.ScriptableObjects
{
  public abstract class EventData : ScriptableObject, IDisposer
  {
    public abstract void Execute();
    public abstract void Dispose();
  }
}
