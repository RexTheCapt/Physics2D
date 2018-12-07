#region Usings

using UnityEngine;
using UnityEngine.UI;

#endregion

public class ExitGame : MonoBehaviour
{
    public float exitTime = 5f;
    public Text QuitText;
    private float timer;

    private void Start()
    {
        QuitText.color = new Color(255, 255, 255, timer / exitTime);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            timer += Time.deltaTime;
        else
            timer -= Time.deltaTime;

        if (timer > exitTime)
        {
            timer = exitTime;
            QuitText.color = Color.red;
            Application.Quit();
        }
        else if (timer > 0)
        {
            QuitText.color = new Color(255, 255, 255, timer / exitTime);
        }
        else if (timer < 0)
        {
            timer = 0;
        }
    }
}