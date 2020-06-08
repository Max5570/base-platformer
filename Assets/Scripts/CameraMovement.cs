using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraFollowDistance = 3;
    public float speed;
    
    private Player player;

    private void Start() 
    {
        player = GameManager.instance.player;
    }
    private void Update()
    {
        Vector2 position = transform.position;
        Vector2 playerPosition = player.transform.position;
        position.y = 0;
        playerPosition.y = 0;
        float distance = Vector2.Distance(position, playerPosition);

        if(distance > cameraFollowDistance)
        {
            Vector3 movePosition = position + (playerPosition - position).normalized * Time.deltaTime * (speed + (distance - cameraFollowDistance));
            movePosition.z = -100;
            movePosition.y = -1.16f;
            transform.position = movePosition;
        }
    }
}
