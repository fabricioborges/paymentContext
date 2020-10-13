using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Subscription _subscription;
      
        
        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("45638719075", EdocumentType.CPF);
            _email = new Email("batman@dc.com");
            _student = new Student(_name, _document, _email);
             _address = new Address("rua 1", "134", "bairro legal", "Gotham", "SP", "BR", "88500000");
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void DeveRetornarErroQuandoJaTiverUmaAssinaturaAtiva()
        {
            //Arrange           
            var payment = new PayPalPayment("123456", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "Wayne CORP", _address, _email);

            //Action
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            //Assert
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void DeveRetornarErroQuandoTiverUmaAssinaturaAtivaSemPagamento()
        {            
            //Action
            _student.AddSubscription(_subscription);           

            //Assert
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoNaoTiverUmaAssinaturaAtiva()
        {
            //Arrange           
            var payment = new PayPalPayment("123456", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "Wayne CORP", _address, _email);

            //Action
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            //Assert
            Assert.IsTrue(_student.Valid);
        }
    }
}