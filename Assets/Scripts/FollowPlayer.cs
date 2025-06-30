using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 cameraOffset = new Vector3(0f, 1.2f, -2.6f);

    public Transform _target;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = _target.TransformPoint(cameraOffset);
        this.transform.LookAt(_target);
    }
}
