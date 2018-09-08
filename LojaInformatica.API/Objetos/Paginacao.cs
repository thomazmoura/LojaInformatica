namespace LojaInformatica.API.Objetos
{
    public class Paginacao
    {
        public string NomeParametro { get; set; }
        public bool Ascendente { get; set; }
        public int Tamanho { get; set; }
        public int Pagina { get; set; }
        public int ElementosParaPular => Tamanho * (Pagina - 1);
    }
}
