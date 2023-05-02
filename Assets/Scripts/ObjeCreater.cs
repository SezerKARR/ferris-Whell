using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjeCreater : MonoBehaviour, ITouchObje<string>
{
    public float x, y;
    public GameObject[] obje;
    public float spawnerTime = 1f;
    private float curretPlatformSpawnTimer;
    int[] value= { -1, 1 };
    int ObjectNumber;
    int destroyerNumber=0;
    public Text DestroyerNo;
    public void TakeName(string objectName)
    {
        destroyerNumber++;
        DestroyerNo.gameObject.SetActive(true);
    }
    void Update()
    {
        

        DestroyerNo.text = "" + destroyerNumber + "";
        if (Input.GetMouseButtonDown(0)&& destroyerNumber>0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                

                if (hit.collider.tag == "Enemy")
                {
                    Debug.Log(hit.collider);
                    Destroy(hit.collider);
                    destroyerNumber--;
                    if (destroyerNumber == 0)
                    {
                        DestroyerNo.gameObject.SetActive(false);
                    }
                }
            }
        }
        SpawnPlatforms();
    }
    void SpawnPlatforms()
    {
        curretPlatformSpawnTimer += Time.deltaTime;
        if (curretPlatformSpawnTimer >= spawnerTime)
        {

            Vector2 temp = transform.position;
            x = Random.Range(-1f, 1f);

            y = Mathf.Sqrt(1 - (x * x));
           
            int i = Random.Range(0, 2);
            
            temp.x = x;
            temp.y = (y * value[i])+1;

            GameObject newPlatform = null;
            ObjectNumber = Random.Range(0, obje.Length);
            if (ObjectNumber == 0)
            {
                ObjectNumber = Random.Range(0, obje.Length);
            }
            newPlatform = Instantiate(obje[ObjectNumber], temp, Quaternion.identity);
            curretPlatformSpawnTimer = 0;
        }
    }
}
