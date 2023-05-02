using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerCreater;
    public GameObject ObjeCreater;
    public int number;    
    int colorNumber;
    private SpriteRenderer renderer;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();

        PlayerCreater = GameObject.Find("players");
        ObjeCreater = GameObject.Find("objeCreater");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCreater.gameObject.GetComponent<IPlayerNumber<int>>().TakePlayerNumber(number);
        if (collision.gameObject.CompareTag("Crew"))
        {
            
            PlayerCreater.gameObject.GetComponent<ITouchObje<string>>().TakeName("Crew");
            
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {

            PlayerCreater.gameObject.GetComponent<ITouchObje<string>>().TakeName("Enemy");
          
        }

        if (collision.gameObject.CompareTag("Destroyer"))
        {

            ObjeCreater.gameObject.GetComponent<ITouchObje<string>>().TakeName("Destroyer");

        }
        colorNumber = PlayerCreater.GetComponent<PlayerCreater>().haveAplayer[number];
        if (colorNumber == 1)
        {
            renderer.color = Color.green;
        }
        if (colorNumber == 2)
        {
            renderer.color = Color.cyan;
        }
        else if (colorNumber == 3)
        {
            renderer.color = Color.blue;
        }
        else if (colorNumber >= 4)
        {
            renderer.color = Color.black;
        }
        Destroy(collision.gameObject);
    }
}
