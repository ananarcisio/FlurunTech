using ControleDeVinil.Shared.Modelos.Modelos;

namespace ControleDeVinil.Shared.Dados.Banco
{
    public class DAO<T> where T: class
    {
        public Contexto context;

        public DAO(Contexto context)
        {
            this.context = context;
        }

        public IEnumerable<T> ObterTodos()
        {
            return this.context.Set<T>().ToList();
        }

        public void Criar(T novoItem)
        {
            this.context.Set<T>().Add(novoItem);
            this.context.SaveChanges();
        }

        public void Atualizar(T itemAAlterar)
        {
            this.context.Set<T>().Update(itemAAlterar);
            this.context.SaveChanges();
        }

        public void Excluir(T itemAExcluir)
        {
            this.context.Set<T>().Remove(itemAExcluir);
            this.context.SaveChanges();
        }

        public T? LocalizarPor(Func<T, bool> condicao)
        {
            return this.context.Set<T>().FirstOrDefault(condicao);
        }
    }
}
