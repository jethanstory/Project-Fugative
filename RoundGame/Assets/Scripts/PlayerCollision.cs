using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter (UnityEngine.Collision collisionInfo) 
    {
        if (collisionInfo.collider.name == "Enemy" || collisionInfo.collider.name == "WanderingEnemy" || collisionInfo.collider.name == "flyingEnemy" )
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(1);
            Debug.Log("HIT");
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}