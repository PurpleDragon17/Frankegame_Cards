using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code made with help Calandra
public class DragAndDrop : MonoBehaviour
{
    //input the dimensions of the gameobject
    [SerializeField] float objectHeight;
    [SerializeField] float objectWidth;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) //if the player is clicking
        {
            Vector2 pos = transform.position;
            //get the mouse position
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition); //translate the mouse position

            //check if the mouse position is over the object (within boundaries set)
            if ((-(objectWidth / 2) <= mouse.x - pos.x && mouse.x - pos.x <= (objectWidth / 2)) && (-(objectHeight / 2) <= mouse.y - pos.y && mouse.y - pos.y <= (objectHeight / 2)))
            {
                //move the gameobject
                transform.position = new Vector3(mouse.x, mouse.y, -0.001f);
            }
        }

    }
}
