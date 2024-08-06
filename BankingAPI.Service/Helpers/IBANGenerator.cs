namespace BankingAPI.Service.Helpers
{
    public class IBANGenerator
    {
        public static string GenerateIban(string bankCode, string accountNumberPrefix, string accountNumber)
        {
            string paddedAccountNumber = accountNumber.PadLeft(16, '0');
            string bban = bankCode + accountNumberPrefix + paddedAccountNumber;
            string initialIban = "TR00" + bban;
            string numericIban = ConvertToNumericIban(initialIban);
            string checkDigits = CalculateCheckDigits(numericIban);
            string iban = "TR" + checkDigits + bban;

            return iban;
        }

        private static string ConvertToNumericIban(string iban)
        {
            string numericIban = "";

            foreach (char c in iban)
            {
                if (char.IsLetter(c))
                {
                    numericIban += (c - 'A' + 10).ToString();
                }
                else
                {
                    numericIban += c.ToString();
                }
            }

            return numericIban;
        }

        private static string CalculateCheckDigits(string numericIban)
        {
            string rearrangedIban = numericIban.Substring(4) + numericIban.Substring(0, 4);
            string remainder = rearrangedIban;
            while (remainder.Length > 2)
            {
                int blockSize = Math.Min(remainder.Length, 9);
                int block = int.Parse(remainder.Substring(0, blockSize));
                remainder = (block % 97).ToString() + remainder.Substring(blockSize);
            }

            int mod97 = int.Parse(remainder) % 97;
            int checkDigits = 98 - mod97;

            return checkDigits.ToString("D2");
        }
    }
}
