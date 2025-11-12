using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        var players = FindObjectsOfType<MusicPlayer>();
        if (players.Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
