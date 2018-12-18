#region usings

using UnityEngine;

#endregion

public class PauseScript : MonoBehaviour
{
    public GameObject[] PlayGameObjects;
    public GameObject[] PauseGameObjects;
    public bool GamePaused
    {
        get { return pause; }
    }

    private bool pause;

    public void Toggle()
    {
        pause = !pause;


    }
}