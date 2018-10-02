using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace SistemaFac.Leitor
{
    public static class Ler
    {
        private static Encoding encoding = Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage);
        private static StringBuilder builder;

        public static StringBuilder Arquivo(string arquivoEntrada, char delimitador, int campo, int min, int max)
        {
            builder = new StringBuilder();

            using (var reader = new StreamReader(arquivoEntrada, encoding))
            {
                var books =
                  from line in reader.Lines()
                  let parts = line.Split(delimitador)
                  select new {Teste = parts[campo] };

                builder.Append(books);
            }

            return builder;
        }
    }
}
