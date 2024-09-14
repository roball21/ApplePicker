using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    // Prefab for instantiating apples
    public GameObject applePrefab;

    // speed at which the AppleTree moves
    public float speed = 1f;

    // distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // chance thet the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // seconds between Apples instantiations
    public float appleDropDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple() 
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // changing direction
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); // move right
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); // move left
        }
        /*} else if (Random.value < changeDirChance) {
            speed *= -1; // change direction
        }*/
    }

    void FixedUpdate() {
        // random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance) {
            speed *= -1; // change direction
        }
    }
}
