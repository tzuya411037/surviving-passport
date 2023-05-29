using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class uGUIJoystick : MonoBehaviour
{
	private RectTransform m_JoystickControoler;
	private Vector3 startPos;
	public float joystickX;
	public float joystickY;
	private float clampPos;
	private float fixPos;
	// Use this for initialization
	void Start()
	{
		m_JoystickControoler = transform.Find("Controller").GetComponent<RectTransform>();
		startPos = m_JoystickControoler.position;

		clampPos = GetComponent<RectTransform>().sizeDelta.x / 2;
		fixPos = 1 / GetComponent<RectTransform>().sizeDelta.x * 2;

		EventTriggerListener.Get(m_JoystickControoler.gameObject).onDrag = OnDrag;
		EventTriggerListener.Get(m_JoystickControoler.gameObject).onEndDrag = OnEndDrag;
	}

	// DragController
	public void OnDrag(GameObject go, PointerEventData eventData)
	{
		// Set ControllerPos by MousePos
		m_JoystickControoler.position = eventData.position;
		// Clamp ControllerPos(LocalPos)
		m_JoystickControoler.localPosition = Vector3.ClampMagnitude(m_JoystickControoler.localPosition, clampPos);
		joystickX = m_JoystickControoler.localPosition.x * fixPos;
		joystickY = m_JoystickControoler.localPosition.y * fixPos;
		//Debug.Log(eventData.pointerId);
	}
	// EndDragController
	public void OnEndDrag(GameObject go)
	{
		m_JoystickControoler.position = startPos;
		joystickX = 0;
		joystickY = 0;
	}
}