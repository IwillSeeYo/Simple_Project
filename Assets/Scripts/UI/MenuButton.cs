using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private TimeController _time;

    private void Awake()
    {
        _time = new TimeController();
    }

    public void OnButtonClick()
    {
        _time.Pause();
    }

    public void OnButtonRelease()
    {
        _time.Resume();
    }
}
