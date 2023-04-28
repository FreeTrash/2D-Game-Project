using UnityEngine;
using TMPro;

public class ChangeTextColorOnHover : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public Color hoverColor;

    private Color defaultColor;

    private void Start()
    {
        defaultColor = textMesh.color;
    }

    private void OnMouseEnter()
    {
        textMesh.color = hoverColor;
    }

    private void OnMouseExit()
    {
        textMesh.color = defaultColor;
    }
}
