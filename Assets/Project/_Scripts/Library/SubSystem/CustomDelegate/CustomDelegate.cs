using System;
using System.Collections.Generic;

namespace Project._Scripts.Library.SubSystem.CustomDelegate
{
  public class CustomDelegate<T>
  {
    private readonly SortedDictionary<int, List<T>> _delegates = new(); //Holds the delegates with desired priorities

    public void AddDelegate(T del, int priority)
    {
      if (!_delegates.ContainsKey(priority))
      {
        _delegates[priority] = new List<T>();
      }
      _delegates[priority].Add(del);
    }

    public void RemoveDelegate(T del)
    {
      foreach (var key in _delegates.Keys)
      {
        if (!_delegates[key].Contains(del))
          continue;
        
        _delegates[key].Remove(del);
        if (_delegates[key].Count == 0)
        {
          _delegates.Remove(key);
        }
        break;
      }
    }

    /// <summary>
    /// Invokes the given delegates with their invoke priorities
    /// </summary>
    /// <param name="args"></param>
    public void InvokeAll(params object[] args)
    {
      foreach (var priority in _delegates.Keys)
      {
        foreach (var del in _delegates[priority])
        {
          ((Delegate)(object)del).DynamicInvoke(args);
        }
      }
    }
  }
}
