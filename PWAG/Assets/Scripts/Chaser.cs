using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    public static event System.Action OnGuardHasSpottedPlayer;
    public float speed = 5;
    public float waitTIme = .3f; 
    public float timeToSpotPlayer = .5f;
    public Transform pathHolder; //patrol path
    Transform player;

    Color originalSpotlightColor;

    public Light spotlight;
    public float viewDistance;
    float viewAngle;
    float playerVisibleTimer;

    private NavMeshAgent Mob;
    public GameObject Player;
    public float MobDistranceRun = 4.0f;
    
    public float turnSpeed = 90;

    public LayerMask viewMask;

    //Drawing spheres so we can see the path our chaser will take when patroling
    void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere (waypoint.position, .3f);//Drawing the sphere
            //Connecting the spheres
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition,startPosition);//connecting the last and first sphere making a loop

        Gizmos.color = Color.red;
        Gizmos.DrawRay (transform.position, transform.forward * viewDistance);
    }

    void Start()
    {
        originalSpotlightColor = spotlight.color;
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        viewAngle = spotlight.spotAngle;

        Mob = GetComponent<NavMeshAgent>();
        Vector3[] waypoints = new Vector3 [pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i ++) 
        {
            waypoints [i] = pathHolder.GetChild (i).position;
            waypoints [i] = new Vector3 (waypoints [i].x, transform.position.y, waypoints[i].z);
        }

        StartCoroutine (FollowPath(waypoints));
    }

    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle (transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2 (dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints [0];

        int targetWaypoingIndex = 1;
        Vector3 targetWaypoint = waypoints [targetWaypoingIndex];
        transform.LookAt(targetWaypoint);

        while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                targetWaypoingIndex = (targetWaypoingIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints [targetWaypoingIndex];
                yield return new WaitForSeconds (waitTIme);
                yield return StartCoroutine(TurnToFace(targetWaypoint));
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer ())
        {
            playerVisibleTimer += Time.deltaTime;
        }
        else
        {
            playerVisibleTimer -= Time.deltaTime;
        }
        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer);
        spotlight.color = Color.Lerp(originalSpotlightColor, Color.red, playerVisibleTimer/timeToSpotPlayer);

        if (playerVisibleTimer >= timeToSpotPlayer)
        {
            if (OnGuardHasSpottedPlayer != null)
            {
                OnGuardHasSpottedPlayer();
            }
        }
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        // Run towards player

        if (distance < MobDistranceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            Mob.SetDestination(newPos);
        }
        
    }
}
