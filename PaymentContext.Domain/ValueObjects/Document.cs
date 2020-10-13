using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EdocumentType type)
        {
            Number = number;
            Type = type;
            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido")
                );
        }
        public string Number { get; private set; }

        public EdocumentType Type { get; private set; }

        private bool Validate()
        {
            if (Type == EdocumentType.CNPJ && Number.Length == 14)
                return true;


            if (Type == EdocumentType.CPF && Number.Length == 11)
                return true;

            return false;
        }

    }
}