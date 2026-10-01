using UnityEngine;

public class weaponScript : MonoBehaviour
{
    float destroyTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destroyTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;

        if (destroyTime < 0)
        {
            Destroy(gameObject);
            destroyTime = 2;

        }
    }
}
