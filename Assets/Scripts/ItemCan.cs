using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
    public float rotateSpeed;
    AudioSource audio;

	private void Awake()
	{
		audio = GetComponent<AudioSource>();
	}
	void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player")
			gameObject.SetActive(false);

	}
}
