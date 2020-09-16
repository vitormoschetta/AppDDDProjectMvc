using System;
using Flunt.Notifications;

namespace AppDDDProject.Shared.Entities
{
    public abstract class Entity : Notifiable, IEquatable<Entity>
    {
        public Entity(Guid id)
        {
            Id = Guid.NewGuid();
        }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }


        // Implementação de interface IEquatable 
        // Verifica se duas entidades são iguais.
        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}