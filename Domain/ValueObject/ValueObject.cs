namespace Domain.ValueObjects

{

    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object valueObject)
        {
            var objDeValor = valueObject as T;

            if (ReferenceEquals(objDeValor, null))
                return false;

            return EqualsCore(objDeValor);
        }

        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return (int)GetHashCodeCore();
        }

        protected abstract decimal GetHashCodeCore();

        public static bool operator ==(ValueObject<T> objectA, ValueObject<T> objectB)
        {
            if (ReferenceEquals(objectA, null) && ReferenceEquals(objectB, null))
                return true;

            return objectA.Equals(objectB);
        }

        public static bool operator !=(ValueObject<T> objectA, ValueObject<T> objectB)
        {
            return !(objectA == objectB);
        }

    }
}
