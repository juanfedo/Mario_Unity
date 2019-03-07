using System;
using System.Collections.Generic;
using UnityEngine;


abstract public class _ACElement : MonoBehaviour
{    
    protected bool Validate_Overlap(float x, float y)
    {
        foreach (Tuple<float, float> t in _Parameters.Coord_global)            
            if (t.First == x && t.Second == y)
                return false;            
        return true;
    }

    protected void Instantiate_Element(Transform element, List<Tuple<float, float>> coord)
    {
        foreach (Tuple<float,float> t in coord)                    
            Instantiate(element, new Vector3(t.First + 0.5f,t.Second -0.5f, 0), Quaternion.identity);        
    }

     protected  List<Tuple<float,float>> Fill_Coord(int prob, int length,int prob_air,float floor,float air)
    {
        System.Random rnd = new System.Random();
        List<Tuple<float, float>> coord = new List<Tuple<float, float>>();
        for (int x = 0; x <= length; x++)        
            if (rnd.Next(1, 100) <= prob)
                coord.Add(new Tuple<float, float>(Convert.ToInt16(x), (rnd.Next(0, 100) > prob_air ? floor : air)));        
        return coord;
    }

}
