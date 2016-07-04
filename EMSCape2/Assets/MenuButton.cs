using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Text theText;
	public Color over;
	public Color normal;

	public void OnPointerEnter(PointerEventData eventData){

		theText.color = Color.Lerp (normal,over, 1.0f);
	}
	public void OnPointerExit(PointerEventData eventData){
		theText.color = Color.Lerp (over,normal, 1.0f);
	}
}
