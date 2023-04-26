using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Car : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float acceleration;
    [SerializeField] float turnSpeed;
    
    private float steer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0f, 1f * steer * Time.deltaTime, 0f);

        speed += acceleration * Time.deltaTime;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    /*
     * Quick note regarding the canvas that is created (based on Zfold2):
     * Pos: Vector3(1104,884,0)
     * Size: Width=2208, Height=1768
     */
    public void Steer(int direction)
    {
        steer = turnSpeed * (float) direction;
    }
}