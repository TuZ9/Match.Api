namespace Suitability.Domain.Entities
{
    public class Document
    {
        public Guid IdDocument { get; set; }
        public required string ClientName { get; set; }
        public required string CPF { get; set; }
        public required string RG { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public required string Email { get; set; }
        private string _DocumentNumber;
        public required string DocumentNumber
        {
            get => _DocumentNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length != 9 || !long.TryParse(value.Trim(), out _))
                {
                    throw new ArgumentException("Document number must be exactly 9 digits.");
                }
                _DocumentNumber = value.Trim();
            }
        }
    }
}
