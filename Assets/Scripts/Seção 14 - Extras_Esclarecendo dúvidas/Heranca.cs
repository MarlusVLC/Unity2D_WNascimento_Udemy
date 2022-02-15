using UnityEngine;

public class Heranca : MonoBehaviour
{
    private Carro car;
    private Moto moto;

    private void Start()
    {
        car = new Carro();
        car.motorP = 400f;
        car.combQtd = 57;
        car.nPessoas = 1000;
        moto.motorP = Mathf.PI;
    }
    /*
     *  1- Motor P
     *  2- Combustível qtd
     *  3- N-Pessoas
     */

    class Veiculo
    {
        public float motorP;
        public int combQtd;
        public int nPessoas;
    }
    
    class Carro : Veiculo
    {
        public string espCarro;
    }

    class Moto : Veiculo
    {
        public string espMoto;
    }
    
    
}