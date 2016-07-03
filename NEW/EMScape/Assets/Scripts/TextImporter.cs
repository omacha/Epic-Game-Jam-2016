using UnityEngine;
using System.Collections;

public class TextImporter : MonoBehaviour {

	public TextAsset textfile;
	public string[] textLines;
	// Use this for initialization
	void Start () {
		if (textfile != null) {
			textLines = (textfile.text.Split ('\n'));

		}
	}
}
