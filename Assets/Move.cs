using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Move : MonoBehaviour
{
    public GameObject model;
    public ObserverBehaviour[] ImageTargets;
    public GameObject[] Models;
    public int currentTarget;
    public float speed = 1.0f;
    private bool isMoving = false;
    // Start is called before the first frame update
    
    public void moveToNextMarker() {
        if (!isMoving)
        {
            StartCoroutine(MoveModel());
        }
    }

    private IEnumerator MoveModel()
    {
        isMoving = true;
        ObserverBehaviour target = GetNextDetectedTarget();
        if(target == null) {
            isMoving = false;
            yield break;
        }

        Vector3 startPosition = model.transform.position;
        Vector3 endPosition = target.transform.position;

        float journey = 0;

        while (journey <= 1f)
        {
            journey += Time.deltaTime * speed;
            model.transform.position = Vector3.Lerp(startPosition, endPosition, journey);
            yield return null;

        }

        Models[(currentTarget) % Models.Length].SetActive(false);
        currentTarget = (currentTarget+1)%ImageTargets.Length;
        if (currentTarget == 0)
        {
            foreach(GameObject model in Models)
            {
                model.SetActive(true);
            }
        }
        isMoving = false;

    }

    private ObserverBehaviour GetNextDetectedTarget()
    {
        foreach(ObserverBehaviour target in ImageTargets)
        {
            if(target != null && (target.TargetStatus.Status==Status.TRACKED || target.TargetStatus.Status==Status.EXTENDED_TRACKED) && target == ImageTargets[(currentTarget+1)%ImageTargets.Length])
            {
                return target;
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
