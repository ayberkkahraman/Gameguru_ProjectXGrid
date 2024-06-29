using System;
using System.Collections.Generic;
using Project._Scripts.Global.Manager.ManagerClasses;
using UnityEngine;

namespace Project._Scripts.Global.EventData.Core
{
  [DefaultExecutionOrder(620)]
  public class EventDataExecuter : MonoBehaviour
  {
    public List<ScriptableObjects.EventData> EventDatas;
    private void Awake() => EventDatas.ForEach(x => Manager.Core.ManagerCore.Instance.GetInstance<DisposerManager>().Disposers.Add(x));
    private void OnEnable() => EventDatas.ForEach(x => x.Execute());
  }
}
