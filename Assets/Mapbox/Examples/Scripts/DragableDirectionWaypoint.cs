using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mapbox.Examples
{
	public class DragableDirectionWaypoint : MonoBehaviour
	{
		public Transform MoveTarget;
		private Vector3 screenPoint;
		private Vector3 offset;
		private Plane _yPlane;
        public GameObject events;
        public GameObject WayPoint;

        public void Start()
		{
			_yPlane = new Plane(Vector3.up, Vector3.zero);
		}

		void OnMouseDrag()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float enter = 0.0f;
			if (_yPlane.Raycast(ray, out enter))
			{
				MoveTarget.position = ray.GetPoint(enter);
			}
		}
        public void Toggle_Changed(bool newValue)
        {
            if (WayPoint.activeSelf == false)
            {
                WayPoint.SetActive(true);
                events.GetComponent<CameraMovement>().enabled = false;
            }
            else if (WayPoint.activeSelf == true)
            {
                WayPoint.SetActive(false);
                events.GetComponent<CameraMovement>().enabled = true;

            }

        }
    }
}
