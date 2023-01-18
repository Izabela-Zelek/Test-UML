using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class MapEditor : MonoBehaviour
{
    public XRRayInteractor rayInteractor;
    public Transform centre;
    public Transform left;
    public Transform camCentre;
    public Transform camLeft;

    public InputActionProperty rightSelect;

    public MeshRenderer option1;
    public MeshRenderer option2;

    private float mapDistance;
    private float camDistance;
    private float multiplier;

    private int chosenOption = 0;

    private bool clicked = false;

    private GameObject tree;
    private GameObject tree2;

    private Material notChosenMat;
    private Material chosenMat;
    private void Start()
    {
        mapDistance = Vector3.Distance(centre.position, left.position);
        camDistance = Vector3.Distance(camCentre.position, camLeft.position);

        multiplier = camDistance / mapDistance;

        tree = Resources.Load("Tree_1_1") as GameObject;
        tree2 = Resources.Load("Tree_1_2") as GameObject;

        notChosenMat = Resources.Load("notChosen_mat") as Material;
        chosenMat = Resources.Load("chosen_mat") as Material;
    }
    private
    void Update()
    {

        if (rightSelect.action.ReadValue<float>() >= 0.1f)
        {
            RaycastHit res;
            if (rayInteractor.TryGetCurrent3DRaycastHit(out res))
            {
                Vector3 hitPoint = res.point; // the coordinate that the ray hits
                if (res.collider.name == "Tree1" && !clicked)
                {
                    if (chosenOption != 1)
                    {
                        resetColours();
                        chosenOption = 1;
                        option1.material = chosenMat;
                    }
                    else
                    {
                        resetColours();
                        chosenOption = 0;
                    }
                }
                else if(res.collider.name == "Tree2" && !clicked)
                {
                    if (chosenOption != 2)
                    {
                        resetColours();
                        chosenOption = 2;
                        option2.material = chosenMat;
                    }
                    else
                    {
                        resetColours();
                        chosenOption = 0;
                    }
                }
                else if (res.collider.name == "Map" && !clicked)
                {
                    clicked = true;
                    float yDistance = Mathf.Sqrt((hitPoint.y - centre.position.y) * (hitPoint.y - centre.position.y));
                    float zDistance = Mathf.Sqrt((hitPoint.z - centre.position.z) * (hitPoint.z - centre.position.z));

                    if (hitPoint.z > centre.position.z)
                    {
                        zDistance = -zDistance;
                    }
                    zDistance = zDistance * multiplier;

                    if (hitPoint.y > centre.position.y)
                    {
                        yDistance = -yDistance;
                    }
                    yDistance = yDistance * multiplier;

                    Vector3 pos = new Vector3(camCentre.position.x + yDistance, 0.0f, camCentre.position.z + zDistance);

                    switch (chosenOption)
                    {
                        case 1:
                            Instantiate(tree, pos, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(tree2, pos, Quaternion.identity);
                            break;
                    }
                   
                   
                }
            }
        }
        else if (rightSelect.action.ReadValue<float>() <= 0.0f)
        {
            clicked = false;
        }
    }

    void resetColours()
    {
        option1.material = notChosenMat;
        option2.material = notChosenMat;
    }
}