using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Curb") && collision.gameObject.layer != LayerMask.NameToLayer("Ground") && collision.gameObject.layer != LayerMask.NameToLayer("Boundary") && collision.gameObject.layer != LayerMask.NameToLayer("Lights") && collision.transform.tag != "EntryPoints")
        {
            transform.parent.GetComponent<VehicleMover>().setMove(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Curb") && collision.gameObject.layer != LayerMask.NameToLayer("Ground") && collision.gameObject.layer != LayerMask.NameToLayer("Boundary") && collision.gameObject.layer != LayerMask.NameToLayer("Lights") && collision.transform.tag != "EntryPoints")
        {
            transform.parent.GetComponent<VehicleMover>().setMove(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Curb") && other.gameObject.layer != LayerMask.NameToLayer("Ground") && other.gameObject.layer != LayerMask.NameToLayer("Boundary") && other.gameObject.layer != LayerMask.NameToLayer("Lights") && other.transform.tag != "EntryPoints")
        {
            transform.parent.GetComponent<VehicleMover>().setMove(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Curb") && collision.gameObject.layer != LayerMask.NameToLayer("Ground") && collision.gameObject.layer != LayerMask.NameToLayer("Boundary") && collision.gameObject.layer != LayerMask.NameToLayer("Lights") && collision.transform.tag != "EntryPoints")
        {
            transform.parent.GetComponent<VehicleMover>().setMove(true);
        }
    }
}