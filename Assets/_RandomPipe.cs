using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;		

public class _RandomPipe : _ACElement
{
    public GameObject Middle_Pipe;
    public GameObject Top_Pipe;

    void Start()
    {
        //int length = 50;
        //int prob_from_main = 80;//(_Parameters.Ground_prob == null || _Parameters.Soild_prob.Trim() == string.Empty) ? 40 : int.Parse(_Parameters.Soild_prob);

        //List<Tuple<float, float>> coord = Fill_Coord(prob_from_main, length, 90, -4f, -1f);
        //print("longitud de coord: " + coord.Count.ToString());
        //foreach (Tuple<float, float> t in coord)        
        //    print("Valor X: " + t.First.ToString() + " Valor Y: " + t.Second.ToString());        
        //int contador = 0;
        //System.Random rnd = new System.Random();
        //for (int i = 0; i < coord.Count; i++)
        //{
        //    while (!Validate_Overlap(coord[i].First, coord[i].Second,2))
        //    {
                
        //        int n = rnd.Next(0, length);
        //        if (n != coord[i].First)
        //            coord[i].First = n;
        //        else
        //            coord[i].First += 1;
        //        print("repetido para " + coord[i].First.ToString() + " en: " + contador.ToString());
        //        contador++;
        //    }
        //    print("Instanciado objeto en X: " + coord[i].First.ToString() + " Y: " + coord[i].Second.ToString());
        //    _Parameters.Coord_global.Add(new Tuple<float, float>(coord[i].First, coord[i].Second));
        //}
        //foreach (Tuple<float, float> t in coord)
        //{
        //    List<Tuple<float, float>> temp = new List<Tuple<float, float>>();
        //    t.Second = -5.0f;
        //    //System.Random rnd = new System.Random();
        //    int height = rnd.Next(1, 3);
        //    for (int i = 0; i <= height; i++)
        //    {
        //        t.Second++;
        //        temp.Add(t);
        //        Instantiate_Element(Middle_Pipe, temp,1);
        //        temp.Clear();
        //    }
        //    temp.Clear();
        //    t.Second++;            
        //    temp.Add(t);
        //    Instantiate_Element(Top_Pipe, temp,2);
        //}
    }

    public bool Validate(float x, float y)
    {
        bool over_ground = false;
        for (int i = 1; i < _Parameters.Coord_ground.Count - 1; i++)
            if (_Parameters.Coord_ground[i].First == x && (_Parameters.Coord_ground[i + 1].First == x + 1 || _Parameters.Coord_ground[i - 1].First == x - 1))
            {
                over_ground = true;
                break;
            }
        return Validate_Overlap(x, y, 2) && over_ground;
    }
}

