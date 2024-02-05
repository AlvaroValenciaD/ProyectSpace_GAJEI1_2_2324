using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    //Tag para diferenciar con el rayo
    public string tagSeleccionable = "Selectable";
    public GameObject playerPosition;
    public float interactDistance;

    public GameObject key1;
    public GameObject key2;
    public GameObject door1;
    public GameObject door2;
    int keyCounter;
    // almacena los materiales de resaltado y actual del objeto
    public Material materialResaltado;
    public Material materialBase;
    
    //objeto siendo elegido
    public Transform objetoSeleccionado;
    
    void SeleccionManager()
    {


        //si deselecionas un objeto...
        if (objetoSeleccionado != null)
        {
            //...Almacena el renderer...
            Renderer rendererDeSeleccion = objetoSeleccionado.GetComponent<Renderer>();
           
            //...Y conviertelo en el material que tenia antes de ser seleccionado...
            rendererDeSeleccion.material = materialBase;
           
            //...Deselecciona el objeto
            objetoSeleccionado = null;
        }
        
        // almacena el rayo de la posicion del raton como un rayo que emerge de la camara
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        // almacena el objeto tocado
        RaycastHit hit;
       
        //si golpeas con el rayo
        if (Physics.Raycast(rayo, out hit))
        {
            // esta mierda almacena el material actual del objeto que estas seleccionando en el material base
            Renderer rendererTemporal = hit.transform.gameObject.GetComponent<Renderer>();
            materialBase = rendererTemporal.material;
            //almacena la posicion del objeto golpeado
            Transform seleccion = hit.transform;

            // si la sellecion lleva el tag...
            if (seleccion.CompareTag(tagSeleccionable))
            {
                //cogemos el renderer del objeto 
                Renderer seleccionRenderer = seleccion.GetComponent<Renderer>();
                
                // en caso de que no coja ningun renderer... 
                if (seleccionRenderer != null)
                {
                    //...lo convertimos en material resaltado
                    seleccionRenderer.material = materialResaltado;
                }

                // almacenamos el objeto selecionado para uso mas tarde
                objetoSeleccionado = seleccion;
            }
        }
    }

    private void Update()
    {
        SeleccionManager();

        if (objetoSeleccionado != null)
        {
            float distance = Vector3.Distance(playerPosition.transform.position, objetoSeleccionado.transform.position);
            if (distance < interactDistance)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (objetoSeleccionado == key1 || objetoSeleccionado == key2)
                    {
                        keyCounter++;
                        Destroy(objetoSeleccionado);
                    }
                    else if (objetoSeleccionado == door1 || objetoSeleccionado == door2)
                    {
                        // movimiento de la puerta 
                    }
                }
            }
            else
            {
                Debug.Log("Acercate al objeto");
            }
        }
    }
}