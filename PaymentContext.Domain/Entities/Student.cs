using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public bool Active { get; private set; }
        public string Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubsceiption(Subscription subscription)
        {
            //Se já tiver uma assinatura ativa, cancela

            //Cancela todas as outras assinaturas e coloca essa como principal

            var hasSubscriptionActive = false;

            foreach (var sub in Subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }


            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
                );

            // Alternativa
            // if(hasSubscriptionActive)
            //     AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");
        }
    }
}