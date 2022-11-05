using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    public bool inSlot = false;
    public Vector3 slotRotation = Vector3.zero;
    public Slot currentSlot = null;
    public bool isHeld = false;
    public InputActionProperty rightSelect;
    public float targetTime = 1.0f;
    public GameObject parent;
    public bool isLarge = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isLarge)
        {
            if (other.tag == "RightHand")
            {
                if (rightSelect.action.ReadValue<float>() > 0.1f)
                {
                    isHeld = true;
                    targetTime = 2.0f;
                    if (currentSlot != null)
                    {
                        currentSlot.RemoveItem();
                        transform.position = other.gameObject.transform.position;
                        inSlot = false;
                        currentSlot = null;
                        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        gameObject.GetComponent<BoxCollider>().isTrigger = false;

                    }

                }
            }
        }
        else
        {
            if (other.tag == "RightHand")
        {
                if (rightSelect.action.ReadValue<float>() > 0.1f) 
                {
                    isHeld = true;
                    targetTime = 2.0f;
                    if (currentSlot != null)
                    {
                        currentSlot.RemoveItem();
                        gameObject.transform.SetParent(parent.transform, false);
                        Vector3 scale = gameObject.transform.localScale;

                        scale.Set(0.5f, 0.5f, 0.5f);

                        gameObject.transform.localScale = scale;
                        gameObject.transform.position = other.gameObject.transform.position;
                        inSlot = false;
                        currentSlot = null;
                        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        gameObject.GetComponent<MeshCollider>().isTrigger = false;


                    }

                }
        
            }
        }

    }

    private void Update()
    {
        if (targetTime > 0 && isHeld)
        { 
            targetTime -= Time.deltaTime; 
        }

        if (rightSelect.action.ReadValue<float>() == 0 && targetTime <= 0)
        {
            isHeld = false;
        }
    }
}
