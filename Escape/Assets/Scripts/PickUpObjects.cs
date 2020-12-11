using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public Rigidbody rb;
    public MeshCollider coll;
    public Transform player, handCon;
    public Animator playerAnim;
    
    public float pickUpDistance;
    public float dropForwardForce, dropUpwardForce;

    public bool isEquip;
    public static bool slotFull;
    public Vector3 ItemPosition, ItemRotation, ItemSize;

    void Start()
    {
        playerAnim = player.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!isEquip && distanceToPlayer.magnitude <= pickUpDistance && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();
        if (isEquip && Input.GetKeyDown(KeyCode.Q)) Drop();
    }
    
    private void PickUp() 
    {
        isEquip = true;
        slotFull = true;

        transform.SetParent(handCon);
        transform.localPosition = ItemPosition;
        transform.localRotation = Quaternion.Euler(ItemRotation);
        transform.localScale = ItemSize;

        rb.isKinematic = true;
        coll.isTrigger = true;

        playerAnim.SetBool("hasItem", true);
    }

    private void Drop()
    {
        isEquip = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;
        
        playerAnim.SetBool("hasItem", false);
    }
}
