﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина имени не менее 5 символов")]
        public string name { get; set; }
        [Display(Name = "Введите фамилию")]
        [StringLength(14)]
        [Required(ErrorMessage = "Длина фамилии не менее 14 символов")]
        public string surname { get; set; }
        [Display(Name = "Введите адрес")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина адреса не менее 15 символов")]
        public string phone { get; set; }
        [Display(Name = "Введите номер телефона")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера не менее 10 символов")]
        public string email { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина имени не менее 5 символов")]
        public string adress { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
