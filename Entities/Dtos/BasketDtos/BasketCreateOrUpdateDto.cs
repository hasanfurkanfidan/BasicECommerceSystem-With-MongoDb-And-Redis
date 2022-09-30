namespace Entities.Dtos.BasketDtos
{
    public class BasketCreateOrUpdateDto
    {
        public string UserName { get; set; }
        public string ProductId { get; set; }
        public int Count { get; set; }
        /// <summary>
        /// Sepete eklenme durumunda true çıkartma durumunda false olacak
        /// </summary>
        public bool IsAdded { get; set; }
    }
}
