namespace Suitability.Account.Domain.Entities
{
    public class Account
    {
        public Guid IdAccount { get; set; }
        public string ClientName { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        private string _accountNumber;
        public string AccountNumber
        {
            get => _accountNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length != 9 || !long.TryParse(value.Trim(), out _))
                {
                    throw new ArgumentException("Account number must be exactly 9 digits.");
                }
                _accountNumber = value.Trim();
            }
        }
        public Account() { }

        public Account(Guid idAccount, string clientName, string cpf, string rg, DateTime dateOfBirth, string address, string phone, string email, string accountNumber)
        {
            IdAccount = idAccount;
            ClientName = clientName;
            CPF = cpf;
            RG = rg;
            DateOfBirth = dateOfBirth;
            Address = address;
            Phone = phone;
            Email = email;
            AccountNumber = accountNumber;
        }
    }
}
