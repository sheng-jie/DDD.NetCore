using System;

namespace DDD.NetCore.Exception
{
    /// <summary>
    /// This exception is thrown if an entity excepted to be found but not found.
    /// </summary>
    public class EntityNotFoundException : ExceptionBase
    {
        /// <summary>
        /// Type of the entity.
        /// </summary>
        public Type EntityType { get; set; }

        /// <summary>
        /// Id of the Entity.
        /// </summary>
        public object Id { get; set; }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException"/> object.
        /// </summary>
        public EntityNotFoundException()
        {

        }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException"/> object.
        /// </summary>
        public EntityNotFoundException(Type entityType, object id)
            : this(entityType, id, null)
        {

        }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException"/> object.
        /// </summary>
        public EntityNotFoundException(Type entityType, object id, System.Exception innerException)
            : base($"There is no such an entity. Entity type: {entityType.FullName}, id: {id}", innerException)
        {
            EntityType = entityType;
            Id = id;
        }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public EntityNotFoundException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public EntityNotFoundException(string message, System.Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
