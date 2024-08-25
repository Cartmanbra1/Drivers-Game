using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Driver : MonoBehaviour
{
    [SerializeField] float SteerSpeed = 181f;
    [SerializeField] float MoveSpeed = 20f;
    [SerializeField] float SlowSpeed = 15f;
    [SerializeField] float BoostSpeed = 30f;
    float timer = 0;
    Vector3 Position;

    void Start()
    {
        Position = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        float SteerAmount = Input.GetAxis("Horizontal") * SteerSpeed * Time.deltaTime;
        float MoveAmount = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -SteerAmount);
        transform.Translate(0, MoveAmount, 0);

        if (MoveSpeed == BoostSpeed || MoveSpeed == SlowSpeed)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 2)
        {
            MoveSpeed = 20f;
            timer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Speed Up")
        {
            MoveSpeed = BoostSpeed;
            Vector3 randomVector = new Vector3(Random.Range(Position.x + 5, Position.x - 5),
                Random.Range(Position.y + 5, Position.y - 5), Position.z);
            other.transform.position = randomVector; 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        MoveSpeed = SlowSpeed;
    }
}
