using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionGuide : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] Transform Destiny;
    [SerializeField] Transform Player;
    Vector2 Origin, direction, destiny;
    void Start()
    {
        Origin = new Vector2();
        destiny = new Vector2(Destiny.position.x, Destiny.position.y);
    }


    void Update()
    {
        if(Destiny == null)
        {
            Destroy(gameObject);
        }
        Origin = new Vector2(Player.position.x, Player.position.y);
        direction = (destiny - Origin).normalized;
        transform.eulerAngles = new Vector3(0,0,Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg-90);
        direction = direction * radius + Origin;
        transform.position = new Vector3(direction.x, direction.y, 0)  ;
    }
}