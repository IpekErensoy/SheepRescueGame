using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public static UIManager Instance; // 1
    public Text sheepSavedText; // 2
    public Text sheepDroppedText; // 3
    public GameObject gameOverWindow; // 4

    void Awake()
    {
     Instance = this;   
    }

    // Update is called once per frame
    public void UpdateSheepSaved() // 1
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped() // 2
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }

}
