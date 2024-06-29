using System;
using System.Collections.Generic;

namespace Project._Scripts.Library.SubSystem.CustomDelegate
{
  public class CustomDelegate<T>
  {
    private SortedDictionary<int, List<T>> delegates = new SortedDictionary<int, List<T>>();

    public void AddDelegate(T del, int priority)
    {
      if (!delegates.ContainsKey(priority))
      {
        delegates[priority] = new List<T>();
      }
      delegates[priority].Add(del);
    }

    public void RemoveDelegate(T del)
    {
      foreach (var key in delegates.Keys)
      {
        if (delegates[key].Contains(del))
        {
          delegates[key].Remove(del);
          if (delegates[key].Count == 0)
          {
            delegates.Remove(key);
          }
          break;
        }
      }
    }

    public void InvokeAll(params object[] args)
    {
      foreach (var priority in delegates.Keys)
      {
        foreach (var del in delegates[priority])
        {
          ((Delegate)(object)del).DynamicInvoke(args);
        }
      }
    }
  }
}
