using UnityEngine;
using System.Collections;
using VRTK;

public class SlidingPuzzlePanel : MonoBehaviour
{
	public float SnapSize = 0.15f;

	void Start ()
	{
		if (GetComponent<VRTK_InteractableObject>() == null)
		{
			Debug.LogError("This component requires the VRTK_InteractableObject script attached to the parent.");
			return;
		}

		GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);
		GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(ObjectUngrabbed);
	}

	void Update ()
	{
	
	}

	private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
	{
		Debug.Log("Im grabbed");
	}

	private void ObjectUngrabbed(object sender, InteractableObjectEventArgs e)
	{
		float ySnap = Mathf.Round(transform.localPosition.y / SnapSize) * SnapSize;
		float zSnap = Mathf.Round(transform.localPosition.z / SnapSize) * SnapSize;

		transform.localPosition = new Vector3 (transform.localPosition.x, ySnap, zSnap);
	}
}
