using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
	public float JumpPower;
	public int itemCount;
	bool isJump;
	byte Jump = 2;
	Rigidbody rigid;
	AudioSource audio;
	public GameManagerLogic manager;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody>();
		audio = GetComponent<AudioSource>();
	}
	// Update is called once per frame

	private void Update()
	{
		if (Input.GetButtonDown("Jump") && !isJump)
		{
			if (--Jump == 0)
				isJump = true;
			rigid.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Impulse);
		}
	}
	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Floor"))
		{
			isJump = false;
			Jump = 2;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Item"))
		{
			itemCount++;
			audio.Play();
			other.gameObject.SetActive(false);
			manager.GetItem(itemCount);
		}
		else if (other.CompareTag("Finish"))
		{
			if (itemCount == manager.totalItemCount)
			{
				if (manager.stage == 2)
					SceneManager.LoadScene(0);
				else
					SceneManager.LoadScene(manager.stage + 1);
			}
			else
			{
				//Restart!
				SceneManager.LoadScene(manager.stage);
			}
		}
	}
}