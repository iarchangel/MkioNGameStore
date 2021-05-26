using OpenOrderFramework.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OpenOrderFramework.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {

        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Укажите имя!")]
        [DisplayName("Имя")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Укажите фамилию!")]
        [DisplayName("Фамилия")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Укажите адрес!")]
        [StringLength(70)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Укажите город!")]
        [StringLength(40)]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите регион/область!")]
        [StringLength(40)]
        public string State { get; set; }

        [Required(ErrorMessage = "Укажите почтовый индекс!")]
        [DisplayName("Почтовый индекс")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Укажите страну!")]
        [StringLength(40)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Укажите номер телефона!")]
        [StringLength(24)]
        public string Phone { get; set; }

        [Display(Name = "Срок  годности")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Experation { get; set; }

        [Display(Name = "Карта")]
        [NotMapped]
        [Required]
        [DataType(DataType.CreditCard)]
        public String CreditCard { get; set; }

        [Display(Name = "Тип карты")]
        [NotMapped]
        public String CcType { get; set; }

        public bool SaveInfo { get; set; }


        [DisplayName("Адрес электронной почты")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Почта введена не верно.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

       

        public string ToString(Order order)
        {
            StringBuilder bob = new StringBuilder();

            bob.Append("<p>Order Information for Order: "+ order.OrderId +"<br>Placed at: " + order.OrderDate +"</p>").AppendLine();
            bob.Append("<p>Name: " + order.FirstName + " " + order.LastName + "<br>");
            bob.Append("Address: " + order.Address + " " + order.City + " " + order.State + " " + order.PostalCode + "<br>");
            bob.Append("Contact: " + order.Email + "     " + order.Phone + "</p>");
            bob.Append("<p>Charge: " + order.CreditCard + " " + order.Experation.ToString("dd-MM-yyyy") + "</p>");
            bob.Append("<p>Credit Card Type: " + order.CcType + "</p>");

            bob.Append("<br>").AppendLine();
            bob.Append("<Table>").AppendLine();
            // Display header 
            string header = "<tr> <th>Item Name</th>" + "<th>Quantity</th>" + "<th>Price</th> <th></th> </tr>";
            bob.Append(header).AppendLine();

            String output = String.Empty;
            try
            {
                foreach (var item in order.OrderDetails)
                {
                    bob.Append("<tr>");
                    output = "<td>" + item.Item.Name + "</td>" + "<td>" + item.Quantity + "</td>" + "<td>" + item.Quantity * item.UnitPrice + "</td>";
                    bob.Append(output).AppendLine();
                    Console.WriteLine(output);
                    bob.Append("</tr>");
                }
            }
            catch (Exception ex)
            {
                output = "Нет заказанных предметов.";
            }
            bob.Append("</Table>");
            bob.Append("<b>");
            // Display footer 
            string footer = String.Format("{0,-12}{1,12}\n",
                                          "Total", order.Total);
            bob.Append(footer).AppendLine();
            bob.Append("</b>");

            return bob.ToString();
        }
    }
}