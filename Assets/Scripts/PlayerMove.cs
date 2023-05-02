using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    public Button rotationButton;
    private bool directionofRotation;
    void Start()
    {      
        Button btn = rotationButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);        
    }
    void TaskOnClick()
    {
        directionofRotation = !directionofRotation;

    }
    private void Update() {
        
            if (directionofRotation == true)
            {

                transform.RotateAround(new Vector2(0, 1), Vector3.forward, -100 * Time.deltaTime);
            }
            else
            {
                transform.RotateAround(new Vector2(0, 1), Vector3.forward, 100 * Time.deltaTime);
            }
        
    }
}
