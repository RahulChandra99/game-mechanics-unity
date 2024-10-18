using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPA
{
    public class GameManager : MonoBehaviour
    {


        public Text scoreText;
        public static int score;
        public Text timerText;
        public static float timer;

        
        

        public static bool gameStarted = false;

        public GameObject childBow;

        public GameObject crossHair;
        

        private void Start()
        {
            timer = 15f;

            
            UpdateScoreBoard();
        }

        private void Update()
        {
            
           
            if(PlayerMovement.canMove == false) //timer starts decrementing
            {
                timer -= Time.deltaTime;

                UpdateScoreBoard();
            }

            if(timer <=0)
            {
                EndGame(); // player out of time 
            }

           
        }

        void UpdateScoreBoard()
        {
            scoreText.text = score + " Targets"; // displaying score

            timerText.text = Mathf.RoundToInt(timer) + " seconds";       //displaying time 
        }

        void StartGame()
        {
            score = 0;
            

        }

        void EndGame()
        {
            PlayerMovement.canMove = true;
            
                childBow.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);

            crossHair.SetActive(false);



        }
    }
}


