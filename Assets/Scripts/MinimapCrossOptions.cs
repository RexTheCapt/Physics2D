#region Usings

using UnityEngine;

#endregion

public class MinimapCrossOptions : MonoBehaviour
{
    [Range(0f, 1f)] public float alpha = 1f;
    public GameObject[] SquareGameObjects;

    void Update()
    {
        foreach (GameObject squareGameObject in SquareGameObjects)
        {
            Renderer renderer = squareGameObject.GetComponent<Renderer>();
            Material material = renderer.material;
            Color color = material.color;

            color.a = alpha;

            material.color = color;
        }
    }
}