using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoldToPickUp : MonoBehaviour
{
    public Camera camera;
    public LayerMask layerMask;
    public float pickUpTime = 2f;
    public RectTransform pickupImageRoot;
    public Image pickupProgressImage;
    private TextMeshProUGUI itemNameText;

    public Item itemBeingPickedUp;
    private float currentPickupTimerElapsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SelectItemBeingPickedUpFromRay();

        if(HasItemTargeted())
        {
            pickupImageRoot.gameObject.SetActive(true);

            if(Input.GetKey("f"))
            {
                IncrementPickupProgressandTryComplete();
            }
            else
            {
                currentPickupTimerElapsed = 0f;
            }

            UpdatePickUpProgressImage();
        }
        else
        {
            pickupImageRoot.gameObject.SetActive(false);
            currentPickupTimerElapsed = 0f;
        }
        
    }

    private void UpdatePickUpProgressImage()
    {
        float pct = currentPickupTimerElapsed / pickUpTime;
        pickupProgressImage.fillAmount = pct;
    }

    private void IncrementPickupProgressandTryComplete()
    {
        currentPickupTimerElapsed += Time.deltaTime;
        if(currentPickupTimerElapsed >= pickUpTime)
        {
            InteractWithItem();
        }
    }

    private void InteractWithItem()
    {
        itemBeingPickedUp.ShipCutScene();
        itemBeingPickedUp = null;
    }

    private bool HasItemTargeted()
    {
        return itemBeingPickedUp != null;
    }

    private void SelectItemBeingPickedUpFromRay()
    {
        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, 2f, layerMask))
        {
            var hitItem = hitInfo.collider.GetComponent<Item>();

            if(hitItem == null)
            {
                itemBeingPickedUp = null;
            }
            else if(hitItem != null && hitItem != itemBeingPickedUp)
            {
                itemBeingPickedUp = hitItem;
                itemNameText.text = "Interact with " + itemBeingPickedUp.gameObject.name;
            }
        }
        else
        {
            itemBeingPickedUp = null;
        }
    }
}
