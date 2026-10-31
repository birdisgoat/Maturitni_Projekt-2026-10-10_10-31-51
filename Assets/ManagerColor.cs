using UnityEngine;

public class ManagerColor : MonoBehaviour
{
    [SerializeField] private Color blueColor = Color.blue;
    [SerializeField] private Color redColor = Color.red;

    void Start()
    {
        Renderer[] renderers = FindObjectsByType<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            if (renderer.gameObject.layer == LayerMask.NameToLayer("Blue"))
            {
                renderer.material.color = blueColor;
            }
            else if (renderer.gameObject.layer == LayerMask.NameToLayer("Red"))
            {
                renderer.material.color = redColor;
            }
        }
    }
}
