using UnityEngine;

public class Oscilator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [SerializeField] float speed;

    Vector3 startingPos;
    float movementFactor;
    Vector3 endPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPos = transform.position;
        endPos = startingPos + movementVector;
    }

    // Update is called once per frame
    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(startingPos, endPos, movementFactor);
    }
}
