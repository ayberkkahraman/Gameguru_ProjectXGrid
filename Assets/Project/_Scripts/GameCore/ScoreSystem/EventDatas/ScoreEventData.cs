using Project._Scripts.Global.EventData.ScriptableObjects;
using Project._Scripts.Library.SubSystem.CustomDelegate;
using UnityEngine;

namespace Project._Scripts.GameCore.ScoreSystem.EventDatas
{
  [CreateAssetMenu(fileName = "Score", menuName = "GameCore/EventData/Score")]
  public class ScoreEventData : EventData
  {
    public static int CurrentScore { get; set; }

    public delegate void OnScoreChanged(int value);
    public static CustomDelegate<OnScoreChanged> OnScoreChangedHandler;
    public override void Execute()
    {
      CurrentScore = 0;
      
      OnScoreChangedHandler = new CustomDelegate<OnScoreChanged>();
      OnScoreChangedHandler.AddDelegate((value) => CurrentScore += value, 0);
    }
    public override void Dispose() => OnScoreChangedHandler = null;
  }
}
