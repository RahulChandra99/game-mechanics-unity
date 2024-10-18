using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FPA
{
    public class FullGameManager : MonoBehaviour
    {
        public Text totalScoreText;
        public static int totalScore;
        public GameObject levelCompleteCanvas;

        
        public GameObject welcomeScreen;

        private void Start()
        {
            


        }

        // Update is called once per frame
        void Update()
        {

            if(GameManager.score <= 0)
            {

            }

            
            if(GameManager.timer <=0)
            {

                levelCompleteCanvas.SetActive(true);
                totalScoreText.text = "Current Score : " + totalScore;

            }
        }

        public void PreviousMenu()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadSceneAsync("MainMenu");
            }
        }

        
    }
}

