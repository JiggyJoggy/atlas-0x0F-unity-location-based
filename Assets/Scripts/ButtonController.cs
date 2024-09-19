using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Script for handling the User's location
    private UsersLocation gpsLocation;

    // Setting Text
    public TextMeshProUGUI SavedLongitude;
    public TextMeshProUGUI SavedLatitude;
    public TextMeshProUGUI SavedAltitude;
    public TextMeshProUGUI SavedUnity;

    // Object for waypoint
    public GameObject Waypoint;

    // Saved Unity Pos
    public Vector3 SavedPos;

    void Start()
    {
        gpsLocation = FindObjectOfType<UsersLocation>();
    }

    public void SaveCurrentCords()
    {
        // Saves the current location used for Adding a waypoint
        SavedPos = gpsLocation.pos;

        SavedLongitude.text = gpsLocation.Longitude.ToString();
        SavedLatitude.text = gpsLocation.Latitude.ToString();
        SavedAltitude.text = gpsLocation.Altitude.ToString();
        SavedUnity.text = gpsLocation.pos.ToString();
    }

    public void AddWaypoint()
    {
        GameObject newWayPoint = Instantiate(Waypoint);
        newWayPoint.transform.position = new Vector3(gpsLocation.Camera.transform.position.x, 0.9f, gpsLocation.Camera.transform.position.z);

        //newWayPoint.transform.position = new Vector3(gpsLocation.pos.x, 3, gpsLocation.pos.y);

        //newWayPoint.transform.position = SavedPos;
        //SavedPos.y = 3.0f;
        //Debug.Log(SavedPos);
    }
}
