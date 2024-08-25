using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoostPosition : MonoBehaviour
{
    Vector3 Position;

    void Start()
    {
        Position = GetComponent<Transform>().position;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        while (other.tag != "Road")
        {
            Vector3 randomVector = new Vector3(Random.Range(Position.x + 5, Position.x - 5),
                Random.Range(Position.y + 5, Position.y - 5), Position.z);
            Position = randomVector;
        }
    }
}
