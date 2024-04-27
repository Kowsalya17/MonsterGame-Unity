using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
        void Start()
    {
        
    }

    void Update()
    {
        Vector2 pos = transform.position;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;
       transform.position = pos;
    }
}
