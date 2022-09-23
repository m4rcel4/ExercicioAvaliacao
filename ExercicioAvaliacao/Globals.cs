using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioAvaliacao
{
    internal class Globals
    {
        // precisar uma classe para criara uma variável data
        // essa nova variável será usada para pegar a data, que o visualStudio retorna (como string) e ser convertida em dateTime, na ordem invertida.
        // data invertida exigida pelas configurações do banco, que só recebe DATE.


        public static DateTime data;
        public static string dataNova;



        public static DateTime dataVenc;
        public static string dataVencimento;


        public static int recebido;
        




        public static DateTime Data { get; set; }

        public static string DataNova { get; set;}




        public static DateTime DataVenc { get; set; }

        public static string DataVencimento { get; set; }




        public static int  Recebimento { get; set; }

       
    }
}
