using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour
{
    public GameObject mainCamera;
    public Text logTitle, logDesc;
    public GameObject device;
    public float playerReach = 1f;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Cursor.visible = false;
        device.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact")) //CHANGE Fire1 TO Interact IN AXIS SETTINGS FOR THIS TO WORK
        {
            Ray interact;
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(interact, out hitInfo, playerReach))
            {
                if (hitInfo.collider.CompareTag("Collectable")) //ITEMS MUST BE TAGGED "Collectable"
                {
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    device.SetActive(true);
                    logTitle.text = hitInfo.collider.GetComponent<DeviceInfo>().logTitle;
                    logDesc.text = hitInfo.collider.GetComponent<DeviceInfo>().logDesc;
                }
            }
        }

        if (device)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                device.SetActive(false);
                logTitle.text = "";
                logDesc.text = "";
            }

        }
    }
}