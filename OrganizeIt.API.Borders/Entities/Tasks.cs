using OrganizeIt.API.Borders.Enums;

namespace OrganizeIt.API.Borders.Entities
{
    public class Tasks : DatabaseEntityBase<Guid>
    {
        public virtual string? Titulo { get; private set; }
        public virtual string? Descricao { get; private set; }
        public virtual Prioridades? Prioridade { get; private set; }
        public virtual DateTime DataCriacao { get; private set; }
        public virtual DateTime? DataConclusao { get; private set; }
        public virtual bool Concluida { get; private set; }
    }
}