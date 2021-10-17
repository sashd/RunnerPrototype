using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player player;
    private Vector3 mousePos;
    private Vector3 initialMousePos;


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            initialMousePos = Input.mousePosition;
            player.StartMove();
        }

        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            var dif = initialMousePos.x - mousePos.x;
            player.Move(dif);

            initialMousePos = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            player.FinishMove();
        }
    }
        
}
