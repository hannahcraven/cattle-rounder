using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowControl : MonoBehaviour
{
    public float speed = 20f;
    public float turnspeed = 8.0f;
    private float spawnRate = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Make cow spawn
        StartCoroutine(SpawnCows());

    }

    IEnumerator SpawnCow()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, Cows.Count);
            Instantiate(cows[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Make cow run into distance (other side of screen)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //Make cow zig zag while moving forward
        transform.Translate(Vector3.left * turnspeed * Time.deltaTime);
        transform.Translate(Vector3.right * turnspeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cow"))
        {
            Destroy(gameObject);
        }
    }
}
