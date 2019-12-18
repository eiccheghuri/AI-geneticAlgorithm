using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulationManager : MonoBehaviour
{


    public GameObject player_prefab;
    public int number_of_population;

    public static float elasped_time;


    public List<GameObject> _population = new List<GameObject>();


    public int trial_time = 10;
    public int _generation = 1;

    GUIStyle gui_style = new GUIStyle();
    public void OnGUI()
    {
        gui_style.fontSize = 50;
        gui_style.normal.textColor = Color.white;


        GUI.Label(new Rect(10,10,100,20),"Generation "+_generation,gui_style);
        GUI.Label(new Rect(10,65,100,20),"Trial Time "+(int)elasped_time,gui_style);
    }

    public void Start()
    {
        for(int i=0;i<number_of_population;i++)
        {
            Vector2 _position = new Vector2(Random.Range(-8.98f,8.9f),Random.Range(-4.39f,4.39f));
            GameObject go = Instantiate(player_prefab,_position,Quaternion.identity);

            go.GetComponent<DNA>()._red = Random.Range(0f,1f);
            go.GetComponent<DNA>()._green = Random.Range(0f, 1f);
            go.GetComponent<DNA>()._blue = Random.Range(0f, 1f);
            go.GetComponent<DNA>()._scale = Random.Range(.1f,.3f);

            _population.Add(go);



        }
    }


    public void Update()
    {
        elasped_time += Time.deltaTime;
        if(elasped_time>trial_time)
        {

            BreedNewPopulation();
            elasped_time = 0;
        }
    }

    public void BreedNewPopulation()
    {

        List<GameObject> new_populaton = new List<GameObject>();

        List<GameObject> sorted_list = _population.OrderByDescending(o => o.GetComponent<DNA>().time_to_die).ToList();
        _population.Clear();

        for(int i=(int)(sorted_list.Count/2f)-1;i<sorted_list.Count-1;i++)
        {
            _population.Add(Breed(sorted_list[i], sorted_list[i + 1]));
            _population.Add(Breed(sorted_list[i+1], sorted_list[i]));

        }

        for(int i=0;i<sorted_list.Count; i++)
        {
            Destroy(sorted_list[i]);
        }
        _generation++;

    }

    public GameObject Breed(GameObject parent1,GameObject parent2)
    {
        Vector3 _pos = new Vector3(Random.Range(-8,8),Random.Range(-4,4),0);

        GameObject offspring = Instantiate(player_prefab,_pos,Quaternion.identity);

        DNA dna1 = parent1.GetComponent<DNA>();
        DNA dna2 = parent2.GetComponent<DNA>();

        if(Random.Range(0,1000)>5)
        {
            offspring.GetComponent<DNA>()._red = Random.Range(0, 10) < 5 ? dna1._red : dna2._red;
            offspring.GetComponent<DNA>()._green = Random.Range(0, 10) < 5 ? dna1._green : dna2._green;
            offspring.GetComponent<DNA>()._blue = Random.Range(0, 10) < 5 ? dna1._blue : dna2._blue;
            offspring.GetComponent<DNA>()._scale = Random.Range(0, 10) < 5 ? dna1._scale : dna2._scale;
        }
        else
        {
            offspring.GetComponent<DNA>()._red = Random.Range(0f, 1f);
            offspring.GetComponent<DNA>()._green = Random.Range(0f, 1f);
            offspring.GetComponent<DNA>()._blue = Random.Range(0f, 1f);
            offspring.GetComponent<DNA>()._scale = Random.Range(.1f, .3f);
        }

        return offspring;
    }

        

       

   




}//class
