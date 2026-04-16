namespace JewelleryApi.Models.Dtos
{
    public class CreateJewelleryDto
    {
        public string Name{get; set;}= string.Empty;

        public string Material{get; set;} = string.Empty;
        public string Category{ get; set;} = string.Empty;
        public decimal Price{ get; set;}

        public int Quantity{ get; set;} 
    }
}