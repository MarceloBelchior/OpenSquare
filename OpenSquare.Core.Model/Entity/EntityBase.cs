namespace OpenSquare.Core.Model.Entity
{
    public class EntityBase
    {
        public int id { get; set; }
        public override bool Equals(object obj)
        {
            // Se for nulo, já retorna falso
            if (obj == null)
                return false;

            // Se não puder fazer o cast para EntidadeBase,
            // falso também
            var entidade = obj as EntityBase;
            if (entidade == null)
                return false;

            // Se o Id for igual a zero, é uma nova entidade,
            // nesse caso verificar se é a mesma referencia em memória
            if (entidade.id == 0 && id == 0)
                return ReferenceEquals(this, entidade);

            // Agora Returna true se o Id for o mesmo
            // para entidades do mesmo tipo
            return (id == entidade.id && GetType() == entidade.GetType());
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
