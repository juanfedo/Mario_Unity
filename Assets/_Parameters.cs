using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class _Parameters 
{
    static string ground_prob  = string.Empty;
    static string soild_prob = string.Empty;
    static string goomba_prob = string.Empty;

    static List<Tuple<float, float>> coord_ground;
    static List<Tuple<float, float>> coord_soild;
    static List<Tuple<float, float>> coord_goomba;
    static List<Tuple<float,float>> global_coord;

    static _Parameters()
    {
        coord_ground = new List<Tuple<float, float>>();
        coord_soild = new List<Tuple<float, float>>();
        coord_goomba = new List<Tuple<float, float>>();
        global_coord = new List<Tuple<float, float>>();
    }

    public static string Ground_prob
    {
        get
        {
            return ground_prob;
        }
        set
        {
            ground_prob = value;
        }
    }

    public static List<Tuple<float, float>> Coord_global
    {
        get
        {
            return global_coord;
        }

        set
        {
            global_coord = value;
        }
    }

    public static List<Tuple<float, float>> Coord_ground
    {
        get
        {
            return coord_ground;
        }

        set
        {
            coord_ground = value;
        }
    }

    public static string Soild_prob
    {
        get
        {
            return soild_prob;
        }

        set
        {
            soild_prob = value;
        }
    }

    public static string Goomba_prob
    {
        get
        {
            return goomba_prob;
        }

        set
        {
            goomba_prob = value;
        }
    }
}

public class Tuple<T1, T2>
{
    public T1 First { get; set; }
    public T2 Second { get; set; }
    internal Tuple(T1 first, T2 second)
    {
        First = first;
        Second = second;
    }
}

public enum Element_type {
    Goomba,
    Soild,
    Pipe
}
