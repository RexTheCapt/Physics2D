#region Usings

using UnityEngine;

#endregion

public class ExitGame : MonoBehaviour
{
    public float exitTime = 5f;
    private float timer;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}