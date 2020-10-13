using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void DeveRetornarErroQuandoDocumentoExistir()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "99999999999";
            command.Email = "batman@dc.com";
            command.BarCode = "123456789";
            command.BoletoNumber = "123456789";
            command.PaymentNumber = "12345";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now;
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Wayne Corp";
            command.PayerEmail = "batman@dc.com";
            command.PayerDocument = "99999999911";
            command.PayerDocumentType =EdocumentType.CPF;
            command.Street ="asdad";
            command.Number ="asdasd";
            command.NeighBorhood ="asdas";
            command.City = "as";
            command.State ="as";
            command.Country ="as";
            command.ZipCode ="12345678";

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }
    }
}