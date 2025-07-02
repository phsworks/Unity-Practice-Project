using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float OnScreenDelay = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, OnScreenDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
