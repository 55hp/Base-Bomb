using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        if(speed == 0)
        {
            speed = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.down * speed * Time.deltaTime;
    }

    public void SetSpeed(float amount)
    {
        speed = amount;
    }

    public void BoostSpeed(float boostAmount)
    {
        speed += (speed / 100 * boostAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        }
    }
}
