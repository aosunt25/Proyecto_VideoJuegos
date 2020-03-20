using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InformacionDeJugar
{
  
    public int cartas;
    public int acto;
    public float[] posicion;
    public int[] cartasActivarInventario;

    public InformacionDeJugar( GameMaster juego)
    {
        cartas = juego.GetCartas();
        acto = juego.escenaActual;
        posicion = new float[2];
        posicion[0]=juego.GetClonePlayerPositionX();
        posicion[1] = juego.GetClonePlayerPositionY();

        cartasActivarInventario = juego.CartasaActivar();

    }
}
