using System.Collections;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float moveDistance = 4f;   // how far to move right
    public float moveSpeed = 1f;      // how fast it moves
    public float waitTime = 2f;       // how long to wait before going back

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.right * moveDistance;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                StartCoroutine(WaitThenSwitch(false));
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPos) < 0.01f)
            {
                StartCoroutine(WaitThenSwitch(true));
            }
        }
    }

    IEnumerator WaitThenSwitch(bool goingRight)
    {
        // stop Update() from spamming coroutines
        enabled = false;
        yield return new WaitForSeconds(waitTime);
        movingRight = goingRight;
        enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
