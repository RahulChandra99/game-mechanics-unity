using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPA
{

    
    public class TargetCollision : MonoBehaviour
    {
        private int localScoreKeeper;
        private void OnCollisionEnter(Collision other)
        {
            
            
                if (other.gameObject.CompareTag("Arrow"))
                {
                     GameManager.score++;

                FullGameManager.totalScore = GameManager.score;

                    other.transform.parent = transform;

                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                    GetComponent<Rigidbody>().isKinematic = false;

                GetComponent<Collider>().enabled = false;

                    Destroy(gameObject, 1f);
                                
                            
                }      
            
        }
    }

}
