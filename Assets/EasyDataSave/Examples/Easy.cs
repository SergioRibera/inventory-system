using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : MonoBehaviour
{
    public UserData userData;

    void Start()
    {
        if(!ManagerData.Exist(typeof(UserData))){ // De esta manera revisamos si existen o no, datos guardados para la clase UserData
            userData = new UserData();
            // Para guardar los datos existen dos maneras de hacerlo, una de
            // ellas es la siguiente
            //
            // El true como parámetro no es necesario ya que por defecto tiene
            // false, ese determina si se guardarán los datos privados de la
            // clase, por ejemplo, en nuestra clase UserData coins es privado
            // al pasarle true, le indicamos que también guarde los datos de
            // coins
            ManagerData.Save(userData, true);
            // la misma situeción con el parámetro true tenemos en este método
            // de guardado
            userData.Save<UserData>(true);

        }else{

            // Si existen datos, los cargamos
            //
            // El true como parámetro indica que tiene que cargar los datos
            // privados que se hayan guardado, no es obligatorio ya que por
            // defecto está en false
            userData = ManagerData.Load<UserData>(true);
            // La misma situacipon con el parámetro true ocurre en este método
            userData.Load<UserData>(true);
        }
    }
}
