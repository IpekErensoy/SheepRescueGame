using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public MeshRenderer model; // 1
    public Color normalColor; // 2
    public Color hoverColor; // 3

    void Start()
    {
        model.material.color = normalColor;
    }

    // Update is called once per frame
    public void OnPointerEnter(PointerEventData eventData) // 1
    {
        model.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData) // 2
    {
        model.material.color = normalColor;
    }

}
