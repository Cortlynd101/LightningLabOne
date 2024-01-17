using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Pages
{
    [Serializable]
    public class Payment
    {
        [Required(ErrorMessage = "Pick up method is required.")]
        public bool IsDelivery {  get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Card Number is required.")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Experation date is required.")]
        public DateOnly ExpirationDate { get; set; }
        [Required(ErrorMessage = "CVV is required.")]
        public int Cvv { get; set; }
        [Required(ErrorMessage = "Address Is Requred if you are doing a delivery")]
        public string Address { get => IsDelivery ? Address : "" ; set => Address = value; }
    }
}
