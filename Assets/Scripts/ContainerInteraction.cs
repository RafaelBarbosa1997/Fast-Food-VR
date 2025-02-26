using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ContainerInteraction : XRGrabInteractable
{
    [SerializeField]
    private GameObject objectToSpawn;// Object that this container will spawn on interaction.

    [SerializeField]
    private Vector3 spawnOffset;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Make parent with container's position to spawn gameobject in container.
        GameObject setParent = new GameObject();
        setParent.transform.position = transform.position + spawnOffset;

        // Spawn object.
        GameObject obj = Instantiate(objectToSpawn, setParent.transform);

        // Get spawned object interactable.
        XRGrabInteractable interactable = obj.GetComponent<XRGrabInteractable>();

        // Enter spawned object select event and exit this select event.
        interactionManager.SelectEnter(args.interactorObject, interactable);
        interactionManager.SelectExit(args.interactorObject, this);
    }
}
