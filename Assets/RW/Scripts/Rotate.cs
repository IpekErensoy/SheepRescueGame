using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vector3 rotationSpeed;   
     
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
