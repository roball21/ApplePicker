using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    // Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject badApplePrefab;

    // speed at which the AppleTree moves
    public float speed = 1f;

    // distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // chance thet the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // seconds between Apples instantiations
    public float appleDropDelay = 2f;

    public float tossHeight = 2f;

    public float tossDuration = 1f;


    // Start is called before the first frame update
    void Start()
    {
        // start dropping apples
        Invoke("DropApple", 2f);
        Invoke("DropBadApple", 11f);
    }

    void DropApple() 
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    void DropBadApple() 
    {
        GameObject badApple = Instantiate<GameObject>(badApplePrefab);
        StartCoroutine(TossBadApple(badApple));
        Invoke("DropBadApple", 11f);
    }
      IEnumerator TossBadApple(GameObject badApple)
    {
        Vector3 startPos = transform.position;
        Vector3 peakPos = startPos + Vector3.up * tossHeight;
        float elapsedTime = 0f;

        // Move up to the peak
        while (elapsedTime < tossDuration / 2)
        {
            badApple.transform.position = Vector3.Lerp(startPos, peakPos, (elapsedTime / (tossDuration / 2)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;
        Vector3 endPos = startPos;

        // Move down to the original position
        while (elapsedTime < tossDuration / 2)
        {
            badApple.transform.position = Vector3.Lerp(peakPos, endPos, (elapsedTime / (tossDuration / 2)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
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
        else if (Random.value < changeDirChance) {
            speed *= -1; // change direction
        }
    }
}
