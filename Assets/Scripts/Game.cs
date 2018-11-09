using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private Transform _teleport;
    [SerializeField] private Transform _teleportTo;
    [SerializeField] private TMP_Text _tumbleText;

    private float _totalTumbleTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.velocity.x > 0)
        {
            _totalTumbleTime += Time.deltaTime;
        }

        _tumbleText.text = $"You have tumbled for {_totalTumbleTime:0} seconds";
        
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(_player.transform.position.x + 3, _player.transform.position.y + 1, -10), .25f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.AddForce(new Vector2(100, 10));
        }

        if (_player.transform.position.x > _teleport.position.x)
            _player.transform.position = _teleportTo.position;
    }
}
