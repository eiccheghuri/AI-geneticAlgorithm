using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{

    public float _red;
    public float _green;
    public float _blue;
    public float _scale;
    public bool _dead = false;


    
    private SpriteRenderer sprite_renderer;
    private Collider2D player_collider;

    public float time_to_die;

    public void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
        player_collider = GetComponent<Collider2D>();

        sprite_renderer.color = new Color(_red,_green,_blue);
        this.transform.localScale = new Vector3(_scale,_scale,_scale);

    }


    public void OnMouseDown()
    {

        _dead = true;
        time_to_die = PopulationManager.elasped_time;

        sprite_renderer.enabled = false;
        player_collider.enabled = false;



    }



}
