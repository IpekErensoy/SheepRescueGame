using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour, IPointerClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerClick(PointerEventData eventData) // 1
    {
        SceneManager.LoadScene("Game"); // 2
    }

}
