using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public void fixedUpdate(DiskData disk)
    {
        Rigidbody rigid = disk.gameObject.GetComponent<Rigidbody>();
        if (disk.isEnabled && disk.transform.position != disk.pointB)
        {
            disk.currentTimeCount++;
            if (rigid)
            {
                rigid.velocity = new Vector3(Random.Range(-5f, 5f), (10f / 4) + Random.Range(-4f, 2f), 15f);
                disk.currentAngle.x = -Mathf.Atan((disk._speed.y + disk.Gravity.y) / disk._speed.z) * Mathf.Rad2Deg;
                transform.eulerAngles = disk.currentAngle;
            }
        }
        if (disk.reachedEnd) // if it has reached the end and not get clicked
        {
            disk.reset();
            rigid.velocity = Vector3.zero;
            Singleton<DiskFactory>.Instance.FreeDisk(disk);
        }
    }
}
