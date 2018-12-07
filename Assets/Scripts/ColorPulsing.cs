#region Usings

using UnityEngine;

#endregion

public class ColorPulsing : MonoBehaviour
{
    private bool fadeUp = true;
    public float timer;
    public float timerMin = 0f;
    public float timerMax = 5f;

    void Update()
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;

        if (fadeUp)
            timer += Time.deltaTime;
        else
            timer -= Time.deltaTime;

        if (timer > timerMax)
            fadeUp = false;
        else if (timer < timerMin)
            fadeUp = true;

        color.a = timer / timerMax;

        gameObject.GetComponent<Renderer>().material.color = color;
    }
}