using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace OnionDemo.Domain.Entity
{
    public class Review(int rating, string blurb) : DomainEntity
    {
        [Range(0, 100, ErrorMessage = "Value must be between 100 and 0.")]
        public int Rating { get; protected set; } = rating;
        public string Blurb { get; protected set; } = blurb;
        public static Review Create(int rating, string blurb)
        {
            return new Review(rating, blurb);
        }
    }
}
