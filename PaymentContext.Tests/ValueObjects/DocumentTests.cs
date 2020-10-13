using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void DeveRetornarErroQuandoCNPJForInvalido()
        {
            var doc = new Document("123", EdocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoCNPJForValido()
        {
            var doc = new Document("48003444000107", EdocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void DeveRetornarErroQuandoCPFForInvalido()
        {
            var doc = new Document("123", EdocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }


        [TestMethod]
        public void DeveRetornarErroQuandoCPFForValido()
        {
            var doc = new Document("45638719075", EdocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}