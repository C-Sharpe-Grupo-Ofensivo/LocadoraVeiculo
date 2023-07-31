
using FluentValidation.Results;

namespace LocadoraVeiculo.Dominio.Compartilhado {
    public interface IValidador<T> where T : EntidadeBase<T> {
        public ValidationResult Validate(T instance);
    }
}
