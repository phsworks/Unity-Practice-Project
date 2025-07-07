using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public GameBehaviour GameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            GameManager.Items += 1;
        }
  }

  // Update is called once per frame
  void Update()
    {

    }
}
