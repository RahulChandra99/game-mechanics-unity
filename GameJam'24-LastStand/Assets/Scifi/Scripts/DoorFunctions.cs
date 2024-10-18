using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFunctions : MonoBehaviour {

    static Animator Door_Anim;
    
    public GameObject Locker;
    public GameObject Sound;


    private void Awake()
    {
    Door_Anim = GetComponent<Animator>();

    }
  

   void OnTriggerEnter(Collider col)   
    {

        if(col.gameObject.tag == "Player")
        {

            Door_Anim.SetBool("Door_Open",true);
            Locker.SetActive(true);
            StartCoroutine(Timmer());
            // plays sound when door opens.
            // Sound.SetActive(true); 

        }
       

    }

    IEnumerator Timmer()
    {
       
        yield return new WaitForSeconds(4);
        Door_Anim.SetBool("Door_Open", false);
        Locker.SetActive(false);
        // plays sound when door closes
        // Sound.SetActive(false);


    }


}
	
	