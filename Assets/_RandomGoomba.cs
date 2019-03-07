using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class _RandomGoomba : _ACElement
{
    public Transform enemy;
    
    void Start()
    {
        int length = 210;
        int prob_from_main = (_Parameters.Ground_prob == null || _Parameters.Goomba_prob.Trim() == string.Empty) ? 10 : int.Parse(_Parameters.Goomba_prob);
        List<Tuple<float, float>> coord = Fill_Coord(prob_from_main, length,90,-4f,0f);

        for (int i = 0; i < coord.Count; i++)
        {
            while (!Validate_Overlap(coord[i].First, coord[i].Second))
            {
                System.Random rnd = new System.Random();
                coord[i].First = rnd.Next(0, length);                
            }
            _Parameters.Coord_global.Add(new Tuple<float, float>(coord[i].First, coord[i].Second));
        }

        Instantiate_Element(enemy, coord);
    }

}
