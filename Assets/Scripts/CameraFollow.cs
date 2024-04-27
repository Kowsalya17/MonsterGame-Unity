using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    [SerializeField] private float minX, maxX;
   


    void Start()
    {
        //To find the transform position of the player when it's in private
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (!player)
            return;

        //Getting the same pos for Camera as Player 
        tempPos = transform.position;
        tempPos.x = player.position.x;
        // to not cross over the BG 
        if(tempPos.x < minX)
            tempPos.x = minX;

        if(tempPos.x > maxX)
            tempPos.x = maxX;  
           
       transform.position = tempPos;
    }
}


//SceneManager.LoadScene("GameOver");