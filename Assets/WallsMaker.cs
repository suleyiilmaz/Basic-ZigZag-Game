
using UnityEngine;

public class WallsMaker : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform lastwall;
    Vector3 lastposition;
    public GameObject wallprefab;
    Camera cam;
    PlayerController player;
    void Start()
    {
        lastposition = lastwall.position;
        InvokeRepeating("CreateWalls", 1, 0.1f);
        cam = Camera.main;
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CreateWalls()
    {
        float distance = Vector3.Distance(lastposition, player.transform.position);
        if (distance > cam.orthographicSize * 2) return;

        Vector3 newPosition = Vector3.zero;
        int rand = Random.Range(0, 11); 
        if (rand <= 5)
        {
            newPosition = new Vector3(lastposition.x - 0.70711f, 0, lastposition.z + 0.70711f);
        }
        else
        {
            newPosition = new Vector3(lastposition.x +0.70711f, 0, lastposition.z + 0.70711f);
        }
        GameObject newBlock = Instantiate(wallprefab, newPosition, Quaternion.Euler(0, 45, 0), transform);
        newBlock.transform.GetChild(0).gameObject.SetActive(rand % 3 == 2);
        lastposition = newBlock.transform.position;

    }
}
