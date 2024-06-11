using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip knifeSE;
    public AudioClip waterSE;
    public AudioClip ropeSE;

    AudioSource aud;

    GameObject director;

    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        this.aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            Debug.Log("Tag = Apple");
            this.director.GetComponent<GameDirector>().GetApple();
            aud.PlayOneShot(appleSE);
        }
        else if (other.gameObject.tag == "Water")
        {
            Debug.Log("Tag = Water");
            this.director.GetComponent<GameDirector>().GetWater();
            aud.PlayOneShot(waterSE);
        }
        else if (other.gameObject.tag == "Rope")
        {
            Debug.Log("Tag = Rope");
            this.director.GetComponent<GameDirector>().GetRope();
            aud.PlayOneShot(ropeSE);
        }
        else
        {
            Debug.Log("Tag = Knife");
            this.director.GetComponent<GameDirector>().GetKnife();
            aud.PlayOneShot(knifeSE);
        }

        Destroy(other.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
