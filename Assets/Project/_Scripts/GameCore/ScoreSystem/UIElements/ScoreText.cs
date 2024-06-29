using Project._Scripts.GameCore.ScoreSystem.EventDatas;
using TMPro;
using UnityEngine;

namespace Project._Scripts.GameCore.ScoreSystem.UIElements
{
  [DefaultExecutionOrder(1500)]
  public class ScoreText : MonoBehaviour
  {
    private TMP_Text _text;

    private void Awake() => _text = GetComponent<TMP_Text>();
    private void OnEnable() => ScoreEventData.OnScoreChangedHandler.AddDelegate(UpdateText, 1);
    private void OnDisable() => ScoreEventData.OnScoreChangedHandler.RemoveDelegate(UpdateText);
    private void UpdateText(int value) => _text.text = ScoreEventData.CurrentScore.ToString();
  }
}
