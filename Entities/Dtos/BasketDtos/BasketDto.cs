namespace Entities.Dtos.BasketDtos
{
    public class BasketDto
    {
        public decimal Price { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
    }
}
