namespace IRM.WebLeilao.Domain.ValueObjects
{
    public class CNS : IdentificacaoPessoa
    {
        public string Numero { get; private set; }

        public CNS(string numero)
        {

            Numero = numero;

            if ((!ValidaCns(numero) || !ValidaCnsProv(numero)))
            {
                AddNotification("Numero", "CNS Inválido.");
            }

        }

        public bool ValidaCns(string cns)
        {
            if ((cns.Trim().Length != 15))
            {
                return false;
            }

            float soma;
            float dv;
            float resto;
            string pis = new string("");
            string resultado = new string("");
            pis = cns.Substring(0, 11);
            soma = ((int.Parse(pis.Substring(0, 1)) * 15)
                        + ((int.Parse(pis.Substring(1, 1)) * 14)
                        + ((int.Parse(pis.Substring(2, 1)) * 13)
                        + ((int.Parse(pis.Substring(3, 1)) * 12)
                        + ((int.Parse(pis.Substring(4, 1)) * 11)
                        + ((int.Parse(pis.Substring(5, 1)) * 10)
                        + ((int.Parse(pis.Substring(6, 1)) * 9)
                        + ((int.Parse(pis.Substring(7, 1)) * 8)
                        + ((int.Parse(pis.Substring(8, 1)) * 7)
                        + ((int.Parse(pis.Substring(9, 1)) * 6)
                        + (int.Parse(pis.Substring(10, 1)) * 5)))))))))));
            resto = (soma % 11);
            dv = (11 - resto);
            if ((dv == 11))
            {
                dv = 0;
            }

            if ((dv == 10))
            {
                soma = ((int.Parse(pis.Substring(0, 1)) * 15)
                            + ((int.Parse(pis.Substring(1, 1)) * 14)
                            + ((int.Parse(pis.Substring(2, 1)) * 13)
                            + ((int.Parse(pis.Substring(3, 1)) * 12)
                            + ((int.Parse(pis.Substring(4, 1)) * 11)
                            + ((int.Parse(pis.Substring(5, 1)) * 10)
                            + ((int.Parse(pis.Substring(6, 1)) * 9)
                            + ((int.Parse(pis.Substring(7, 1)) * 8)
                            + ((int.Parse(pis.Substring(8, 1)) * 7)
                            + ((int.Parse(pis.Substring(9, 1)) * 6)
                            + ((int.Parse(pis.Substring(10, 1)) * 5)
                            + 2)))))))))));
                resto = (soma % 11);
                dv = (11 - resto);
                resultado = (pis + ("001" + ((int)(dv)).ToString()));
            }
            else
            {
                resultado = (pis + ("000" + ((int)(dv)).ToString()));
            }

            if (!cns.Equals(resultado))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool ValidaCnsProv(string cns)
        {
            if ((cns.Trim().Length != 15))
            {
                return false;
            }

            float soma;
            float resto;
            soma = ((int.Parse(cns.Substring(0, 1)) * 15)
                        + ((int.Parse(cns.Substring(1, 1)) * 14)
                        + ((int.Parse(cns.Substring(2, 1)) * 13)
                        + ((int.Parse(cns.Substring(3, 1)) * 12)
                        + ((int.Parse(cns.Substring(4, 1)) * 11)
                        + ((int.Parse(cns.Substring(5, 1)) * 10)
                        + ((int.Parse(cns.Substring(6, 1)) * 9)
                        + ((int.Parse(cns.Substring(7, 1)) * 8)
                        + ((int.Parse(cns.Substring(8, 1)) * 7)
                        + ((int.Parse(cns.Substring(9, 1)) * 6)
                        + ((int.Parse(cns.Substring(10, 1)) * 5)
                        + ((int.Parse(cns.Substring(11, 1)) * 4)
                        + ((int.Parse(cns.Substring(12, 1)) * 3)
                        + ((int.Parse(cns.Substring(13, 1)) * 2)
                        + (int.Parse(cns.Substring(14, 1)) * 1)))))))))))))));
            resto = (soma % 11);
            if ((resto != 0))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}