using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

           AddNotifications(
                new ValidationContract()
                .Requires()
                .HasMinLen(firstName, 3, "FirstName", "Nome dever conter pelo menos 3 caracteres")
                .HasMaxLen(firstName, 40,"FirstName", "Nome só pode conter até 40 caracteres.")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString(){
            return $"{FirstName} {LastName}";
        }
    }
}