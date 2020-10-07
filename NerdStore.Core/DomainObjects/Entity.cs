using System;

namespace NerdStore.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        //para comparar diferentes objetos que são a mesma entidade
        //camiseta == short ? ambos são produtos mas não são a mesma coisa
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        //Realizar a mesma função do equals ao comparar
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return true;

            return a.Equals(b);
        }

        //negação do == dessa classe
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        //hash code é um código exclusivo da classe
        //para não ter diferença, pega o hash code dessa classe
        //multiplica por um numero aleatório e soma com o hash do Id
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
