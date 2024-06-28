namespace Project._Scripts.Global.Interfaces
{
  public interface IAudioOwner
  {
    public IAudioOwner AudioOwner { get; set; }
    // public static AudioManager AudioManager => ManagerContainer.Instance.GetInstance<AudioManager>();
    // public void Play(string audioName) => AudioManager.PlayAudio(audioName);
  }
}
