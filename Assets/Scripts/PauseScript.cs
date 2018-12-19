#region usings

using UnityEngine;

#endregion

public class PauseScript : MonoBehaviour
{
    public GameObject[] PauseGameObjects;
    public GameObject[] PlayGameObjects;

    public bool GamePaused { get; private set; }

    public void Toggle()
    {
        GamePaused = !GamePaused;

        if (!GamePaused)
            PlayGame();
        else
            PauseGame();
    }

    private void PauseGame()
    {
        SetObjectState(GamePaused);
    }

    private void PlayGame()
    {
        SetObjectState(GamePaused);
    }

    private void SetObjectState(bool pause)
    {
        foreach (var o in PauseGameObjects) o.SetActive(pause);

        foreach (var o in PlayGameObjects) o.SetActive(!pause);
    }
}