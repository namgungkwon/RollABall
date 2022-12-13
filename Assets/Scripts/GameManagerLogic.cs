using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
	public int stage;
	public Text stageCountText;
	public Text playerCountText;
	private void Awake()
	{
		stageCountText.text = "/ " + totalItemCount.ToString();
	}

	public void GetItem(int count)
	{
		playerCountText.text = count.ToString();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene(stage);
		}
	}
}

