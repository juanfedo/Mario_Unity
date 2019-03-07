using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;		

public class _RandomPipe : _ACElement
{
    public Transform Middle_Pipe;
    public Transform Top_Pipe;

    void Start()
    {
        int length = 100;
        int prob_from_main = 3;//(_Parameters.Ground_prob == null || _Parameters.Soild_prob.Trim() == string.Empty) ? 40 : int.Parse(_Parameters.Soild_prob);
        System.Random rnd = new System.Random();
        List<Tuple<float, float>> coord = Fill_Coord(prob_from_main, length, 90, -4f, -1f);

        //for (int i = 0; i < coord.Count; i++)
        //{
        //    while (!Validate(coord[i].First, coord[i].Second))
        //        coord[i].First = rnd.Next(0, length);
        //    _Parameters.Coord_global.Add(new Tuple<float, float>(coord[i].First, coord[i].Second));
        //}
        foreach (Tuple<float, float> t in coord)
        {
            List<Tuple<float, float>> temp = new List<Tuple<float, float>>();
            t.Second = -5.0f;
            int height = rnd.Next(1, 3);
            for (int i = 0; i <= height ; i++)
            {
                t.Second ++;
                //print(" Middle: " + t.First.ToString() + "::" + t.Second.ToString());
                temp.Add(t);
                Instantiate_Element(Middle_Pipe, temp);
                temp.Clear();
            }
            temp.Clear();
            t.Second++;
            //print(" Top: " + t.First.ToString() + "::" + t.Second.ToString());
            temp.Add(t);
            Instantiate_Element(Top_Pipe, temp);
        }
    }

	public bool Validate(float x, float y)
	{
		bool over_ground = false;
		foreach (Tuple<float, float> t in _Parameters.Coord_ground)
			if(t.First == x && (t.First == x+1 || t.First == x-1))
				over_ground = true;
		return Validate_Overlap(x,y) && over_ground;		
	}
}

