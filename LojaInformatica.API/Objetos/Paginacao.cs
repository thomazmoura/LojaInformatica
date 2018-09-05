namespace LojaInformatica.API.Objetos
{
    public class Paginacao
    {
        public int Tamanho { get; set; }
        public int Pagina { get; set; }
        public int ElementosParaPular => Tamanho * (Pagina - 1);
    }
}
