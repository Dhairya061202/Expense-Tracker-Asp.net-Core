﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
	public class TranscationTable
	{
		[Key]
        public int TranscationId { get; set; }

		//CategoryId
		[Range(1,int.MaxValue,ErrorMessage = "Please select a Category")]
		public int CategoryId { get; set; }
		public CategoryTable? Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0")]
        public int Amount { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string? Note { get; set; } = "";

		public DateTime Date { get; set; } = DateTime.Now;

		[NotMapped]
		public string? CategoryTitleWithIcon {
			get {
				return Category == null ? "" : Category.Icon + " " + Category.Title;

            }
		}

        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + Amount.ToString("C0");
            }
        }
    } 
}
