#region usings

using UnityEngine;

#endregion

public class PauseScript : MonoBehaviour
{
    public GameObject[] PauseGameObjects;
    public GameObject[] PlayGameObjects;

    public bool GamePaused { get; private set; }

    void Update()
    {
        if(GamePaused)
            PauseGame();
        else
            PlayGame();
    }

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
        Time.timeScale = 0;
        SetObjectState(GamePaused);
    }

    private void PlayGame()
    {
        Time.timeScale = 1;
        SetObjectState(GamePaused);
    }

    private void SetObjectState(bool pause)
    {
        foreach (var o in PauseGameObjects) o.SetActive(pause);

        foreach (var o in PlayGameObjects) o.SetActive(!pause);
    }
}