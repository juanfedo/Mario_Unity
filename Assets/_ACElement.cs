using System;
using System.Collections.Generic;
using UnityEngine;


abstract public class _ACElement : MonoBehaviour
{    
    protected bool Validate_Overlap(float x, float y,float size_x = 1)
    {
        
        Collider2D[] collisions = Physics2D.OverlapBoxAll(new Vector2(x,y), new Vector2(size_x,1), Vector2.Angle(Vector2.zero, new Vector2(x, y)));
        //print("Validando objeto en X: " + x.ToString() + " Y: " + y.ToString() + " con size: " + size_x.ToString() + " colisiones: " + collisions.Length.ToString());
        //if (collisions.Length > 0 && size_x ==2)
        //    print("Entro a la colision en " +x.ToString());
        return collisions.Length == 0;        
    }

    protected void Instantiate_Element(GameObject element, List<Tuple<float, float>> coord,int temp = 0)
    {
        foreach (Tuple<float, float> t in coord)
        {
            GameObject temp_obj = Instantiate(element, new Vector3(t.First, t.Second - 0.5f, 0), Quaternion.identity) ;
            if (temp > 0)
            {
                Collider2D[] collisions = Physics2D.OverlapBoxAll(new Vector2(t.First, t.Second - 0.5f), new Vector2(1.9f, 0.9f), Vector2.Angle(Vector2.zero, temp_obj.transform.position));
                //print("INSTANCIANDO objeto en coordenadas " + temp_obj.transform.position.ToString() + " escala: " + temp_obj.transform.localScale.ToString() + " colisiones: " + collisions.Length.ToString());
                if (collisions.Length > 1)
                {
                    foreach (Collider2D collider in collisions)
                    {
                        //print("colisiona con: " + collider.tag);
                        if(collider.gameObject != temp_obj)
                            Destroy(temp_obj);                
                    }
                }
            }            
        }
        
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
