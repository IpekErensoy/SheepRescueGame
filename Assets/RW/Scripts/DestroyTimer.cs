using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public float timeToDestroy;

    void Start()
    {
        
     Destroy(gameObject, timeToDestroy);
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
