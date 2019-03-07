using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;		

public class _RandomSoild : _ACElement
{
    public Transform Soild;

    void Start()
    {
        int length = 210;
        int prob_from_main = (_Parameters.Ground_prob == null || _Parameters.Soild_prob.Trim() == string.Empty) ? 40 : int.Parse(_Parameters.Soild_prob);
        List<Tuple<float, float>> coord = Fill_Coord(prob_from_main, length,0,-4f,-4f);

        for (int i = 0; i < coord.Count; i++)
        {
            while (!Validate_Overlap(coord[i].First, coord[i].Second))
            {
                System.Random rnd = new System.Random();
                coord[i].First = rnd.Next(0, length);                
            }
            _Parameters.Coord_global.Add(new Tuple<float, float>(coord[i].First, coord[i].Second));
        }

        Instantiate_Element(Soild, coord);
    }


}
