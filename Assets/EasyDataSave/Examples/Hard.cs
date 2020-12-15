using UnityEngine;

// Primero que nada necesitamos importar la libreria para poder hacer uso del
// sistema de guardadoo y cargado de datos
using EasyDataSave;

public class Hard : MonoBehaviour
{
    string _path = Application.persistentDataPath; // Al ser esta la manera (dificil) por asi decirlo, necesitamos especificar la ruta en la que se guardaran los datos
    string _key = "TU_KEY_PARA_ENCRIPTACIÓN"; // Este texto es la llave con la que se encriptarán los datos para que sean inaccesibles por terceros (Nunca la reveles y guardala bien, porque de perderla se pierden los datos)

    public UserData userData;

    // Para Hacer uso del método Hard (este) es recomendable eliminar el script
    // ManagerData debido a que pueden ocurrir confuciones

    void Start()
    {
        // Como Recomendación, para generar una key de encriptación la libreria
        // contiene una función con un algoritmo para generar un texto random,
        // para hacer uso de esa función hacemos los siguiente
        Debug.Log("Texto Random: " + SaveDataManager.RandomId()); // Por defecto crea un texto con 15 caracteres, mayusculas, minusculas y simbolos
        // Si desea cambiar algun parametro de la funcion puede hacerlo de las
        // siguientes maneras
        //
        SaveDataManager.RandomId(Length:30); // Esto genera un texto con 30 caracteres de longitud
        SaveDataManager.RandomId(Mayusculas:false); // Esto quita las mayusculas en la generacion del texto
        SaveDataManager.RandomId(minusculas:false); // esto quita las minusculas en la generacion del texto
        SaveDataManager.RandomId(simbolos:false); // esto quita los simbolos de la generacion del texto
        // asi mismo varias opciones pueden ser anidadas de la siguiente manera
        SaveDataManager.RandomId(Length:30, simbolos:false);
        // Ojo cada que se llama a esta función genera un nuevo texto random
        // con los parametros indicados, no se guarda la configuración
        // establecida
        //
        // Recomiendo usar esta funcion cambiando el lenght para crear la llave
        // (luego introducirla de manera manual en una variable)
        
        
        //Verificamos que los datos existan
        if(!SaveDataManager.Exist(typeof(UserData), _path)){
            userData = new UserData();
            // para guardar los datos existen dos maneras, una de ellas es:
            userData.Save<UserData>(_path, _key, true); // el parametro true no es obligatorio ya que siempre será false, pero este indica si se desea guardar los parametros privados de la clase
            // otra manera es:
            SaveDataManager.Save(userData, _path, _key, true); // el mismo caso para el parámetro true
        }else{
            // para cargar los datos tenemos dos opciones de igual manera
            userData = SaveDataManager.Load<UserData>(_path, _key, true); // En este caso tenemos que indicar la clase que se desea cargar, la ruta y la llave
            // otra opción es:
            userData.Load<UserData>(_path, _key, true); // En este caso se aplican las mismas circunstancias que el anterior

        }
    }
}
