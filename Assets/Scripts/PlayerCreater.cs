using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerCreater : MonoBehaviour,ITouchObje<string>,IPlayerNumber<int>
{
    public GameObject[] Player;
    public GameObject Finish;
    public int[] haveAplayer = new int[16];
    private int playerNoMin;
    private int playerNo; 
    public int number;
    private int PlayerNumber;
    private int gameOverNumber;
    
    public void TakePlayerNumber(int PlayerNuber)
    {

        PlayerNumber = PlayerNuber;
    }
   
    IEnumerator GameOver(int  time)
    {

        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);

    }
    public  void TakeName(string objectName)
    {
        if (objectName == "Enemy")
        {
            haveAplayer[PlayerNumber]--;
            if (haveAplayer[PlayerNumber] == 0)
            {
                Player[PlayerNumber].SetActive(false);
            }
            for (int x = 0; x < haveAplayer.Length; x++)
            {
                if (haveAplayer[x] <= 0)
                {
                    gameOverNumber++;
                }
                if (gameOverNumber == 16)
                {
                    StartCoroutine(GameOver(2));

                }
            }
            gameOverNumber = 0;
        }
        
        else if (objectName=="Crew")
        {

            haveAplayer[PlayerNumber]++;
            

            for (int x = 0; x < haveAplayer.Length; x++)
            {
                if (haveAplayer[x] >= 2)
                {
                    playerNoMin++;
                }

                if (haveAplayer[x] >= 3)
                {
                    playerNo++;

                }

                if (haveAplayer[x] == 0 && x <= 3)
                {
                    Player[x].SetActive(true);



                    haveAplayer[x]++;

                    break;
                }

                if (x > 3 && x <= 7)
                {
                    if (playerNoMin >= 4 && haveAplayer[x] == 0)
                    {
                        Player[x].SetActive(true);
                        haveAplayer[x]++;

                        break;
                    }




                }
                if (x > 7 )
                {
                    if (playerNo >= 8 && haveAplayer[x] == 0)
                    {
                        Player[x].SetActive(true);
                        haveAplayer[x]++;

                        break;
                    }
                    if (playerNo == 16)
                    {
                        Finish.SetActive(true);
                        StartCoroutine(GameOver(5));
                    }




                }
                

            }
            playerNoMin = 0;
            playerNo = 0;
        }



    }
}
