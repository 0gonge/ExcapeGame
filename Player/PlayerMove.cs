using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private CharacterController controller;
    private AudioSource audioSource;
    [SerializeField] AudioClip footstepSound;
    [SerializeField] AudioClip doorSound;
    private bool isMoving;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "door")
        {
            PlayDoorSound();
            SceneManager.LoadScene("Food");
        }
        if (other.gameObject.tag == "outdoor")
        {
            PlayDoorSound();
            SceneManager.LoadScene("Shoot");
        }
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(h, 0, v);
        this.transform.Translate(mov * Time.deltaTime * speed);

        if (mov != Vector3.zero)
        {
            if (!isMoving)
            {
                isMoving = true;
                StartCoroutine(PlayFootstepSound());
            }
        }
        else
        {
            isMoving = false;
        }
    }

    IEnumerator PlayFootstepSound()
    {
        while (isMoving)
        {
            audioSource.PlayOneShot(footstepSound);
            yield return new WaitForSeconds(0.5f); // Adjust the delay for realistic footstep timing
        }
    }

    void PlayDoorSound()
    {
        audioSource.PlayOneShot(doorSound);
    }
}
