//Used for wandering enemy with flashlight (The key difference between this and the enemyAI script is the flashlight toggle)
//and the color change on FPSTarget pickup

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingEnemyAI : MonoBehaviour
{
    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;

    public GameObject lightSource;
    public Transform fpsTarget;
    public Transform fpsWanderTarget;
    Rigidbody theRigidBody;
    //Renderer myRenderer;

    

    //private Light enemyLight;
    // Start is called before the first frame update
    void Start()
    {
       //myRenderer = GetComponent<Renderer>();
       theRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance) {
            //myRenderer.material.color = Color.yellow;
            lookAtPlayer();
            if (fpsTargetDistance < attackDistance) {
                //myRenderer.material.color = Color.red;
                attackPlease();
            }
        }
        
        else{

            //WandertoPlacePlease();

            //myRenderer.material.color = Color.blue;
            //enemyLight.color = Color.white;
          
        }
    }

    void lookAtPlayer() {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
         

            /*else if (isOn == true)
            {
                lightSource.SetActive(false);
                isOn = false;
            }*/
    }

    void attackPlease() {
        theRigidBody.AddForce(transform.forward * enemyMovementSpeed);
        //enemyLight.color = Color.red;
        //lightSource.SetActive(true);
    }
    void WandertoPlacePlease() {
        //Wander to location specified
        Quaternion rotation = Quaternion.LookRotation(fpsWanderTarget.position - transform.position);
        //Go to player position (useful for testing)
        //Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
    }
}

