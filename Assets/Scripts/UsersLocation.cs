using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Niantic.Experimental.Lightship.AR.WorldPositioning;
using TMPro;

public class UsersLocation : MonoBehaviour
{
    // Setting up AR Camera in the World
    [SerializeField] private ARCameraManager _arCameraManager;
    private ARWorldPositioningCameraHelper _arWorldPositioningCameraHelper;
    public GameObject Camera;

    // Setting GPS location
    public double Longitude;
    public double Latitude;
    public double Altitude;

    // Setting GPS Cords to Unity Vector3
    public Vector2 GPSPos;
    internal Vector3 pos;

    // TextMeshPro Texts
    public TextMeshProUGUI LongitudeText;
    public TextMeshProUGUI LatitudeText;
    public TextMeshProUGUI AltitudeText;
    public TextMeshProUGUI UnityText;

    // Start is called before the first frame update
    void Start()
    {
        _arWorldPositioningCameraHelper = _arCameraManager.GetComponent<ARWorldPositioningCameraHelper>();
        GPSPos = new Vector2(ToSingle(Longitude), ToSingle(Latitude));
        pos = GPSEncoder.GPSToUCS(GPSPos);
        Camera.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        IRL_GPS();
        GPS_CORDS_TO_TEXT();
    }

    public void GPS_CORDS_TO_TEXT()
    {

        LongitudeText.text = Longitude.ToString();
        LatitudeText.text = Latitude.ToString();
        AltitudeText.text = Altitude.ToString();
        UnityText.text = pos.ToString();
    }

    public void IRL_GPS()
    {
        float heading = _arWorldPositioningCameraHelper.TrueHeading;
        Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, heading);

        Longitude = _arWorldPositioningCameraHelper.Longitude;
        Latitude = _arWorldPositioningCameraHelper.Latitude;
        Altitude = _arWorldPositioningCameraHelper.Altitude;

        GPSPos = new Vector2(ToSingle(Longitude), ToSingle(Latitude));
        pos = GPSEncoder.GPSToUCS(GPSPos);
    }

    public static float ToSingle(double value)
    {
        return (float)value;
    }
}
