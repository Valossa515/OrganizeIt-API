using OrganizeIt.API.Borders.Enums;

namespace OrganizeIt.API.Borders.Entities
{
    public class Tasks : DatabaseEntityBase<Guid>
    {
        public virtual string? Titulo { get; set; }
        public virtual string? Descricao { get; set; }
        public virtual Prioridades? Prioridade { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual DateTime? DataConclusao { get; set; }
        public virtual bool Concluida { get; set; }
    }
}