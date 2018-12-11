using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_3_Hashing
{
    public class Hash
    {
        public void Menu()
        {
            Console.WriteLine("¿Que numero de ejemplo?");
            Console.WriteLine("1 o 2 y  otro para salir");//0 para que se realize la accion default que es salirse
            int numero = int.Parse(Console.ReadLine());

            switch (numero)
            {
                case 1:
                    Console.Clear();
                    ejemplo1();

                    Console.ReadKey();
                    Menu();//Regresa al menu
                    break;
                case 2:
                    Console.Clear();
                    ejemplo2();

                    Console.ReadKey();
                    Menu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Adios");
                    break;

            }
        }

        public void ejemplo1()
        {
            Console.WriteLine("Tamaño del arreglo: ");
            int tamaño = int.Parse(Console.ReadLine());

            int[] arreglo = new int[tamaño];
            int opcion;

            do
            {
                Console.WriteLine("¿Que desea hacer?");
                Console.Write(" 1. Insertar elemento \n 2. Mostrar elementos\n 3.Buscar elemento 0. salir\n");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1://insertaelemento en una tabla hash

                        int elemento, posicion, contador = 0;
                        Console.WriteLine("Insertar elemento");
                        elemento = int.Parse(Console.ReadLine());

                        posicion = elemento % tamaño;
                        int t = tamaño;

                        while (arreglo[posicion] != int.MinValue)//el int minvalue y int maxvalue indican si esta vacio el espacio
                        {
                            if (arreglo[posicion] == int.MaxValue)//si el indice esta vacio se hace break para ir abajo e insertar elemento
                                break;
                            posicion = (posicion + 1) % t;
                            contador++;
                            if (contador == tamaño)
                                break;      //si la tabla esta llena se debe hacer break para que no se un ciclo infinito
                        }

                        if (contador == tamaño)
                            Console.Write("Tabla hash estaba llena\nNo No hay lugar para insertar elemento\n\n");
                        else
                            arreglo[posicion] = elemento;    //Inserta elemento

                        break;
                    case 2://muestra tabla hash
                        int c = 0;
                        foreach (int e in arreglo)
                        {
                            Console.WriteLine("indice: {0}  elemento: {1}", c, e);
                            c++;
                        }
                        Console.Write("\n\n");

                        break;
                    case 3:
                       
                        int elemento2, posicion2, contador2 = 0;

                        Console.WriteLine("Elemento a buscar:");
                        elemento2 = int.Parse(Console.ReadLine());
                        int t2 = tamaño;//copia de tamaño del arreglo para ser modificado

                        posicion2 = elemento2 % t2;//pisicion segun formula

                        while (contador2++ != tamaño)//si el contador no es igual a tamaño
                        {
                            if (arreglo[posicion2] == elemento2)//si se enecuentra en posicion segun formula te dice el indice
                            {
                                Console.Write("Elemento enecontrado en el indice {0}", posicion2);
                                break;
                            }
                            else//de lo contrario suma 1 a posicion para ir recorriendo
                                if (arreglo[posicion2] == int.MaxValue || arreglo[posicion2] != int.MinValue)
                                posicion2 = (posicion2 + 1) % t2;
                        }
                        if (--contador2 == tamaño) Console.Write("Elemento no encontrado \n");// si el contador es del tamaño de arreglo es porque recorrio todo y no lo encontro

                        break;
                    case 0:
                        break;

                    default:
                        Console.Write("Inserte opcion correcta\n");
                        break;
                }
            } while (opcion != 0);

        }

        public void ejemplo2()
        {

            int tamaño = 26;
            char[] letras = new char[tamaño];
            int opcion;

            do
            {
                Console.WriteLine("¿Que desea hacer?");
                Console.Write(" 1. Insertar letra \n 2. Mostrar tabla hash\n 3.Buscar letra 0. salir\n");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1://inserta letra en una tabla hash

                        
                        int posicion, contador = 0;
                        char letra='\0';
                        int ascii=0;
                        do
                        {

                            try
                            {
                                Console.WriteLine("insertar letra minuscula");//pide insertar letra
                                letra= char.Parse(Console.ReadLine());

                                ascii = Convert.ToInt32(letra);//convierte letra  a ascii
                                if ( ascii< 97 || ascii>122)//lanza excepcion si no son minusculas
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Debe ser letra minuscula", e);//mensaje a usuario para que corrija
                            }
                        } while (ascii < 97 || ascii > 122);


                        posicion = ascii-97;//esta sera mi funcion hash para letras, convirtiendo la letra a numero y restandole 97 para que deje de ser el numero ASCII 
                        

                        while (letras[posicion]!='\0')
                        {
                            
                            posicion++;
                            contador++;
                            if (contador == tamaño)
                                break;      //si la tabla esta llena se debe hacer break para que no se un ciclo infinito
                        }

                        if (contador == tamaño)
                        {
                            Console.Write("Tabla hash estaba llena\nNo No hay lugar para insertar letra\n\n");
                        }
                        else
                        {
                            letras[posicion] = letra;    //Inserta elemento
                        }
                        break;
                    case 2://muestra tabla hash
                        int c = 0;
                        foreach (char l in letras)
                        {
                            Console.WriteLine("indice: {0}  elemento: {1}", c, l);
                            c++;
                        }
                        Console.Write("\n\n");

                        break;
                    case 3:
                        int posicion2, contador2 = 0, ascii2=0;
                        char letra2 = '\0';
                        do
                        {

                            try
                            {
                                Console.WriteLine("insertar letra minuscula a buscar");
                                letra2 = char.Parse(Console.ReadLine());
                                ascii2 = Convert.ToInt32(letra2);
                                if (ascii2 < 97 || ascii2 > 122)//lanza excepcion si no son minusculas
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Debe ser letra minuscula", e);//mensaje a usuario para que corrija
                            }
                        } while (ascii2 < 97 || ascii2 > 122);


                        posicion2 = ascii2 - 97;//esta sera mi funcion hash para letras, convirtiendo la letra a numero y restandole 97 para que deje de ser el numero ASCII 
                      
                       

                        while (contador2++ != tamaño)
                        {
                            if (letras[posicion2] == letra2)
                            {
                                Console.Write("Elemento enecontrado en el indice {0}", posicion2);
                                break;
                            }
                            else
                                if (letras[posicion2] == '\0')
                                posicion2 ++;
                        }
                        if (--contador2 == tamaño) Console.Write("Letra no encontrada \n");

                        break;
                    case 0:
                        break;

                    default:
                        Console.Write("Inserte opcion correcta\n");
                        break;
                }
            } while (opcion != 0);
        }


    }
}
