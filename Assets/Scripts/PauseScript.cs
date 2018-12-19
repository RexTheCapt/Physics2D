#region usings

using UnityEngine;
using UnityEngine.UI;

#endregion

public class PauseScript : MonoBehaviour
{
    public GameObject[] PauseGameObjects;
    public GameObject[] PlayGameObjects;
    public GameObject SimulationTextGameObject;
    public Slider SimulationSpeedSlider;
    public float SimulationSpeed = 1f;

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

    public void SimulationSpeedSliderUpdate()
    {
        SimulationSpeed = SimulationSpeedSlider.value;

        SimulationTextGameObject.gameObject.GetComponent<Text>().text =
            string.Format("Game speed: {0:0.00}", SimulationSpeed);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        SetObjectState(GamePaused);
    }

    private void PlayGame()
    {
        Time.timeScale = SimulationSpeed;
        SetObjectState(GamePaused);
    }

    private void SetObjectState(bool pause)
    {
        foreach (var o in PauseGameObjects) o.SetActive(pause);

        foreach (var o in PlayGameObjects) o.SetActive(!pause);
    }
}