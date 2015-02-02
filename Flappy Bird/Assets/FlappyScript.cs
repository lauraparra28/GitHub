using UnityEngine;
using System.Collections;

public class flappyScript : MonoBehaviour {
	//Declaramos la velocidad inicial del pajaro sea igual a zero, Vector3.zero = 0,0,0
	//Es un objeto en memoria que tiene el valor de 1,1,0 (x,y,z)
	Vector3 velocidad = Vector3.zero;
	//Declaramos un vector que controle la gravedad, no usaremos la fisica de unity
	// la fisica de unity es muy pesada, poco incontrolable y complicada de manejar
	public Vector3 gravedad;
	//Declaramos un vector que define el salto (aleteo) del pajaro
	public Vector3 velocidadAleteo;
	//Declaramos si se debe aletear, si se toco la pantalla o se presiono espacio
	// define cuanto va a saltar
	bool aleteo = false; // pasa a true cuando tocan la pantalla o barra especiadora o mouse
	//Declaramos la velocidad maxima de rotacion del pajaro
	//cuando se rota el parajo sube a arriba cuando anda y abajo cuando cae
	public float velocidadMaxima;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update (){
		//Si la persona presiona el boton de espacio o hace clic en la pantalla con el mouse
		// es la entrada cuando se presiona la tecla
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			aleteo = true;
		}
	}
	
	//Este es el update de la fisica, que es ligeramente mas lento que el update del juego
	void FixedUpdate () {
		//A la velocidad le sumamos la gravedad (Para que el pajaro caiga)
		velocidad += gravedad * Time.deltaTime;
		
		//Si presionaron espacio o hicieron clic
		if (aleteo == true)
		{
			//Que solo sea una vez
			aleteo = false;
			//El vector velocidad recibe el impulso hacia arriba al pajaro
			velocidad.y = velocidadAleteo.y;
		}
		//Hacemos que el pajaro reciba la velocidad (la gravedad lo hace caer mas rapido)
		transform.position += velocidad * Time.deltaTime;
		float angulo = 0;
		if (velocidad.y >= 0) {
			//Cambiamos el angulo si Y es positivo que mire arriba
			angulo = Mathf.Lerp (0, 25, velocidad.y/velocidadMaxima);
		}
		else {
			//Cambiamos el angulo si Y es negativo que mire abajo
			angulo = Mathf.Lerp (0, -75, -velocidad.y/velocidadMaxima);
		}
		//Rotamos
		transform.rotation = Quaternion.Euler (0, 0, angulo);
	}
}