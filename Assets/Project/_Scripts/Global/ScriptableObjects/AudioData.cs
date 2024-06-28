using UnityEngine;

namespace Project._Scripts.Global.ScriptableObjects
{
  [CreateAssetMenu(fileName = "AudioData", menuName = "Game/Audio")]
  public class AudioData : ScriptableObject
  {
    #region Childs
    public AudioClip AudioClip;
    #endregion
    
    #region Fields
    [Header("Attributes")]
    public AudioType Type;
    [Range(0,1f)]public float Volume = .5f;

    [Range(-.5f,.5f)]
    public float PitchVariation;
    public enum AudioType
    {
      BGM,
      MainSfx,
      SecondaryEffect,
      SecondarySfx,
      Effect
    }
    #endregion
  }
}
