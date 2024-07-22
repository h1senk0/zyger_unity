using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerMovementController : NetworkBehaviour
{
    public float Speed = 0.1f;
    public GameObject PlayerModel;

    public MeshRenderer PlayerMesh;
    public Material[] PlayerColors;

    private void Start()
    {
        PlayerModel.SetActive(false);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name!= "Lobby")
        {
            if(PlayerModel.activeSelf == false)
            {
                SetPosition();
                PlayerModel.SetActive(true);
                PlayerCosmeticsSetup();
            }

            if (hasAuthority)
            {
                Movement();
            }        
        }
    }

    public void SetPosition()
    {
        transform.position = new Vector3(Random.Range(-5,5), 0.8f, Random.Range(-15,7));
    }

    public void Movement()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        transform.position += moveDirection * Speed;
    }


    public void PlayerCosmeticsSetup()
    {
        PlayerMesh.material = PlayerColors[GetComponent<PlayerObjectController>().PlayerColor];
    }


}
