using System.Collections.Generic;
using System.IO;

namespace IRM.WebLeilao.Api.Common.Helpers
{
    public static class ImportacaoHelper
    {
        public static List<string> ConverterByteToList(byte[] arquivoRetorno)
        {
            Stream s = new MemoryStream(arquivoRetorno);
            var lista = new List<string>();

            using (StreamReader sr = new StreamReader(s))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lista.Add(line);
                }
            }

            return lista;
        }
        
    }
}