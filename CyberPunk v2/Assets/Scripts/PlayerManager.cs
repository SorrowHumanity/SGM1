using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour {

	void Start()
	{
		if (isLocalPlayer)
		{
			this.GetComponent<CapsuleCollider>().enabled = true;
			this.GetComponent<Animator>().enabled = true;
			this.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
			this.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;

			transform.Find("CameraBase").gameObject.SetActive(true);
		}

	}

	// Update is called once per frame
	void Update () {

	}
}