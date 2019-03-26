namespace Mapbox.Examples
{
    using Mapbox.Geocoding;
    using UnityEngine.UI;
    using Mapbox.Unity.Map;
    using UnityEngine;
    using System;
    using System.Collections;

    public class reload_object : MonoBehaviour
    {
        Camera _camera;
        public GameObject waypoint;
        Vector3 _cameraStartPos;
        AbstractMap _map;

        [SerializeField]
        ForwardGeocodeUserInput _forwardGeocoder;

        [SerializeField]
        Slider _zoomSlider;

        private HeroBuildingSelectionUserInput[] _heroBuildingSelectionUserInput;

        Coroutine _reloadRoutine;

        WaitForSeconds _wait;

        void Awake()
        {
            _camera = Camera.main;
            _cameraStartPos = _camera.transform.position;
            _map = FindObjectOfType<AbstractMap>();
            if (_map == null)
            {
                Debug.LogError("Error: No Abstract Map component found in scene.");
                return;
            }
          
            if (_forwardGeocoder != null)
            {
                _forwardGeocoder.OnGeocoderResponse += ForwardGeocoder_OnGeocoderResponse;
            }
            _heroBuildingSelectionUserInput = GetComponentsInChildren<HeroBuildingSelectionUserInput>();
            if (_heroBuildingSelectionUserInput != null)
            {
                for (int i = 0; i < _heroBuildingSelectionUserInput.Length; i++)
                {
                    _heroBuildingSelectionUserInput[i].OnGeocoderResponse += ForwardGeocoder_OnGeocoderResponse;
                }
            }
            _wait = new WaitForSeconds(.3f);
        }

        void ForwardGeocoder_OnGeocoderResponse(ForwardGeocodeResponse response)
        {
            if (null != response.Features && response.Features.Count > 0)
            {
                int zoom = _map.AbsoluteZoom;
                _map.UpdateMap(response.Features[0].Center, zoom);
            }
        }

        void ForwardGeocoder_OnGeocoderResponse(ForwardGeocodeResponse response, bool resetobject)
        {
            if (response == null)
            {
                return;
            }
            if (resetobject)
            {
                waypoint.transform.position = _cameraStartPos;
            }
            ForwardGeocoder_OnGeocoderResponse(response);
        }
    }
}