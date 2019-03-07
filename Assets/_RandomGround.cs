using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class _RandomGround : MonoBehaviour
{
    public Transform brick;
    int jump = 6;
    int max_count_bricks = 210;

    void Start()
    {
        int prob_from_main = (_Parameters.Ground_prob == null || _Parameters.Ground_prob.Trim() == string.Empty) ? 100 : int.Parse(_Parameters.Ground_prob);
        List<int> coord = Fill_Coord(prob_from_main);
        Instantiate_Ground(Complete_Coord(coord));
    }

    List<int> Fill_Coord(int prob)
    {
        System.Random rnd = new System.Random();
        List<int> coord = new List<int>();
        coord.Add(0);
        coord.Add(max_count_bricks);
        for (int x = 0; x <= max_count_bricks; x++)
            if (rnd.Next(1, 100) <= prob)
                coord.Add(x);
        return coord;
    }

    void Instantiate_Ground(List<int> coord)
    {
        foreach (int x in coord)
        {
            _Parameters.Coord_ground.Add(new Tuple<float, float>(Convert.ToInt16(x),-5.5f));
            Instantiate(brick, new Vector3(x, -5.5f, 0), Quaternion.identity);
            Instantiate(brick, new Vector3(x, -6.5f, 0), Quaternion.identity);
        }
    }

    int Validate(List<int> coord,ref int i)
    {
        coord.Sort();
        for (; i < coord.Count - 1; i++)
            if (coord[i + 1] - coord[i] > jump)
                return (coord[i + 1] + coord[i]) / 2;
        return -1;
    }

    List<int> Complete_Coord(List<int> coord)
    {
        coord.Sort();
        int temp = 0, cont = 0;
        while (temp >= 0)
        {            
            temp = Validate(coord,ref cont);
            if (temp > 0)
                coord.Add(temp);
        }
        return coord;
    }
}



