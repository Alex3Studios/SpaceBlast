using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour {

	private GameObject[] textor;

	private int number = 3;
	// Use this for initialization
	void Start () {
		textor = GameObject.FindGameObjectsWithTag("countdown");
		StartCoroutine(countdowner());
	}
	
	// Update is called once per frame
	void Update () {
	}
	IEnumerator countdowner()
	{
		for(int i = number; i > 0; i--)
		{
			foreach(var text in textor)
			{
				text.GetComponent<UnityEngine.UI.Text>().text = i.ToString();
			}
			yield return new WaitForSeconds(0.8f);
		}
		foreach(var text in textor)
		{
			text.GetComponent<UnityEngine.UI.Text>().text = "Go!";
		}
		SceneManager.LoadScene("Main");
	}
}
